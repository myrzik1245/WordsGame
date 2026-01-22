using Assets._Project.Develop.Data;
using System;
using System.Collections;

namespace Assets._Project.Develop.Utility.DataManagment.SaveLoadService
{
    public interface ISaveLoadService
    {
        IEnumerator LoadAsync<T>(Action<T> onCompleate) where T : ISaveData;
        IEnumerator SaveAsync<T>(T data, Action onCompleate = null) where T : ISaveData;
        IEnumerator HasDataAsync<T>(Action<bool> onCompleate) where T : ISaveData;
        IEnumerator RemoveAsync<T>(Action onCompleate = null) where T : ISaveData;
    }
}
