using UnityEngine;

namespace Assets._Project.Develop.Utility.ResourceLoader
{
    public class ResourcesLoader
    {
        public T Load<T>(string path) where T : Object
        {
            return Resources.Load<T>(path);
        }
    }
}
