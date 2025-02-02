﻿using System.Collections.Generic;
using Storage.Interfaces;

namespace Storage.Models
{
    public class StorageModel : IStorable
    {
        /// <summary>
        /// Свойство для хранения уникального идентификатора склада.
        /// </summary>
        public string HashCode { get; set; }
        
        /// <summary>
        /// Свойство для хранения названия склада.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Свойство для хранения разделов скалада.
        /// </summary>
        public List<SectionModel> SectionList { get; set; }

        public StorageModel()
        {
            SectionList = new List<SectionModel>();
        }

        public StorageModel(string name) : this()
        {
            HashCode = GetHashCode().ToString();
            Name = name;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}