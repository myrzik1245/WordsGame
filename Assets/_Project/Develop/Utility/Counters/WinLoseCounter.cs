using Assets._Project.Develop.Data.Meta.Player;
using Assets._Project.Develop.Utility.DataManagment;
using Assets._Project.Develop.Utility.DataManagment.Providers;
using Assets._Project.Develop.Utility.Reactive;

namespace Assets._Project.Develop.Utility.Counters
{
    public class WinLoseCounter : IDataWriter<PlayerData>, IDataReader<PlayerData>
    {
        private Counter _winCounter = new Counter();
        private Counter _loseCounter = new Counter();

        public WinLoseCounter(PlayerDataProvider playerDataProvider)
        {
            playerDataProvider.RegisterWriter(this);
            playerDataProvider.RegisterReader(this);
        }

        public IReadOnlyReactiveVariable<int> WinCount => _winCounter.Count;
        public IReadOnlyReactiveVariable<int> LoseCount => _loseCounter.Count;

        public void AddWin()
        {
            _winCounter.Add();
        }

        public void AddLose()
        {
            _loseCounter.Add();
        }

        public void Write(PlayerData saveData)
        {
            saveData.WinCounter = _winCounter.Count.Value;
            saveData.LoseCounter = _loseCounter.Count.Value;
        }

        public void Read(PlayerData saveData)
        {
            _winCounter.SetCount(saveData.WinCounter);
            _loseCounter.SetCount(saveData.LoseCounter);
        }
    }
}