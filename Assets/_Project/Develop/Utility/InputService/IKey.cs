namespace Assets._Project.Develop.Utility.InputService
{
    public interface IKey
    {
        bool Down { get; }
        bool Pressing { get; }
        bool Up { get; }
    }
}