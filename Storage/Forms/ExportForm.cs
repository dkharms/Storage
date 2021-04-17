﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Storage.Controllers;
using Storage.Models;

namespace Storage
{
    public partial class ExportForm : Form
    {
        private Dictionary<ProductModel, string> _productModelsDictionary;

        public ExportForm()
        {
            InitializeComponent();
        }

        public ExportForm(Dictionary<ProductModel, string> productModelsDictionary)
        {
            InitializeComponent();
            _productModelsDictionary = productModelsDictionary;
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    ProductController.ExportCSV(saveFileDialog.FileName, _productModelsDictionary,
                        (int) minimalBalanceNumericUpDown.Value);
                
                this.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Не получается экспортировать CSV!", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}