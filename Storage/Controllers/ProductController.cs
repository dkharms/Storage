using System.Collections.Generic;
using System.Windows.Forms;
using Storage.Models;

namespace Storage.Controllers
{
    public static class ProductController
    {
        public static Dictionary<ProductModel, TreeNode> ProductDictionary = new Dictionary<ProductModel, TreeNode>();

        public static ProductModel CreateProduct(SectionModel parentSection, string name, string vendorCode,
            string description, double price, int balance)
        {
            ProductModel productModel = new ProductModel(name, vendorCode, description, price, balance);
            parentSection.ProductList.Add(productModel);

            return productModel;
        }

        public static void AssignProductNode(ProductModel productModel, TreeNode treeNode) =>
            ProductDictionary.Add(productModel, treeNode);


        public static void DeleteProduct(SectionModel sectionModel, ProductModel productModel)
        {
            sectionModel.ProductList.Remove(productModel);
            ProductDictionary.Remove(productModel);
        }

        public static void UpdateProduct(ProductModel productModel, string name, string vendorCode, string description,
            double price, int balance)
        {
            productModel.Name = name;
            productModel.VendorCode = vendorCode;
            productModel.Description = description;
            productModel.Price = price;
            productModel.Balance = balance;
        }
    }
}