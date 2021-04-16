using System.ComponentModel;

namespace Storage
{
    partial class ProductForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.vendorCodeLabel = new System.Windows.Forms.Label();
            this.vendorTextBox = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.priceLabel = new System.Windows.Forms.Label();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.balanceLabel = new System.Windows.Forms.Label();
            this.balanceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.actionButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize) (this.balanceNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.nameLabel.Location = new System.Drawing.Point(12, 9);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(250, 20);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Название товара:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(12, 32);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(250, 26);
            this.nameTextBox.TabIndex = 1;
            // 
            // vendorCodeLabel
            // 
            this.vendorCodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.vendorCodeLabel.Location = new System.Drawing.Point(299, 9);
            this.vendorCodeLabel.Name = "vendorCodeLabel";
            this.vendorCodeLabel.Size = new System.Drawing.Size(250, 23);
            this.vendorCodeLabel.TabIndex = 2;
            this.vendorCodeLabel.Text = "Артикул товара:";
            // 
            // vendorTextBox
            // 
            this.vendorTextBox.Location = new System.Drawing.Point(299, 32);
            this.vendorTextBox.Name = "vendorTextBox";
            this.vendorTextBox.Size = new System.Drawing.Size(250, 26);
            this.vendorTextBox.TabIndex = 3;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.descriptionLabel.Location = new System.Drawing.Point(12, 81);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(250, 23);
            this.descriptionLabel.TabIndex = 4;
            this.descriptionLabel.Text = "Описание товара:";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(12, 107);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(250, 26);
            this.descriptionTextBox.TabIndex = 5;
            // 
            // priceLabel
            // 
            this.priceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.priceLabel.Location = new System.Drawing.Point(12, 158);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(250, 23);
            this.priceLabel.TabIndex = 6;
            this.priceLabel.Text = "Цена товара:";
            // 
            // priceTextBox
            // 
            this.priceTextBox.Location = new System.Drawing.Point(12, 184);
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.Size = new System.Drawing.Size(250, 26);
            this.priceTextBox.TabIndex = 7;
            // 
            // balanceLabel
            // 
            this.balanceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.balanceLabel.Location = new System.Drawing.Point(299, 158);
            this.balanceLabel.Name = "balanceLabel";
            this.balanceLabel.Size = new System.Drawing.Size(250, 23);
            this.balanceLabel.TabIndex = 8;
            this.balanceLabel.Text = "Кол-во на складе:";
            // 
            // balanceNumericUpDown
            // 
            this.balanceNumericUpDown.Location = new System.Drawing.Point(299, 185);
            this.balanceNumericUpDown.Maximum = new decimal(new int[] {100000, 0, 0, 0});
            this.balanceNumericUpDown.Name = "balanceNumericUpDown";
            this.balanceNumericUpDown.Size = new System.Drawing.Size(250, 26);
            this.balanceNumericUpDown.TabIndex = 9;
            this.balanceNumericUpDown.ThousandsSeparator = true;
            // 
            // actionButton
            // 
            this.actionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.actionButton.Location = new System.Drawing.Point(202, 290);
            this.actionButton.Name = "actionButton";
            this.actionButton.Size = new System.Drawing.Size(150, 50);
            this.actionButton.TabIndex = 10;
            this.actionButton.Text = "Создать";
            this.actionButton.UseVisualStyleBackColor = true;
            this.actionButton.Click += new System.EventHandler(this.actionButton_Click);
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 354);
            this.Controls.Add(this.actionButton);
            this.Controls.Add(this.balanceNumericUpDown);
            this.Controls.Add(this.balanceLabel);
            this.Controls.Add(this.priceTextBox);
            this.Controls.Add(this.priceLabel);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.vendorTextBox);
            this.Controls.Add(this.vendorCodeLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.nameLabel);
            this.Name = "ProductForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.ProductForm_Load);
            ((System.ComponentModel.ISupportInitialize) (this.balanceNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.NumericUpDown balanceNumericUpDown;
        private System.Windows.Forms.Button actionButton;

        private System.Windows.Forms.Label balanceLabel;

        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.TextBox priceTextBox;

        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.TextBox descriptionTextBox;

        private System.Windows.Forms.TextBox vendorTextBox;
        private System.Windows.Forms.Label vendorCodeLabel;

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;

        #endregion
    }
}