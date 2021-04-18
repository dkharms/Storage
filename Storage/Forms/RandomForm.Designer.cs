using System.ComponentModel;

namespace Storage
{
    partial class RandomForm
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
            this.sectionNumberLabel = new System.Windows.Forms.Label();
            this.sectionNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.productNumberLabel = new System.Windows.Forms.Label();
            this.productNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.generateButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize) (this.sectionNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.productNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // sectionNumberLabel
            // 
            this.sectionNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.sectionNumberLabel.Location = new System.Drawing.Point(75, 38);
            this.sectionNumberLabel.Name = "sectionNumberLabel";
            this.sectionNumberLabel.Size = new System.Drawing.Size(225, 23);
            this.sectionNumberLabel.TabIndex = 0;
            this.sectionNumberLabel.Text = "Количество разделов:";
            // 
            // sectionNumericUpDown
            // 
            this.sectionNumericUpDown.Location = new System.Drawing.Point(75, 64);
            this.sectionNumericUpDown.Maximum = new decimal(new int[] {500, 0, 0, 0});
            this.sectionNumericUpDown.Name = "sectionNumericUpDown";
            this.sectionNumericUpDown.Size = new System.Drawing.Size(225, 26);
            this.sectionNumericUpDown.TabIndex = 1;
            // 
            // productNumberLabel
            // 
            this.productNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.productNumberLabel.Location = new System.Drawing.Point(75, 111);
            this.productNumberLabel.Name = "productNumberLabel";
            this.productNumberLabel.Size = new System.Drawing.Size(225, 23);
            this.productNumberLabel.TabIndex = 2;
            this.productNumberLabel.Text = "Количество продуктов:";
            // 
            // productNumericUpDown
            // 
            this.productNumericUpDown.Location = new System.Drawing.Point(75, 137);
            this.productNumericUpDown.Maximum = new decimal(new int[] {500, 0, 0, 0});
            this.productNumericUpDown.Name = "productNumericUpDown";
            this.productNumericUpDown.Size = new System.Drawing.Size(225, 26);
            this.productNumericUpDown.TabIndex = 3;
            // 
            // generateButton
            // 
            this.generateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.generateButton.Location = new System.Drawing.Point(108, 210);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(150, 50);
            this.generateButton.TabIndex = 4;
            this.generateButton.Text = "Создать";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // RandomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 329);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.productNumericUpDown);
            this.Controls.Add(this.productNumberLabel);
            this.Controls.Add(this.sectionNumericUpDown);
            this.Controls.Add(this.sectionNumberLabel);
            this.Name = "RandomForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize) (this.sectionNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.productNumericUpDown)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Label productNumberLabel;
        private System.Windows.Forms.NumericUpDown productNumericUpDown;
        private System.Windows.Forms.Label sectionNumberLabel;
        private System.Windows.Forms.NumericUpDown sectionNumericUpDown;

        #endregion
    }
}