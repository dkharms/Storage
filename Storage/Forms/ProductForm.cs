using System;
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

                if (_isChanging)
                {
                    _treeNode.Text = name;
                    ProductController.UpdateProduct(_productModel, name, vendorCode, description, price, balance,
                        imagePath);
                }
                else
                {
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
                MessageBox.Show($"Не получается загрузить изображение товара!\n{e.Message}", "Ошибка!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

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
            }
        }

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