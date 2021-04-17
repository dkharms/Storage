using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        private string[] _columnHeaders = {"Путь к товару", "Название", "Цена", "Остаток на складе"};

        public MainForm()
        {
            InitializeComponent();
        }

        private void SetupListView(int widthOfColumn, params string[] columnsHeaders)
        {
            productListView.View = View.Details;
            foreach (string columnsHeader in columnsHeaders)
                productListView.Columns.Add(columnsHeader, widthOfColumn, HorizontalAlignment.Left);
        }

        private void InitializeDirectories()
        {
            try
            {
                FileController.Init();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Не получается создать стартовую директорию!", "Ошибка!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeDirectories();
            SetupListView(200, _columnHeaders);
            ChangeActionToolStripsState(
                true, false, false, false, false, false, false);
        }

        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                treeView.SelectedNode = treeView.GetNodeAt(e.Location);
                Dictionary<TreeNode, List<TreeNode>> treeNodes =
                    NodeController.GetDeepestNodes(treeView.SelectedNode, new Dictionary<TreeNode, List<TreeNode>>());

                GenerateListViewItems(treeNodes);
            }

            if (e.Button == MouseButtons.Right)
            {
                treeView.SelectedNode = treeView.GetNodeAt(e.Location);
                if (treeView.SelectedNode.Tag is StorageModel)
                    ChangeActionToolStripsState(
                        false, true, false, true, true, true, true);
                if (treeView.SelectedNode.Tag is SectionModel)
                    ChangeActionToolStripsState(
                        false, true, true, true, true, true, false);
                if (treeView.SelectedNode.Tag is ProductModel)
                    ChangeActionToolStripsState(
                        false, false, false, true, true, false, false);

                contextMenuStrip.Show(e.Location);
            }
        }

        private void GenerateListViewItems(Dictionary<TreeNode, List<TreeNode>> treeNodes)
        {
            productListView.Items.Clear();
            productListView.BeginUpdate();

            foreach (KeyValuePair<TreeNode, List<TreeNode>> treeNode in treeNodes)
            {
                foreach (TreeNode node in treeNode.Value)
                {
                    if (node.Tag is ProductModel productModel)
                    {
                        string[] productInfo =
                        {
                            ProductController.GetProductPath(productModel), productModel.Name,
                            productModel.Price.ToString(), productModel.Balance.ToString(),
                        };
                        productListView.Items.Add(new ListViewItem(productInfo) {Tag = productModel});
                    }
                }
            }

            productListView.EndUpdate();
        }

        private void UpdateListViewItems()
        {
            foreach (ListViewItem listViewItem in productListView.Items)
            {
                ProductModel productModel = (ProductModel) listViewItem.Tag;
                if (ProductController.ProductDictionary.ContainsKey(productModel))
                {
                    listViewItem.SubItems[0].Text = ProductController.GetProductPath(productModel);
                    listViewItem.SubItems[1].Text = productModel.Name;
                    listViewItem.SubItems[2].Text = productModel.Price.ToString();
                    listViewItem.SubItems[3].Text = productModel.Balance.ToString();
                }
                else
                    productListView.Items.Remove(listViewItem);
            }
        }

        private void ChangeActionToolStripsState(bool storageState, bool sectionState, bool productState,
            bool deleteState, bool changeState, bool sortState, bool exportState)
        {
            createStorageInstanceToolStripMenuItem.Enabled = storageState;
            createSectionInstanceToolStripMenuItem.Enabled = sectionState;
            createProductInstanceToolStripMenuItem.Enabled = productState;

            deleteToolStripMenuItem.Enabled = deleteState;
            changeToolStripMenuItem.Enabled = changeState;
            sortToolStripMenuItem.Enabled = sortState;
            exportCSVToolStripMenu.Enabled = exportState;
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
            ChangeActionToolStripsState(
                true, false, false, false, false, false, false);
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

            UpdateListViewItems();
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
                    ProductController.DeleteProduct(parentNode.Tag as SectionModel, productModel);

                UpdateListViewItems();
                selectedNode.Remove();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                StorageController.SerializeStorages();
            }
            catch (IOException ioException)
            {
                e.Cancel = true;
                MessageBox.Show(
                    $"Не получается сериализовать склады!\nПроверьте правильность названия складов!\n" +
                    $"{ioException.Message}", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exportCSVToolStripMenu_Click(object sender, EventArgs e)
        {
            Dictionary<ProductModel, string> productModelsDictionary = new Dictionary<ProductModel, string>();
            TreeNode selectedNode = treeView.SelectedNode;

            List<TreeNode> productNodes =
                NodeController.GetDeepestNodesByType(selectedNode, typeof(ProductModel), new List<TreeNode>());

            foreach (TreeNode productNode in productNodes)
                productModelsDictionary.Add((ProductModel) productNode.Tag, productNode.FullPath);

            ExportForm exportForm = new ExportForm(productModelsDictionary) {Owner = this};
            exportForm.ShowDialog();
        }
    }
}