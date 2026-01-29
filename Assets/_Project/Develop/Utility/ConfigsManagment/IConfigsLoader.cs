using System;
using System.Collections;

namespace Assets._Project.Develop.Utility.ConfigsManagment
{
    public interface IConfigsLoader
    {
        IEnumerator LoadAsync(Action<Type, object> onLoad);
    }
}