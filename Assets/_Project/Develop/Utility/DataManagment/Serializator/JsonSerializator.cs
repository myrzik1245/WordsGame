using Newtonsoft.Json;

namespace Assets._Project.Develop.Utility.DataManagment.Serializator
{
    public class JsonSerializator : ISerializator
    {
        public T Deserialize<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }

        public string Serialize<T>(T data)
        {
            return JsonConvert.SerializeObject(data);
        }
    }
}