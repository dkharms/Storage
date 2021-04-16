using System.Drawing;

namespace Storage.Models
{
    public class ProductModel
    {
        /// <summary>
        /// Свойство для хранения наименования товара.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Свойство для хранения артикула товара.
        /// </summary>
        public string VendorCode { get; set; }

        /// <summary>
        /// Свойство для хранения текстового описания товара.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Свойство для хранения цены товара.
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Свойство для хранения остатка товара на складе.
        /// </summary>
        public int Balance { get; set; }

        /// <summary>
        /// Свойство для хранения ссылки на родительский раздел.
        /// </summary>
        public SectionModel ParentSection { get; set; }

        /// <summary>
        /// Свойство для хранения пути к товару.
        /// </summary>
        public string Path { get; set; }

        public ProductModel()
        {
        }

        public ProductModel(SectionModel parentSection, string name, string vendorCode, string description,
            double price,
            int balance)
        {
            ParentSection = parentSection;
            Name = name;
            VendorCode = vendorCode;
            Description = description;
            Price = price;
            Balance = balance;
        }

        public override string ToString()
        {
            return $"/{Name}";
        }
    }
}