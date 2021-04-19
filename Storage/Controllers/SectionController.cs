using System;
using System.Collections.Generic;
using Storage.Interfaces;
using Storage.Models;

namespace Storage.Controllers
{
    public static class SectionController
    {
        public static SectionModel CreateSection(IStorable iStorable, string name, int sortIndex)
        {
            if (CanCreateSection(iStorable, name))
            {
                SectionModel sectionModel = new SectionModel(name, sortIndex);
                iStorable.SectionList.Add(sectionModel);

                return sectionModel;
            }

            throw new Exception();
        }

        public static bool CanCreateSection(IStorable iStorable, string name)
        {
            foreach (SectionModel model in iStorable.SectionList)
                if (model.Name == name)
                    return false;

            return true;
        }

        public static void UpdateSection(SectionModel sectionModel, string name, int sortIndex)
        {
            sectionModel.Name = name;
            sectionModel.SortIndex = sortIndex;
        }


        public static void DeleteSection(IStorable iStorable, SectionModel sectionModel) =>
            iStorable.SectionList.Remove(sectionModel);
    }
}