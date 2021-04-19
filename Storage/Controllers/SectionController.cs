using System;
using System.Collections.Generic;
using Storage.Models;

namespace Storage.Controllers
{
    public static class SectionController
    {
        public static SectionModel CreateSection(StorageModel storageModel, string name, int sortIndex)
        {
            if (CanCreateSection(storageModel, name))
            {
                SectionModel sectionModel = new SectionModel(name, sortIndex);
                storageModel.SectionList.Add(sectionModel);

                return sectionModel;
            }

            throw new Exception();
        }

        public static SectionModel CreateSection(SectionModel sectionModel, string name, int sortIndex)
        {
            if (CanCreateSection(sectionModel, name))
            {
                SectionModel subSectionModel = new SectionModel(name, sortIndex);
                sectionModel.SectionList.Add(subSectionModel);

                return subSectionModel;
            }

            throw new Exception();
        }

        public static bool CanCreateSection(SectionModel sectionModel, string name)
        {
            foreach (SectionModel model in sectionModel.SectionList)
                if (model.Name == name)
                    return false;

            return true;
        }

        public static bool CanCreateSection(StorageModel storageModel, string name)
        {
            foreach (SectionModel model in storageModel.SectionList)
                if (model.Name == name)
                    return false;

            return true;
        }

        public static void UpdateSection(SectionModel sectionModel, string name, int sortIndex)
        {
            sectionModel.Name = name;
            sectionModel.SortIndex = sortIndex;
        }


        public static void DeleteSection(StorageModel storageModel, SectionModel sectionModel) =>
            storageModel.SectionList.Remove(sectionModel);


        public static void DeleteSection(SectionModel parentSectionModel, SectionModel sectionModel) =>
            parentSectionModel.SectionList.Remove(sectionModel);
    }
}