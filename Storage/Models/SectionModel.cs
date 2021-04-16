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
        /// Свойство для хранения ссылки на родительский раздел.
        /// </summary>
        public SectionModel ParentSection { get; set; }

        /// <summary>
        /// Свойство для хранения ссылки на родительский склад.
        /// </summary>
        public StorageModel Storage { get; set; }

        /// <summary>
        /// Свойство для хранения списка подразделов классификатора.
        /// </summary>
        public List<SectionModel> SectionList { get; set; }

        /// <summary>
        /// Свойство для хранения списка товаров данного классификатора.
        /// </summary>
        public List<ProductModel> ProductList { get; set; }

        /// <summary>
        /// Свойство для получения пути к данному классификатору.
        /// </summary>
        public string Path
        {
            get
            {
                if (ParentSection == null)
                    return Storage.Path + ToString();

                return ParentSection.Path + ToString();
            }
        }

        public SectionModel()
        {
            SectionList = new List<SectionModel>();
            ProductList = new List<ProductModel>();
        }

        public SectionModel(string name, SectionModel parentSection) : this()
        {
            Name = name;
            ParentSection = parentSection;
        }

        public SectionModel(string name, StorageModel storage) : this()
        {
            Name = name;
            Storage = storage;
        }

        public override string ToString()
        {
            return $"/{Name}";
        }
    }
}