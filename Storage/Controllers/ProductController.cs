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

        public static ProductModel CreateProduct(SectionModel parentSection, string name, string vendorCode,
            string description, double price, int balance, string imagePath)
        {
            ProductModel productModel = new ProductModel(name, vendorCode, description, price, balance, imagePath);
            parentSection.ProductList.Add(productModel);

            return productModel;
        }

        public static ProductModel CreateRandomProduct(SectionModel parentSection)
        {
            string name = RandomGenerator.Next(0, 1000).ToString();
            string vendorCode = RandomGenerator.Next(0, 1000).ToString();
            string description = "RANDOM DESCRIPTION";
            int price = RandomGenerator.Next(0, 1000);
            int balance = RandomGenerator.Next(0, 1000);

            return CreateProduct(parentSection, name, vendorCode, description, price, balance, null);
        }

        public static void AssignProductToNode(ProductModel productModel, TreeNode treeNode) =>
            ProductDictionary.Add(productModel, treeNode);

        public static void DeleteProduct(SectionModel sectionModel, ProductModel productModel)
        {
            sectionModel.ProductList.Remove(productModel);
            ProductDictionary.Remove(productModel);
        }

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

        public static string GetProductPath(ProductModel productModel) => ProductDictionary[productModel].FullPath;

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