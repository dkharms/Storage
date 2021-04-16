using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Storage.Controllers;
using Storage.Models;

namespace Storage
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ChangeActionToolStripsState(true, false, false, false, false);
        }

        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                treeView.SelectedNode = treeView.GetNodeAt(e.Location);
                if (treeView.SelectedNode.Tag is StorageModel)
                    ChangeActionToolStripsState(false, true, false, true, true);
                if (treeView.SelectedNode.Tag is SectionModel)
                    ChangeActionToolStripsState(false, true, true, true, true);
                if (treeView.SelectedNode.Tag is ProductModel)
                    ChangeActionToolStripsState(false, false, false, true, true);

                contextMenuStrip.Show(e.Location);
            }
        }

        private void ChangeActionToolStripsState(bool storageState, bool sectionState, bool productState,
            bool deleteState, bool changeState)
        {
            createStorageInstanceToolStripMenuItem.Enabled = storageState;
            createSectionInstanceToolStripMenuItem.Enabled = sectionState;
            createProductInstanceToolStripMenuItem.Enabled = productState;

            deleteToolStripMenuItem.Enabled = deleteState;
            changeToolStripMenuItem.Enabled = changeState;
        }

        private void treeView_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is SectionModel)
            {
                e.Node.ImageIndex = 1;
                e.Node.SelectedImageIndex = 1;
            }
        }

        private void treeView_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is SectionModel)
            {
                e.Node.ImageIndex = 0;
                e.Node.SelectedImageIndex = 0;
            }
        }

        private void contextMenuStrip_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            ChangeActionToolStripsState(true, false, false, false, false);
        }

        private void createStorageInstanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StorageForm storageForm = new StorageForm(treeView, false) {Owner = this};
            storageForm.ShowDialog();
        }

        private void createSectionInstanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SectionForm sectionForm = new SectionForm(treeView.SelectedNode, false) {Owner = this};
            sectionForm.ShowDialog();
        }

        private void createProductInstanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductForm productForm = new ProductForm(treeView.SelectedNode, false) {Owner = this};
            productForm.ShowDialog();
        }

        private void changeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeView.SelectedNode;

            if (selectedNode.Tag is StorageModel storageModel)
            {
                StorageForm storageForm = new StorageForm(selectedNode, storageModel, true) {Owner = this};
                storageForm.ShowDialog();
            }

            if (selectedNode.Tag is SectionModel sectionModel)
            {
                SectionForm sectionForm = new SectionForm(selectedNode, sectionModel, true) {Owner = this};
                sectionForm.ShowDialog();
            }

            if (selectedNode.Tag is ProductModel productModel)
            {
                ProductForm productForm = new ProductForm(selectedNode, productModel, true) {Owner = this};
                productForm.ShowDialog();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить выбранный узел?", "Удаление узла", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                TreeNode selectedNode = treeView.SelectedNode;
                TreeNode parentNode = selectedNode.Parent;

                if (selectedNode.Tag is StorageModel storageModel)
                    StorageController.DeleteStorage(storageModel);
                
                if (selectedNode.Tag is SectionModel sectionModel)
                {
                    if (parentNode.Tag is StorageModel parentStorageModel)
                        SectionController.DeleteSection(parentStorageModel, sectionModel);
                    if (parentNode.Tag is SectionModel parentSectionModel)
                        SectionController.DeleteSection(parentSectionModel, sectionModel);
                }

                if (selectedNode.Tag is ProductModel productModel)
                    ProductController.DeleteProduct((SectionModel) parentNode.Tag, productModel);


                selectedNode.Remove();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StorageController.SerializeStorages();
        }
    }
}