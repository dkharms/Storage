using System;
using System.Windows.Forms;
using Storage.Controllers;
using Storage.Models;

namespace Storage
{
    public partial class RandomForm : Form
    {
        private TreeNode _treeNode;
        private bool _isStorage;

        public RandomForm()
        {
            InitializeComponent();
        }

        public RandomForm(TreeNode treeNode, bool isStorage)
        {
            InitializeComponent();
            _treeNode = treeNode;
            _isStorage = isStorage;
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            SectionModel parentSectionModel = null;
            StorageModel parentStorageModel = null;

            Random random = new Random();
            int numberOfSections = (int) sectionNumericUpDown.Value;
            int numberOfProducts = (int) productNumericUpDown.Value;

            if (_isStorage)
                parentStorageModel = (StorageModel) _treeNode.Tag;
            else
                parentSectionModel = (SectionModel) _treeNode.Tag;

            for (int i = 0; i < numberOfSections; i++)
            {
                SectionModel sectionModel;
                TreeNode treeNode;
                if (_isStorage)
                { 
                    sectionModel =
                        SectionController.CreateSection(parentStorageModel, random.Next().ToString(), 0);
                    treeNode = NodeController.CreateNode(_treeNode, sectionModel);
                }
                else
                {
                    sectionModel =
                        SectionController.CreateSection(parentSectionModel, random.Next().ToString(), 0);
                    treeNode = NodeController.CreateNode(_treeNode, sectionModel);
                }

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