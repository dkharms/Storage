using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Storage.Models;

namespace Storage.Controllers
{
    public static class StorageController
    {
        public static List<StorageModel> StorageList = new List<StorageModel>();

        public static StorageModel CreateStorage(string name)
        {
            StorageModel storageModel = new StorageModel(name);
            StorageList.Add(storageModel);

            return storageModel;
        }

        public static void DeleteStorage(StorageModel storageModel) => StorageList.Remove(storageModel);

        public static void ChangeStorage(StorageModel storageModel, string name) => storageModel.Name = name;

        private static void SerializeStorage(StorageModel storageModel)
        {
            File.WriteAllText($"{storageModel.HashCode}.json", JsonConvert.SerializeObject(storageModel,
                new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    TypeNameHandling = TypeNameHandling.All
                }));
        }

        public static void SerializeStorages()
        {
            foreach (StorageModel storageModel in StorageList)
                SerializeStorage(storageModel);
        }
    }
}