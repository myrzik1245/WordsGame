using System;
using System.Collections;

namespace Assets._Project.Develop.Utility.DataManagment.Storage
{
    public interface IDataStorage
    {
        IEnumerator Load(string key, Action<string> onComplete);
        IEnumerator Save(string key, string data, Action onCompleate = null);
        IEnumerator HasData(string key, Action<bool> onComplete);
        IEnumerator Remove(string key, Action onComplete = null);
    }
}