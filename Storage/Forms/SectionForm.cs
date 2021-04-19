using System;
using System.Windows.Forms;
using Storage.Controllers;
using Storage.Interfaces;
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

        /// <summary>
        /// Создание нового раздела или изменение данного.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void actionButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Введите имя раздела!");
                return;
            }

            string name = nameTextBox.Text;
            int sortIndex = (int) sortIndexNumericUpDown.Value;

            if (_isChanging)
            {
                if (!SectionController.CanUpdateSection((IStorable) _treeNode.Parent.Tag, _sectionModel, name))
                {
                    MessageBox.Show("Раздел с таким же именем уже существует!", "Ошибка!", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                SectionController.UpdateSection(_sectionModel, name, sortIndex);
                _treeNode.Text = nameTextBox.Text;
            }
            else
            {
                if (!SectionController.CanCreateSection((IStorable) _treeNode.Tag, name))
                {
                    MessageBox.Show("Раздел с таким же именем уже существует!", "Ошибка!", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                SectionModel sectionModel = SectionController.CreateSection((IStorable) _treeNode.Tag, name, sortIndex);
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