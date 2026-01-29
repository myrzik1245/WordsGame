using Assets._Project.Develop.UI.BehaviourSelector;
using Assets._Project.Develop.UI.CounterView;
using Assets._Project.Develop.UI.DifficultiesSelector;
using Assets._Project.Develop.UI.Factories;
using Assets._Project.Develop.UI.Wallet;
using System;
using UnityEngine;

namespace Assets._Project.Develop.UI.MainMenu
{
    public class MainMenuView : MonoBehaviour, IView
    {
        public event Action PlayButtonClicked;

        [field: SerializeField] public WalletView Wallet { get; private set; }
        [field: SerializeField] public WinLoseCounterView WinLoseCounter { get; private set; }
        [field: SerializeField] public BehaviourSelectorView BehaviorSelector { get; private set; }
        [field: SerializeField] public DifficultiesSelectorView DifficultiesSelector { get; internal set; }
        [field: SerializeField] public ResetProgressView ProgressReset { get; private set; }

        public void Play()
        {
            PlayButtonClicked?.Invoke();
        }
    }
}
