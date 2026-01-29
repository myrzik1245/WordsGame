namespace Assets._Project.Develop.Utility.Timer
{
    public interface ITimer : IReadOnlyTimer
    {
        public void SetTime(float time);
        public void Start();
        public void Stop();
        public void Restart();
    }
}