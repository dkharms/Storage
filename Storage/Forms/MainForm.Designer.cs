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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.treeView = new System.Windows.Forms.TreeView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.createStorageStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createStorageInstanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createSectionInstanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createProductInstanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.changeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.exportToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(978, 33);
            this.menuStrip.TabIndex = 0;
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(91, 29);
            this.exportToolStripMenuItem.Text = "Экспорт";
            // 
            // treeView
            // 
            this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView.ContextMenuStrip = this.contextMenuStrip;
            this.treeView.ImageIndex = 0;
            this.treeView.ImageList = this.imageList;
            this.treeView.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.treeView.Location = new System.Drawing.Point(12, 36);
            this.treeView.Name = "treeView";
            this.treeView.SelectedImageIndex = 0;
            this.treeView.Size = new System.Drawing.Size(300, 646);
            this.treeView.TabIndex = 1;
            this.treeView.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterCollapse);
            this.treeView.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterExpand);
            this.treeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_NodeMouseClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.createStorageStripMenuItem, this.createStripSeparator, this.changeToolStripMenuItem, this.deleteToolStripMenuItem, this.toolStripSeparator1, this.importToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(164, 136);
            this.contextMenuStrip.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.contextMenuStrip_Closed);
            // 
            // createStorageStripMenuItem
            // 
            this.createStorageStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.createStorageInstanceToolStripMenuItem, this.createSectionInstanceToolStripMenuItem, this.createProductInstanceToolStripMenuItem});
            this.createStorageStripMenuItem.Name = "createStorageStripMenuItem";
            this.createStorageStripMenuItem.Size = new System.Drawing.Size(163, 30);
            this.createStorageStripMenuItem.Text = "Создать...";
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
            // createStripSeparator
            // 
            this.createStripSeparator.Name = "createStripSeparator";
            this.createStripSeparator.Size = new System.Drawing.Size(160, 6);
            // 
            // changeToolStripMenuItem
            // 
            this.changeToolStripMenuItem.Name = "changeToolStripMenuItem";
            this.changeToolStripMenuItem.Size = new System.Drawing.Size(163, 30);
            this.changeToolStripMenuItem.Text = "Изменить";
            this.changeToolStripMenuItem.Click += new System.EventHandler(this.changeToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(163, 30);
            this.deleteToolStripMenuItem.Text = "Удалить";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(160, 6);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(163, 30);
            this.importToolStripMenuItem.Text = "Импорт";
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
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(306, 33);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(672, 661);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 694);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;

        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;

        private System.Windows.Forms.ToolStripSeparator createStripSeparator;

        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem createSectionInstanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createStorageInstanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createProductInstanceToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem changeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createStorageStripMenuItem;

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;

        private System.Windows.Forms.ImageList imageList;

        private System.Windows.Forms.TreeView treeView;

        private System.Windows.Forms.OpenFileDialog openFileDialog;

        private System.Windows.Forms.MenuStrip menuStrip;

        #endregion
    }
}