using System;
using System.Windows.Forms;
using Storage.Controllers;
using Storage.Interfaces;
using Storage.Models;

namespace Storage
{
    public partial class RandomForm : Form
    {
        private TreeNode _treeNode;

        public RandomForm()
        {
            InitializeComponent();
        }

        public RandomForm(TreeNode treeNode)
        {
            InitializeComponent();
            _treeNode = treeNode;
        }

        /// <summary>
        /// Генерация товаров и разделов в количестве, которое указал пользователь.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void generateButton_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            IStorable iStorable = (IStorable) _treeNode.Tag;

            int numberOfSections = (int) sectionNumericUpDown.Value;
            int numberOfProducts = (int) productNumericUpDown.Value;

            for (int i = 0; i < numberOfSections; i++)
            {
                SectionModel sectionModel =
                    SectionController.CreateSection(iStorable, random.Next().ToString(), 0);
                TreeNode treeNode = NodeController.CreateNode(_treeNode, sectionModel);

                for (int j = 0; j < numberOfProducts; j++)
                {
                    ProductModel productModel = ProductController.CreateRandomProduct(sectionModel);
                    TreeNode productTreeNode = NodeController.CreateNode(treeNode, productModel);
                    ProductController.AssignProductToNode(productModel, productTreeNode);
                }
            }

            this.Close();
        }
    }
}