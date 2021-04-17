using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using CsvHelper;
using Storage.Models;

namespace Storage.Controllers
{
    public static class FileController
    {
        public static void Init()
        {
            try
            {
                if (!Directory.Exists("storages"))
                    Directory.CreateDirectory("storages");
            }
            catch (Exception e)
            {
            }
        }

        public static void Write(string path, string content)
        {
            try
            {
                File.WriteAllText($"storages/{path}", content);
            }
            catch (Exception e)
            {
                throw new IOException();
            }
        }

        public static string Read(string path)
        {
            try
            {
                return File.ReadAllText($"storages/{path}");
            }
            catch (Exception e)
            {
                throw new IOException();
            }
        }

        public static void WriteCSV(Dictionary<ProductModel, string> productModels)
        {
            try
            {
                string content = "Путь классификатора, Артикул, Название, Количество на складе\n";
                foreach (KeyValuePair<ProductModel, string> productModel in productModels)
                    content += productModel.Value + productModel.Key + "\n";
                
                File.WriteAllText("products.csv", content, Encoding.UTF8);
            }
            catch (Exception e)
            {
                throw new IOException();
            }
        }
    }
}