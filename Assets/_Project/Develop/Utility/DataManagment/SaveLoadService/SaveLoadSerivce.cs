using Assets._Project.Develop.Data;
using Assets._Project.Develop.Utility.DataManagment.Keys;
using Assets._Project.Develop.Utility.DataManagment.Serializator;
using Assets._Project.Develop.Utility.DataManagment.Storage;
using System;
using System.Collections;

namespace Assets._Project.Develop.Utility.DataManagment.SaveLoadService
{
    public class SaveLoadSerivce : ISaveLoadService
    {
        private readonly ISerializator _serializator;
        private readonly IDataKeys _dataKeys;
        private readonly IDataStorage _dataStorage;

        public SaveLoadSerivce(ISerializator serializator, IDataKeys dataKeys, IDataStorage dataStorage)
        {
            _serializator = serializator;
            _dataKeys = dataKeys;
            _dataStorage = dataStorage;
        }

        public IEnumerator HasData<T>(Action<bool> onCompleate) where T : ISaveData
        {
            yield return _dataStorage.HasData(_dataKeys.GetKeyByType<T>(), onCompleate);
        }

        public IEnumerator Load<T>(Action<T> onCompleate) where T : ISaveData
        {
            yield return _dataStorage.Load(_dataKeys.GetKeyByType<T>(), dataAsString =>
                onCompleate?.Invoke(_serializator.Deserialize<T>(dataAsString)));
        }

        public IEnumerator Remove<T>(Action onCompleate = null) where T : ISaveData
        {
            yield return _dataStorage.Remove(_dataKeys.GetKeyByType<T>(), onCompleate);
        }

        public IEnumerator Save<T>(T data, Action onCompleate = null) where T : ISaveData
        {
            yield return _dataStorage.Save(_dataKeys.GetKeyByType<T>(), _serializator.Serialize(data), onCompleate);
        }
    }
}
