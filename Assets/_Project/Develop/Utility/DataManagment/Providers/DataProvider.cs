using Assets._Project.Develop.Data;
using Assets._Project.Develop.Utility.DataManagment.SaveLoadService;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Assets._Project.Develop.Utility.DataManagment.Providers
{
    public abstract class DataProvider<T> where T : ISaveData
    {
        private readonly ISaveLoadService _saveLoadService;
        private T _data;

        private List<IDataReader<T>> _readers = new List<IDataReader<T>>();
        private List<IDataWriter<T>> _writers = new List<IDataWriter<T>>();

        protected DataProvider(ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
        }

        public void RegisterReader(IDataReader<T> reader)
        {
            if (_readers.Contains(reader))
                throw new InvalidOperationException($"Reader is already registered {nameof(reader)}");

            _readers.Add(reader);
        }

        public void RegisterWriter(IDataWriter<T> writer)
        {
            if (_writers.Contains(writer))
                throw new InvalidOperationException($"Writer is already registered {nameof(writer)}");

            _writers.Add(writer);
        }

        public IEnumerator Load()
        {
            bool hasData = false;

            yield return _saveLoadService.HasData<T>(result => hasData = result);

            if (hasData)
                yield return _saveLoadService.Load<T>(data => _data = data);
            else
                _data = GetDefaultData();

            foreach (IDataReader<T> reader in _readers)
                reader.Read(_data);
        }

        public IEnumerator Save()
        {
            foreach (IDataWriter<T> writer in _writers)
                writer.Write(_data);

            yield return _saveLoadService.Save(_data);
        }

        public IEnumerator Reset()
        {
            yield return _saveLoadService.Remove<T>();

            yield return Load();
        }

        protected abstract T GetDefaultData();
    }
}