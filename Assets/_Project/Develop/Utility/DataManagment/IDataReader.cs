using Assets._Project.Develop.Data;

namespace Assets._Project.Develop.Utility.DataManagment
{
    public interface IDataReader<TSaveData> where TSaveData : ISaveData
    {
        void Read(TSaveData saveData);
    }
}
