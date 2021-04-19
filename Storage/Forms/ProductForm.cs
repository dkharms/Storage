using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Storage.Controllers;
using Storage.Models;

namespace Storage
{
    public partial class ProductForm : Form
    {
        private TreeNode _treeNode;
        private ProductModel _productModel;
        private bool _isChanging;
        private string _imagePath;

        public ProductForm()
        {
            InitializeComponent();
        }

        public ProductForm(TreeNode treeNode, bool isChanging)
        {
            InitializeComponent();
            _treeNode = treeNode;
            _isChanging = isChanging;
        }

        public ProductForm(TreeNode treeNode, ProductModel productModel, bool isChanging)
        {
            InitializeComponent();
            _treeNode = treeNode;
            _productModel = productModel;
            _isChanging = isChanging;
        }


        /// <summary>
        /// Кнопка для создания продукта или его изменения.
        /// Перед этим проверяется, чтобы все обязательные поля были заполнены.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void actionButton_Click(object sender, EventArgs e)
        {
            if (IsEveryTextBoxFilled())
            {
                string name = nameTextBox.Text;
                string vendorCode = vendorTextBox.Text;
                string description = descriptionTextBox.Text ?? "";
                double price = double.Parse(priceTextBox.Text);
                int balance = (int) balanceNumericUpDown.Value;
                string imagePath = _imagePath ?? "";

                TreeNode rootNode = NodeController.GetTreeRoot(_treeNode);
                List<TreeNode> productNodes =
                    NodeController.GetDeepestNodesByType(rootNode, typeof(ProductModel), new List<TreeNode>());
                
                if (_isChanging)
                {
                    if (!ProductController.CanUpdateProduct(productNodes, _productModel, vendorCode))
                    {
                        MessageBox.Show("Товар с таким же артикулом уже существует!", "Ошибка!", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                    
                    _treeNode.Text = name;
                    ProductController.UpdateProduct(_productModel, name, vendorCode, description, price, balance,
                        imagePath);
                }
                else
                {
                    if (!ProductController.CanCreateProduct(productNodes, vendorCode))
                    {
                        MessageBox.Show("Товар с таким же артикулом уже существует!", "Ошибка!", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                    
                    ProductModel productModel = ProductController.CreateProduct((SectionModel) _treeNode.Tag, name,
                        vendorCode, description, price, balance, imagePath);
                    _productModel = productModel;

                    TreeNode treeNode = NodeController.CreateNode(_treeNode, productModel);
                    ProductController.AssignProductToNode(productModel, treeNode);
                }

                this.Close();
            }
            else
                MessageBox.Show("Проверьте корректность введенных данных!");
        }

        /// <summary>
        /// Проверка на заполненность всех обязательных полей.
        /// </summary>
        /// <returns></returns>
        private bool IsEveryTextBoxFilled()
        {
            if (String.IsNullOrEmpty(nameTextBox.Text))
                return false;
            if (String.IsNullOrEmpty(vendorTextBox.Text))
                return false;
            if (String.IsNullOrEmpty(priceTextBox.Text) || !double.TryParse(priceTextBox.Text, out double _))
                return false;

            return true;
        }

        /// <summary>
        /// Добавление фотографии к данному товару.
        /// </summary>
        /// <param name="imagePath"></param>
        private void AssignProductImage(string imagePath)
        {
            if (String.IsNullOrEmpty(imagePath))
                return;

            try
            {
                pictureBox.Load(imagePath);
                FileInfo fileInfo = new FileInfo(imagePath);
                string newImagePath =
                    $"{FileController.ImageDirectory.FullName}{Path.DirectorySeparatorChar}{fileInfo.Name}";
                File.Copy(imagePath, newImagePath, true);
                _imagePath = newImagePath;
            }
            catch (Exception e)
            {
                openFileDialog.FileName = null;
                MessageBox.Show($"Не получается загрузить изображение товара!\n{e.Message}", "Ошибка!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Подгрузка изображения данного продукта.
        /// </summary>
        /// <param name="imagePath"></param>
        private void LoadProductImage(string imagePath)
        {
            if (String.IsNullOrEmpty(imagePath))
                return;

            try
            {
                pictureBox.Load(imagePath);
                _imagePath = imagePath;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Не получается загрузить изображение товара!\n{e.Message}", "Ошибка!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Подгрузка данных данного продукта.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductForm_Load(object sender, EventArgs e)
        {
            if (_isChanging)
            {
                actionButton.Text = "Изменить";
                nameTextBox.Text = _productModel.Name;
                vendorTextBox.Text = _productModel.VendorCode;
                descriptionTextBox.Text = _productModel.Description;
                priceTextBox.Text = _productModel.Price.ToString();
                balanceNumericUpDown.Value = _productModel.Balance;
                LoadProductImage(_productModel.ImagePath);

                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        /// <summary>
        /// Вызов файлового диалога для выбора фотографии товара.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imageButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                AssignProductImage(imagePath);
            }
        }
    }
}