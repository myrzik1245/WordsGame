using Assets._Project.Develop.Configs.Gameplay;
using Assets._Project.Develop.Gameplay.Rules;
using Assets._Project.Develop.Gameplay.Screens;
using Assets._Project.Develop.Utility.CoroutinePerformer;
using Assets._Project.Develop.Utility.Counters;
using Assets._Project.Develop.Utility.DataManagment.Providers;
using Assets._Project.Develop.Utility.SceneManagment;
using Assets._Project.Develop.Utility.SceneManagment.SceneInputArgs;
using Assets._Project.Develop.Utility.WalletService;
using System;

namespace Assets._Project.Develop.Gameplay
{
    public class Game : IDisposable
    {
        private Screen _winScreen;
        private Screen _loseScreen;
        private IGameRules _rules;
        private ICoroutinePerformer _coroutinePerformer;
        private LoadSceneService _loadSceneService;
        private GameplayInputArgs _gameplayInputArgs;
        private WinLoseCounter _counter;
        private WalletService _walletService;
        private PlayerDataProvider _playerDataProvider;
        private MoneyOnEndGameConfig _moneyOnEndGameConfig;
        private bool _gameEnded = false;

        public Game(
            IGameRules rules,
            Screen winScreen,
            Screen loseScreen,
            ICoroutinePerformer coroutinePerformer,
            LoadSceneService loadSceneService,
            WinLoseCounter counter,
            WalletService walletService,
            PlayerDataProvider playerDataProvider,
            MoneyOnEndGameConfig moneyOnEndGameConfig,
            GameplayInputArgs gameplayInputArgs)
        {
            _rules = rules;
            _winScreen = winScreen;
            _loseScreen = loseScreen;
            _coroutinePerformer = coroutinePerformer;
            _loadSceneService = loadSceneService;
            _counter = counter;
            _walletService = walletService;
            _playerDataProvider = playerDataProvider;
            _moneyOnEndGameConfig = moneyOnEndGameConfig;
            _gameplayInputArgs = gameplayInputArgs;

            _rules.Win += OnWin;
            _rules.Lose += OnLose;

            _winScreen.ChangeSceneReauested += OnChangeSceneRequested;
            _loseScreen.ChangeSceneReauested += OnChangeSceneRequested;
        }

        public void Dispose()
        {
            _rules.Dispose();

            _winScreen.ChangeSceneReauested -= OnChangeSceneRequested;
            _loseScreen.ChangeSceneReauested -= OnChangeSceneRequested;

            _rules.Win -= OnWin;
            _rules.Lose -= OnLose;
        }

        public void Start()
        {
            _rules.Start();
        }

        private void OnWin()
        {
            if (_gameEnded)
                return;

            _counter.AddWin();
            CurrencyType currencyType = CurrencyType.Coins;
            _walletService.Add(currencyType, _moneyOnEndGameConfig.GetValueForWinByType(currencyType));
            _winScreen.Show();
            EndGame();
        }

        private void OnLose()
        {
            if (_gameEnded)
                return;

            CurrencyType currencyType = CurrencyType.Coins;
            int amount = _moneyOnEndGameConfig.GetValueForLoseByType(currencyType);

            if (_walletService.CanSpend(currencyType, amount))
                _walletService.Spend(currencyType, amount);

            _counter.AddLose();

            _loseScreen.Show();

            EndGame();
        }

        private void EndGame()
        {
            _gameEnded = true;
            _coroutinePerformer.StartPerform(_playerDataProvider.SaveAsync());
        }

        private void OnChangeSceneRequested(string sceneName)
        {
            _coroutinePerformer.StartPerform(_loadSceneService.LoadAsync(sceneName, _gameplayInputArgs));
        }
    }
}