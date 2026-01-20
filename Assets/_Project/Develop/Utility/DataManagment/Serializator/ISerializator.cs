namespace Assets._Project.Develop.Utility.DataManagment.Serializator
{
    public interface ISerializator
    {
        string Serialize<T>(T data);
        T Deserialize<T>(string data);
    }
}