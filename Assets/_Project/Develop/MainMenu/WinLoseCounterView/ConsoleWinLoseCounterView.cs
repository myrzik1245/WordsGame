using Assets._Project.Develop.Utility.Counters;
using UnityEngine;

namespace Assets._Project.Develop.MainMenu.WinLoseCounterView
{
    public class ConsoleWinLoseCounterView : MonoBehaviour
    {
        private IInputService _inputService;
        private WinLoseCounter _winLoseCounter;

        public void Initialize(IInputService inputService, WinLoseCounter winLoseCounter)
        {
            _inputService = inputService;
            _winLoseCounter = winLoseCounter;
        }

        private void Update()
        {
            if (_inputService.ShowStats.Down)
                Debug.Log($"Win|Lose:\n{_winLoseCounter.WinCount}|{_winLoseCounter.LoseCount}");
        }
    }
}
