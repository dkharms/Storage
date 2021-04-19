using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using Storage.Models;

namespace Storage.Controllers
{
    public static class StorageController
    {
        public static List<StorageModel> StorageList = new List<StorageModel>();

        
        /// <summary>
        /// Создание склада с данным названием.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static StorageModel CreateStorage(string name)
        {
            StorageModel storageModel = new StorageModel(name);
            StorageList.Add(storageModel);

            return storageModel;
        }

        /// <summary>
        /// Удаление данного склада.
        /// </summary>
        /// <param name="storageModel"></param>
        public static void DeleteStorage(StorageModel storageModel) => StorageList.Remove(storageModel);

        /// <summary>
        /// Обновление склада.
        /// </summary>
        /// <param name="storageModel"></param>
        /// <param name="name"></param>
        public static void UpdateStorage(StorageModel storageModel, string name) => storageModel.Name = name;

        /// <summary>
        /// Сериализация данного склада.
        /// </summary>
        /// <param name="storageModel"></param>
        private static void SerializeStorage(StorageModel storageModel)
        {
            string jsonContent = JsonConvert.SerializeObject(storageModel,
                new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    TypeNameHandling = TypeNameHandling.All
                });
            
            FileController.Write($"{storageModel.HashCode}.json", jsonContent);
        }

        /// <summary>
        /// Сериализация всех складов, которые есть в StorageList.
        /// </summary>
        public static void SerializeStorages()
        {
            foreach (StorageModel storageModel in StorageList)
                SerializeStorage(storageModel);
        }

        /// <summary>
        /// Десериализация определенного склада.
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static StorageModel DeserializeStorage(string json)
        {
            StorageModel storageModel = JsonConvert.DeserializeObject<StorageModel>(json);
            StorageList.Add(storageModel);

            return storageModel;
        }
    }
}