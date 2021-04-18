using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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
                throw new Exception();
            }
        }

        public static string Read(string path)
        {
            try
            {
                return File.ReadAllText(path);
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        public static void WriteCsv(string path, Dictionary<ProductModel, string> productModels)
        {
            try
            {
                string content = "Путь классификатора,Артикул,Название,Количество на складе\n";
                foreach (KeyValuePair<ProductModel, string> productModel in productModels)
                    content += productModel.Value + productModel.Key + "\n";
                
                File.WriteAllText(path, content, Encoding.UTF8);
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }
    }
}