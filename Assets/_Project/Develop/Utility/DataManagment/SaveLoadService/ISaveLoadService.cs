using Assets._Project.Develop.Data;
using System;
using System.Collections;

namespace Assets._Project.Develop.Utility.DataManagment.SaveLoadService
{
    public interface ISaveLoadService
    {
        IEnumerator Load<T>(Action<T> onCompleate) where T : ISaveData;
        IEnumerator Save<T>(T data, Action onCompleate = null) where T : ISaveData;
        IEnumerator HasData<T>(Action<bool> onCompleate) where T : ISaveData;
        IEnumerator Remove<T>(Action onCompleate = null) where T : ISaveData;
    }
}
