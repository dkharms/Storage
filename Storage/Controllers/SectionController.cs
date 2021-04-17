using System.Collections.Generic;
using Storage.Models;

namespace Storage.Controllers
{
    public static class SectionController
    {
        public static SectionModel CreateSection(StorageModel storageModel, string name, int sortIndex)
        {
            SectionModel sectionModel = new SectionModel(name, sortIndex);
            storageModel.SectionList.Add(sectionModel);

            return sectionModel;
        }

        public static SectionModel CreateSection(SectionModel sectionModel, string name, int sortIndex)
        {
            SectionModel subSectionModel = new SectionModel(name, sortIndex);
            sectionModel.SectionList.Add(subSectionModel);

            return subSectionModel;
        }

        public static void UpdateSection(SectionModel sectionModel, string name) => sectionModel.Name = name;


        public static void DeleteSection(StorageModel storageModel, SectionModel sectionModel) =>
            storageModel.SectionList.Remove(sectionModel);


        public static void DeleteSection(SectionModel parentSectionModel, SectionModel sectionModel) =>
            parentSectionModel.SectionList.Remove(sectionModel);
    }
}