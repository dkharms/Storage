using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Storage.Interfaces;
using Storage.Models;

namespace Storage.Controllers
{
    public static class SectionController
    {
        /// <summary>
        /// Создание раздела в данном складе или секции.
        /// </summary>
        /// <param name="iStorable"></param>
        /// <param name="name"></param>
        /// <param name="sortIndex"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static SectionModel CreateSection(IStorable iStorable, string name, int sortIndex)
        {
            SectionModel sectionModel = new SectionModel(name, sortIndex);
            iStorable.SectionList.Add(sectionModel);

            return sectionModel;
        }

        /// <summary>
        /// Проверка на то, чтобы не существовало двух разделов с одинаковым именем.
        /// </summary>
        /// <param name="iStorable"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool CanCreateSection(IStorable iStorable, string name)
        {
            foreach (SectionModel model in iStorable.SectionList)
                if (model.Name == name)
                    return false;

            return true;
        }

        /// <summary>
        /// Проверка на то, что можно обновить раздел.
        /// </summary>
        /// <param name="iStorable"></param>
        /// <param name="sectionModel"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool CanUpdateSection(IStorable iStorable, SectionModel sectionModel, string name)
        {
            foreach (SectionModel model in iStorable.SectionList)
                if (model.Name == name && model != sectionModel)
                    return false;

            return true;
        }

        /// <summary>
        /// Обновления раздела.
        /// </summary>
        /// <param name="sectionModel"></param>
        /// <param name="name"></param>
        /// <param name="sortIndex"></param>
        public static void UpdateSection(SectionModel sectionModel, string name, int sortIndex)
        {
            sectionModel.Name = name;
            sectionModel.SortIndex = sortIndex;
        }


        /// <summary>
        /// Удаление раздела.
        /// </summary>
        /// <param name="iStorable"></param>
        /// <param name="sectionModel"></param>
        public static void DeleteSection(IStorable iStorable, SectionModel sectionModel) =>
            iStorable.SectionList.Remove(sectionModel);
    }
}