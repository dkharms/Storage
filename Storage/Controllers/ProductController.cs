using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Storage.Models;

namespace Storage.Controllers
{
    public static class ProductController
    {
        public static Random RandomGenerator = new Random();
        public static Dictionary<ProductModel, TreeNode> ProductDictionary = new Dictionary<ProductModel, TreeNode>();

        /// <summary>
        /// Создание продукта, привязанного к данной секции.
        /// </summary>
        /// <param name="parentSection"></param>
        /// <param name="name"></param>
        /// <param name="vendorCode"></param>
        /// <param name="description"></param>
        /// <param name="price"></param>
        /// <param name="balance"></param>
        /// <param name="imagePath"></param>
        /// <returns></returns>
        public static ProductModel CreateProduct(SectionModel parentSection, string name, string vendorCode,
            string description, double price, int balance, string imagePath)
        {
            ProductModel productModel = new ProductModel(name, vendorCode, description, price, balance, imagePath);
            parentSection.ProductList.Add(productModel);

            return productModel;
        }

        /// <summary>
        /// Создание рандомного продукта с привязкой к данной секции.
        /// </summary>
        /// <param name="parentSection"></param>
        /// <returns></returns>
        public static ProductModel CreateRandomProduct(SectionModel parentSection)
        {
            string name = RandomGenerator.Next(0, 10000).ToString();
            string vendorCode = RandomGenerator.Next(0, 10000).ToString();
            string description = "RANDOM DESCRIPTION";
            int price = RandomGenerator.Next(0, 10000);
            int balance = RandomGenerator.Next(0, 10000);

            return CreateProduct(parentSection, name, vendorCode, description, price, balance, null);
        }

        /// <summary>
        /// Привязка данного продукта к его представлению в TreeView.
        /// </summary>
        /// <param name="productModel"></param>
        /// <param name="treeNode"></param>
        public static void AssignProductToNode(ProductModel productModel, TreeNode treeNode) =>
            ProductDictionary.Add(productModel, treeNode);

        /// <summary>
        /// Удаление продукта из данного раздела.
        /// </summary>
        /// <param name="sectionModel"></param>
        /// <param name="productModel"></param>
        public static void DeleteProduct(SectionModel sectionModel, ProductModel productModel)
        {
            sectionModel.ProductList.Remove(productModel);
            ProductDictionary.Remove(productModel);
        }

        /// <summary>
        /// Обновления продукта.
        /// </summary>
        /// <param name="productModel"></param>
        /// <param name="name"></param>
        /// <param name="vendorCode"></param>
        /// <param name="description"></param>
        /// <param name="price"></param>
        /// <param name="balance"></param>
        /// <param name="imagePath"></param>
        public static void UpdateProduct(ProductModel productModel, string name, string vendorCode, string description,
            double price, int balance, string imagePath)
        {
            productModel.Name = name;
            productModel.VendorCode = vendorCode;
            productModel.Description = description;
            productModel.Price = price;
            productModel.Balance = balance;
            productModel.ImagePath = imagePath;
        }

        /// <summary>
        /// Проверка на то, что можно создать товар.
        /// </summary>
        /// <param name="productModels"></param>
        /// <param name="vendorCode"></param>
        /// <returns></returns>
        public static bool CanCreateProduct(List<TreeNode> productModels, string vendorCode)
        {
            foreach (TreeNode productModel in productModels)
                if (((ProductModel) productModel.Tag).VendorCode == vendorCode)
                    return false;

            return true;
        }

        /// <summary>
        /// Проверка на то, что можно обновить товар.
        /// </summary>
        /// <param name="productModels"></param>
        /// <param name="productModel"></param>
        /// <param name="vendorCode"></param>
        /// <returns></returns>
        public static bool CanUpdateProduct(List<TreeNode> productModels, ProductModel productModel, string vendorCode)
        {
            foreach (TreeNode treeNode in productModels)
            {
                ProductModel anotherProductModel = (ProductModel) treeNode.Tag;
                if (anotherProductModel.VendorCode == vendorCode && anotherProductModel != productModel)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Получение путя продукта.
        /// </summary>
        /// <param name="productModel"></param>
        /// <returns></returns>
        public static string GetProductPath(ProductModel productModel) => ProductDictionary[productModel].FullPath;


        /// <summary>
        /// Экспорт продуктов, кол-во которых меньше, чем введеное, в CSV файл.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="productModels"></param>
        /// <param name="minimalQuantity"></param>
        public static void ExportCsv(string path, Dictionary<ProductModel, string> productModels, int minimalQuantity)
        {
            Dictionary<ProductModel, string> appropriateProductModels = new Dictionary<ProductModel, string>();
            foreach (KeyValuePair<ProductModel, string> productModel in productModels)
                if (productModel.Key.Balance <= minimalQuantity)
                    appropriateProductModels.Add(productModel.Key, productModel.Value);

            FileController.WriteCsv(path, productModels);
        }
    }
}