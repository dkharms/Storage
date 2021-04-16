using System.Collections.Generic;
using Storage.Models;

namespace Storage.Controllers
{
    public static class ProductController
    {
        public static List<ProductModel> ProductList = new List<ProductModel>();

        public static ProductModel CreateProduct(SectionModel parentSection, string name, string vendorCode,
            string description, double price, int balance)
        {
            ProductModel productModel = new ProductModel(parentSection, name, vendorCode, description, price, balance);
            parentSection.ProductList.Add(productModel);
            ProductList.Add(productModel);

            return productModel;
        }

        public static void DeleteProduct(SectionModel sectionModel, ProductModel productModel)
        {
            sectionModel.ProductList.Remove(productModel);
            ProductList.Remove(productModel);
        }
    }
}