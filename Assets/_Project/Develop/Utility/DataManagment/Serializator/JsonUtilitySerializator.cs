using UnityEngine;

namespace Assets._Project.Develop.Utility.DataManagment.Serializator
{
    public class JsonUtilitySerializator : ISerializator
    {
        public T Deserialize<T>(string data)
        {
            return JsonUtility.FromJson<T>(data);
        }

        public string Serialize<T>(T data)
        {
            return JsonUtility.ToJson(data);
        }
    }
}