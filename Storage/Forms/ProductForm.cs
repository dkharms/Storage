using System;
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
                string description = descriptionTextBox.Text;
                double price = double.Parse(priceTextBox.Text);
                int balance = (int) balanceNumericUpDown.Value;

                if (_isChanging)
                {
                    _productModel.Name = name;
                    _productModel.VendorCode = vendorCode;
                    _productModel.Description = description;
                    _productModel.Price = price;
                    _productModel.Balance = balance;

                    _treeNode.Text = name;
                }
                else
                {
                    ProductModel productModel = ProductController.CreateProduct((SectionModel) _treeNode.Tag, name,
                        vendorCode, description, price, balance);

                    _treeNode.Nodes.Add(productModel.Name);
                    _treeNode.Nodes[^1].Tag = productModel;
                    _treeNode.Nodes[^1].ImageIndex = 2;
                    _treeNode.Nodes[^1].SelectedImageIndex = 2;
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
            if (String.IsNullOrEmpty(descriptionTextBox.Text))
                return false;
            if (String.IsNullOrEmpty(priceTextBox.Text) || !double.TryParse(priceTextBox.Text, out double _))
                return false;

            return true;
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
            }
        }
    }
}