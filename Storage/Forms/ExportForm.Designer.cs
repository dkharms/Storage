using System.ComponentModel;

namespace Storage
{
    partial class ExportForm
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
            this.minimalBalanceLabel = new System.Windows.Forms.Label();
            this.exportButton = new System.Windows.Forms.Button();
            this.minimalBalanceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize) (this.minimalBalanceNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // minimalBalanceLabel
            // 
            this.minimalBalanceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.minimalBalanceLabel.Location = new System.Drawing.Point(24, 40);
            this.minimalBalanceLabel.Name = "minimalBalanceLabel";
            this.minimalBalanceLabel.Size = new System.Drawing.Size(224, 43);
            this.minimalBalanceLabel.TabIndex = 0;
            this.minimalBalanceLabel.Text = "Минимальное количество товара:";
            // 
            // exportButton
            // 
            this.exportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.exportButton.Location = new System.Drawing.Point(39, 204);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(193, 58);
            this.exportButton.TabIndex = 2;
            this.exportButton.Text = "Экспорт";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // minimalBalanceNumericUpDown
            // 
            this.minimalBalanceNumericUpDown.Location = new System.Drawing.Point(24, 98);
            this.minimalBalanceNumericUpDown.Maximum = new decimal(new int[] {100000000, 0, 0, 0});
            this.minimalBalanceNumericUpDown.Name = "minimalBalanceNumericUpDown";
            this.minimalBalanceNumericUpDown.Size = new System.Drawing.Size(224, 26);
            this.minimalBalanceNumericUpDown.TabIndex = 3;
            this.minimalBalanceNumericUpDown.ThousandsSeparator = true;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "csv";
            // 
            // ExportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 294);
            this.Controls.Add(this.minimalBalanceNumericUpDown);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.minimalBalanceLabel);
            this.Name = "ExportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize) (this.minimalBalanceNumericUpDown)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.SaveFileDialog saveFileDialog;

        private System.Windows.Forms.NumericUpDown minimalBalanceNumericUpDown;

        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Label minimalBalanceLabel;

        #endregion
    }
}