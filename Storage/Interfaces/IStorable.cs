using System.Collections.Generic;
using Storage.Models;

namespace Storage.Interfaces
{
    public interface IStorable
    {
        /// <summary>
        /// Свойство для хранения разделов.
        /// </summary>
        public List<SectionModel> SectionList { get; set; }
    }
}