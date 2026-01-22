namespace Assets._Project.Develop.Utility.UpdateService
{
    public interface IUpdateService
    {
        void Add(IUpdatable updatable);
        void Remove(IUpdatable updatable);
    }
}