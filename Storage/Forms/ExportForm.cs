using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Storage.Controllers;
using Storage.Models;

namespace Storage
{
    /// <summary>
    /// Форма для экспорта товаров.
    /// </summary>
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

        /// <summary>
        /// Событие для экспорта в CSV файл товаров, чье кол-во меньше заданного.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exportButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    ProductController.ExportCsv(saveFileDialog.FileName, _productModelsDictionary,
                        (int) minimalBalanceNumericUpDown.Value);

                this.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Не получается экспортировать CSV!\n{exception.Message}", "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}