using Assets._Project.Develop.UI.Factories;
using Assets._Project.Develop.Utility.Counters;

namespace Assets._Project.Develop.UI.CounterView
{
    public class WinLoseCounterPresenter : IPresenter
    {
        private readonly WinLoseCounter _winLoseCounter;
        private readonly WinLoseCounterView _view;

        public WinLoseCounterPresenter(WinLoseCounter winLoseCounter, WinLoseCounterView view)
        {
            _winLoseCounter = winLoseCounter;
            _view = view;
        }

        public void Initialize()
        {
            _view.SetWin(_winLoseCounter.WinCount.Value);
            _view.SetLose(_winLoseCounter.LoseCount.Value);

            _winLoseCounter.WinCount.Changed += _view.SetWin;
            _winLoseCounter.LoseCount.Changed += _view.SetLose;
        }

        public void Dispose()
        {
            _winLoseCounter.WinCount.Changed -= _view.SetWin;
            _winLoseCounter.LoseCount.Changed -= _view.SetLose;
        }
    }
}
