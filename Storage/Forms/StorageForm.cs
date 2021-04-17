using System;
using System.Windows.Forms;
using Storage.Controllers;
using Storage.Models;

namespace Storage
{
    public partial class StorageForm : Form
    {
        private TreeView _treeView;
        private TreeNode _treeNode;
        private StorageModel _storageModel;
        private bool _isChanging;

        public StorageForm()
        {
            InitializeComponent();
        }

        public StorageForm(TreeView treeView, bool isChanging)
        {
            InitializeComponent();
            _treeView = treeView;
            _isChanging = isChanging;
        }

        public StorageForm(TreeNode treeNode, StorageModel storageModel, bool isChanging)
        {
            InitializeComponent();
            _treeNode = treeNode;
            _storageModel = storageModel;
            _isChanging = isChanging;
        }

        private void actionStorageButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Введите имя склада!");
                return;
            }

            if (_isChanging)
            {
                _treeNode.Text = nameTextBox.Text;
                StorageController.UpdateStorage(_storageModel, nameTextBox.Text);
            }
            else
            {
                StorageModel storageModel = StorageController.CreateStorage(nameTextBox.Text);
                NodeController.CreateNode(_treeView, storageModel);
            }

            this.Close();
        }

        private void StorageForm_Load(object sender, EventArgs e)
        {
            nameTextBox.Select();

            if (_isChanging)
            {
                nameTextBox.Text = _storageModel.Name;
                actionStorageButton.Text = "Изменить";
            }
        }
    }
}