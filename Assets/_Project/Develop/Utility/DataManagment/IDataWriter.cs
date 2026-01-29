using Assets._Project.Develop.Data;

namespace Assets._Project.Develop.Utility.DataManagment
{
    public interface IDataWriter<TSaveData> where TSaveData : ISaveData
    {
        void Write(TSaveData saveData);
    }
}
