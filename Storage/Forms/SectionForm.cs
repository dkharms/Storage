using System;
using System.Windows.Forms;
using Storage.Controllers;
using Storage.Models;

namespace Storage
{
    public partial class SectionForm : Form
    {
        private TreeNode _treeNode;
        private SectionModel _sectionModel;
        private bool _isChanging;


        public SectionForm()
        {
            InitializeComponent();
        }

        public SectionForm(TreeNode treeNode, bool isChanging)
        {
            InitializeComponent();
            _treeNode = treeNode;
            _isChanging = isChanging;
        }

        public SectionForm(TreeNode treeNode, SectionModel sectionModel, bool isChanging)
        {
            InitializeComponent();
            _treeNode = treeNode;
            _sectionModel = sectionModel;
            _isChanging = isChanging;
        }

        private void actionButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Введите имя раздела!");
                return;
            }

            if (_isChanging)
            {
                _treeNode.Text = nameTextBox.Text;
                SectionController.UpdateSection(_sectionModel, nameTextBox.Text);
            }
            else
            {
                SectionModel sectionModel;
                if (_treeNode.Tag is StorageModel)
                    sectionModel = SectionController.CreateSection((StorageModel) _treeNode.Tag, nameTextBox.Text,
                        (int) sortIndexNumericUpDown.Value);
                else
                    sectionModel = SectionController.CreateSection((SectionModel) _treeNode.Tag, nameTextBox.Text,
                        (int) sortIndexNumericUpDown.Value);

                NodeController.CreateNode(_treeNode, sectionModel);
            }

            this.Close();
        }

        private void SectionForm_Load(object sender, EventArgs e)
        {
            nameTextBox.Select();

            if (_isChanging)
            {
                sortIndexNumericUpDown.Value = ((SectionModel) _treeNode.Tag).SortIndex;
                nameTextBox.Text = (_treeNode.Tag as SectionModel)?.Name;
                actionButton.Text = "Изменить";
            }
        }
    }
}