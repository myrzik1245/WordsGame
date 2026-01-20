using System;
using System.Collections;
using UnityEngine;

namespace Assets._Project.Develop.Utility.DataManagment.Storage
{
    public class PlayerPrefsDataStorage : IDataStorage
    {
        public IEnumerator HasData(string key, Action<bool> onComplete)
        {
            onComplete?.Invoke(PlayerPrefs.HasKey(key));

            yield break;
        }

        public IEnumerator Load(string key, Action<string> onComplete)
        {
            onComplete?.Invoke(PlayerPrefs.GetString(key));

            yield break;
        }

        public IEnumerator Remove(string key, Action onComplete = null)
        {
            PlayerPrefs.DeleteKey(key);
            onComplete?.Invoke();

            yield break;
        }

        public IEnumerator Save(string key, string data, Action onCompleate = null)
        {
            PlayerPrefs.SetString(key, data);
            PlayerPrefs.Save();

            yield break;
        }
    }
}