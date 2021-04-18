namespace Storage
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.treeView = new System.Windows.Forms.TreeView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.createStorageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createStorageInstanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createSectionInstanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createProductInstanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.sortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.exportCSVToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.productListView = new System.Windows.Forms.ListView();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView.ContextMenuStrip = this.contextMenuStrip;
            this.treeView.ImageIndex = 0;
            this.treeView.ImageList = this.imageList;
            this.treeView.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.treeView.Location = new System.Drawing.Point(12, 12);
            this.treeView.Name = "treeView";
            this.treeView.PathSeparator = "/";
            this.treeView.SelectedImageIndex = 0;
            this.treeView.Size = new System.Drawing.Size(400, 670);
            this.treeView.TabIndex = 1;
            this.treeView.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterCollapse);
            this.treeView.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterExpand);
            this.treeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_NodeMouseClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.createStorageToolStripMenuItem, this.createToolStripSeparator, this.sortToolStripMenuItem, this.changeToolStripMenuItem, this.deleteToolStripMenuItem, this.deleteToolStripSeparator, this.importToolStripMenuItem, this.actionToolStripSeparator, this.exportCSVToolStripMenu});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(209, 202);
            this.contextMenuStrip.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.contextMenuStrip_Closed);
            // 
            // createStorageToolStripMenuItem
            // 
            this.createStorageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.createStorageInstanceToolStripMenuItem, this.createSectionInstanceToolStripMenuItem, this.createProductInstanceToolStripMenuItem});
            this.createStorageToolStripMenuItem.Name = "createStorageToolStripMenuItem";
            this.createStorageToolStripMenuItem.Size = new System.Drawing.Size(208, 30);
            this.createStorageToolStripMenuItem.Text = "Создать...";
            // 
            // createStorageInstanceToolStripMenuItem
            // 
            this.createStorageInstanceToolStripMenuItem.Name = "createStorageInstanceToolStripMenuItem";
            this.createStorageInstanceToolStripMenuItem.Size = new System.Drawing.Size(139, 30);
            this.createStorageInstanceToolStripMenuItem.Text = "Склад";
            this.createStorageInstanceToolStripMenuItem.Click += new System.EventHandler(this.createStorageInstanceToolStripMenuItem_Click);
            // 
            // createSectionInstanceToolStripMenuItem
            // 
            this.createSectionInstanceToolStripMenuItem.Name = "createSectionInstanceToolStripMenuItem";
            this.createSectionInstanceToolStripMenuItem.Size = new System.Drawing.Size(139, 30);
            this.createSectionInstanceToolStripMenuItem.Text = "Раздел";
            this.createSectionInstanceToolStripMenuItem.Click += new System.EventHandler(this.createSectionInstanceToolStripMenuItem_Click);
            // 
            // createProductInstanceToolStripMenuItem
            // 
            this.createProductInstanceToolStripMenuItem.Name = "createProductInstanceToolStripMenuItem";
            this.createProductInstanceToolStripMenuItem.Size = new System.Drawing.Size(139, 30);
            this.createProductInstanceToolStripMenuItem.Text = "Товар";
            this.createProductInstanceToolStripMenuItem.Click += new System.EventHandler(this.createProductInstanceToolStripMenuItem_Click);
            // 
            // createToolStripSeparator
            // 
            this.createToolStripSeparator.Name = "createToolStripSeparator";
            this.createToolStripSeparator.Size = new System.Drawing.Size(205, 6);
            // 
            // sortToolStripMenuItem
            // 
            this.sortToolStripMenuItem.Name = "sortToolStripMenuItem";
            this.sortToolStripMenuItem.Size = new System.Drawing.Size(208, 30);
            this.sortToolStripMenuItem.Text = "Сортировать";
            this.sortToolStripMenuItem.Click += new System.EventHandler(this.sortToolStripMenuItem_Click);
            // 
            // changeToolStripMenuItem
            // 
            this.changeToolStripMenuItem.Name = "changeToolStripMenuItem";
            this.changeToolStripMenuItem.Size = new System.Drawing.Size(208, 30);
            this.changeToolStripMenuItem.Text = "Изменить";
            this.changeToolStripMenuItem.Click += new System.EventHandler(this.changeToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(208, 30);
            this.deleteToolStripMenuItem.Text = "Удалить";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // deleteToolStripSeparator
            // 
            this.deleteToolStripSeparator.Name = "deleteToolStripSeparator";
            this.deleteToolStripSeparator.Size = new System.Drawing.Size(205, 6);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(208, 30);
            this.importToolStripMenuItem.Text = "Импорт склада";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // actionToolStripSeparator
            // 
            this.actionToolStripSeparator.Name = "actionToolStripSeparator";
            this.actionToolStripSeparator.Size = new System.Drawing.Size(205, 6);
            // 
            // exportCSVToolStripMenu
            // 
            this.exportCSVToolStripMenu.Name = "exportCSVToolStripMenu";
            this.exportCSVToolStripMenu.Size = new System.Drawing.Size(208, 30);
            this.exportCSVToolStripMenu.Text = "Экспорт CSV";
            this.exportCSVToolStripMenu.Click += new System.EventHandler(this.exportCSVToolStripMenu_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer) (resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "folder.png");
            this.imageList.Images.SetKeyName(1, "opened_folder.png");
            this.imageList.Images.SetKeyName(2, "product.png");
            this.imageList.Images.SetKeyName(3, "storage.png");
            // 
            // productListView
            // 
            this.productListView.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.productListView.Location = new System.Drawing.Point(418, 12);
            this.productListView.Name = "productListView";
            this.productListView.Size = new System.Drawing.Size(848, 670);
            this.productListView.TabIndex = 2;
            this.productListView.UseCompatibleStateImageBehavior = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 694);
            this.Controls.Add(this.productListView);
            this.Controls.Add(this.treeView);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ToolStripMenuItem sortToolStripMenuItem;

        private System.Windows.Forms.ListView productListView;

        private System.Windows.Forms.ToolStripSeparator actionToolStripSeparator;

        private System.Windows.Forms.ToolStripMenuItem exportCSVToolStripMenu;

        private System.Windows.Forms.ToolStripSeparator deleteToolStripSeparator;

        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;

        private System.Windows.Forms.ToolStripSeparator createToolStripSeparator;

        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem createSectionInstanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createStorageInstanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createProductInstanceToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem changeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createStorageToolStripMenuItem;

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;

        private System.Windows.Forms.ImageList imageList;

        private System.Windows.Forms.TreeView treeView;

        private System.Windows.Forms.OpenFileDialog openFileDialog;

        #endregion
    }
}