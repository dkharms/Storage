using System.Collections.Generic;

namespace Storage.Models
{
    public class SectionModel
    {
        /// <summary>
        /// Свойство для хранения имени классификатора.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Свойство для хранения списка подразделов классификатора.
        /// </summary>
        public List<SectionModel> SectionList { get; set; }

        /// <summary>
        /// Свойство для хранения списка товаров данного классификатора.
        /// </summary>
        public List<ProductModel> ProductList { get; set; }

        public SectionModel()
        {
            SectionList = new List<SectionModel>();
            ProductList = new List<ProductModel>();
        }

        public SectionModel(string name) : this()
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"/{Name}";
        }
    }
}