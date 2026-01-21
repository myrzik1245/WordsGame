namespace Assets._Project.Develop.Utility.DataManagment
{
    public interface IDataWriter<T>
    {
        void Write(T saveData);
    }
}
