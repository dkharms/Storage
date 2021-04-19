using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Storage.Models;

namespace Storage.Controllers
{
    public static class FileController
    {
        public static DirectoryInfo StorageDirectory;
        public static DirectoryInfo ImageDirectory;

        /// <summary>
        /// Инициализация нужных директорий.
        /// </summary>
        public static void Init()
        {
            try
            {
                if (!Directory.Exists("storages"))
                    StorageDirectory = Directory.CreateDirectory("storages");
                else
                    StorageDirectory = new DirectoryInfo("storages");

                if (!Directory.Exists("images"))
                    ImageDirectory = Directory.CreateDirectory("images");
                else
                    ImageDirectory = new DirectoryInfo("images");
            }
            catch (Exception e)
            {
            }
        }

        /// <summary>
        /// Запись в файл.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="content"></param>
        /// <exception cref="Exception"></exception>
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

        /// <summary>
        /// Чтение файла.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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

        /// <summary>
        /// Запись в .csv файл товаров, кол-во которых на складе меньше, чем задал пользователь.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="productModels"></param>
        /// <exception cref="Exception"></exception>
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