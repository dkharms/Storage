using System;
using System.Collections.Generic;
using Storage.Interfaces;

namespace Storage.Models
{
    public class SectionModel : IComparable<SectionModel>, IStorable
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

        /// <summary>
        /// Свойство для хранения "кода сортировки".
        /// </summary>
        public int SortIndex { get; set; }

        public SectionModel()
        {
            SectionList = new List<SectionModel>();
            ProductList = new List<ProductModel>();
        }

        public SectionModel(string name, int sortIndex) : this()
        {
            Name = name;
            SortIndex = sortIndex;
        }

        public int CompareTo(SectionModel other)
        {
            if (this.SortIndex == other.SortIndex)
                return string.Compare(this.Name, other.Name);

            return this.SortIndex - other.SortIndex;
        }


        public override string ToString()
        {
            return $"/{Name}";
        }
    }
}