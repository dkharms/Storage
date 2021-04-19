using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Storage.Controllers;
using Storage.Interfaces;
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

        /// <summary>
        /// Добавление всех колонок в ListView.
        /// </summary>
        /// <param name="widthOfColumn"></param>
        /// <param name="columnsHeaders"></param>
        private void SetupListView(int widthOfColumn, params string[] columnsHeaders)
        {
            productListView.View = View.Details;
            foreach (string columnsHeader in columnsHeaders)
                productListView.Columns.Add(columnsHeader, widthOfColumn, HorizontalAlignment.Left);
        }

        /// <summary>
        /// Создание начальных директорий.
        /// </summary>
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

        /// <summary>
        /// Событие, срабатывающее, при нажатии на нод из TreeView.
        /// Если была нажата левая кнопка мыши, то в ListView выводятся все товары разделов и подразделов.
        /// Если была нажата правая кнопка мыши, то открывается контекстное меню для взаимодействия с программой.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Наполнение ListView товарами, что были найдены в разделах и подразделах.
        /// </summary>
        /// <param name="treeNodes"></param>
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

        /// <summary>
        /// Событие, срабатывающее при изменении какого-либо объекта, представленного в TreeView.
        /// </summary>
        private void UpdateListViewItems()
        {
            productListView.BeginUpdate();
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

            productListView.EndUpdate();
        }

        /// <summary>
        /// Изменения состояния кнопок для удобства взаимодействия с программой.
        /// </summary>
        /// <param name="storageState"></param>
        /// <param name="sectionState"></param>
        /// <param name="productState"></param>
        /// <param name="deleteState"></param>
        /// <param name="changeState"></param>
        /// <param name="sortState"></param>
        /// <param name="exportState"></param>
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

        /// <summary>
        /// Изменение картинки нода, если он представляет объект типа SectionModel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is SectionModel)
            {
                e.Node.ImageIndex = 1;
                e.Node.SelectedImageIndex = 1;
            }
        }

        /// <summary>
        /// Изменение картинки нода, если он представляет объект типа SectionModel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is SectionModel)
            {
                e.Node.ImageIndex = 0;
                e.Node.SelectedImageIndex = 0;
            }
        }

        /// <summary>
        /// Изменения состояние кнопок для удобства взаимодействия с программой.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            ChangeActionToolStripsState(
                true, false, false, false, false, false, false);
        }

        /// <summary>
        /// Открытие формы для создания склада.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createStorageInstanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StorageForm storageForm = new StorageForm(treeView, false) {Owner = this};
            storageForm.ShowDialog();
        }

        /// <summary>
        /// Открытие формы для создания продукта.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createProductInstanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductForm productForm = new ProductForm(treeView.SelectedNode, false) {Owner = this};
            productForm.ShowDialog();
        }

        /// <summary>
        /// Открытие формы для изменения склада, раздела или продукта.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Удаление нода, который представляет склад, раздел или продукт.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    SectionController.DeleteSection((IStorable) parentNode.Tag, sectionModel);

                if (selectedNode.Tag is ProductModel productModel)
                    ProductController.DeleteProduct(parentNode.Tag as SectionModel, productModel);

                UpdateListViewItems();
                selectedNode.Remove();
            }
        }

        /// <summary>
        /// Сериализация складов при закрытии формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                StorageController.SerializeStorages();
            }
            catch (Exception exception)
            {
                e.Cancel = true;
                MessageBox.Show(
                    $"Не получается сериализовать склады!\nПроверьте правильность названия складов!\n" +
                    $"{exception.Message}", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Получение всех продуктов данного склада и открытие формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Импорт склада в программу и заполнение TreeView его разделами и продуктами.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog.InitialDirectory = FileController.StorageDirectory.FullName;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string json = FileController.Read(openFileDialog.FileName);
                    StorageModel storageModel = StorageController.DeserializeStorage(json);
                    NodeController.FillTreeView(treeView, storageModel);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Не получается импортировать склад!\n{exception.Message}", "Ошибка!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Сортировка данного нода.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sortToolStripMenuItem_Click(object sender, EventArgs e) =>
            NodeController.SortNodes(treeView, treeView.SelectedNode);

        /// <summary>
        /// Открытие формы для создания раздела вручную.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void handToolStripMenu_Click(object sender, EventArgs e)
        {
            SectionForm sectionForm = new SectionForm(treeView.SelectedNode, false) {Owner = this};
            sectionForm.ShowDialog();
        }

        /// <summary>
        /// Открытие формы для создание разделов и товаров с помощью рандома.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void generateToolStripMenu_Click(object sender, EventArgs e)
        {
            TreeNode selectedTreeNode = treeView.SelectedNode;
            RandomForm randomForm = new RandomForm(selectedTreeNode) {Owner = this};
            randomForm.ShowDialog();
        }
    }
}