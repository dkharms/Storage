﻿using System.ComponentModel;

namespace Storage
{
    partial class SectionForm
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
            this.actionButton = new System.Windows.Forms.Button();
            this.sortIndexLabel = new System.Windows.Forms.Label();
            this.sortIndexNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize) (this.sortIndexNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.nameLabel.Location = new System.Drawing.Point(35, 40);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(200, 23);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Название раздела:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(35, 75);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(200, 26);
            this.nameTextBox.TabIndex = 1;
            // 
            // actionButton
            // 
            this.actionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.actionButton.Location = new System.Drawing.Point(62, 232);
            this.actionButton.Name = "actionButton";
            this.actionButton.Size = new System.Drawing.Size(150, 50);
            this.actionButton.TabIndex = 3;
            this.actionButton.Text = "Создать";
            this.actionButton.UseVisualStyleBackColor = true;
            this.actionButton.Click += new System.EventHandler(this.actionButton_Click);
            // 
            // sortIndexLabel
            // 
            this.sortIndexLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.sortIndexLabel.Location = new System.Drawing.Point(35, 121);
            this.sortIndexLabel.Name = "sortIndexLabel";
            this.sortIndexLabel.Size = new System.Drawing.Size(200, 23);
            this.sortIndexLabel.TabIndex = 4;
            this.sortIndexLabel.Text = "Код сортировки:";
            // 
            // sortIndexNumericUpDown
            // 
            this.sortIndexNumericUpDown.Location = new System.Drawing.Point(35, 156);
            this.sortIndexNumericUpDown.Maximum = new decimal(new int[] {100000, 0, 0, 0});
            this.sortIndexNumericUpDown.Name = "sortIndexNumericUpDown";
            this.sortIndexNumericUpDown.Size = new System.Drawing.Size(200, 26);
            this.sortIndexNumericUpDown.TabIndex = 2;
            // 
            // SectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 294);
            this.Controls.Add(this.sortIndexNumericUpDown);
            this.Controls.Add(this.sortIndexLabel);
            this.Controls.Add(this.actionButton);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.nameLabel);
            this.Name = "SectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.SectionForm_Load);
            ((System.ComponentModel.ISupportInitialize) (this.sortIndexNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.NumericUpDown sortIndexNumericUpDown;

        private System.Windows.Forms.Label sortIndexLabel;

        private System.Windows.Forms.Button actionButton;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;

        #endregion
    }
}