using System.Collections.Generic;
using Storage.Models;

namespace Storage.Controllers
{
    public static class SectionController
    {
        public static SectionModel CreateSection(StorageModel storageModel, string name)
        {
            SectionModel sectionModel = new SectionModel(name, storageModel);
            storageModel.SectionList.Add(sectionModel);

            return sectionModel;
        }

        public static SectionModel CreateSection(SectionModel sectionModel, string name)
        {
            SectionModel subSectionModel = new SectionModel(name, sectionModel);
            sectionModel.SectionList.Add(subSectionModel);

            return subSectionModel;
        }

        public static void ChangeSection(SectionModel sectionModel, string name) => sectionModel.Name = name;

        public static void DeleteSection(StorageModel storageModel, SectionModel sectionModel) =>
            sectionModel.Storage.SectionList.Remove(sectionModel);


        public static void DeleteSection(SectionModel parentSectionModel, SectionModel sectionModel) =>
            parentSectionModel.SectionList.Remove(sectionModel);
    }
}