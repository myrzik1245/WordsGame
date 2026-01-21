using Assets._Project.Develop.Configs.Meta;
using Assets._Project.Develop.Gameplay.Rules;
using Assets._Project.Develop.Utility.CoroutinePerformer;
using Assets._Project.Develop.Utility.Counters;
using Assets._Project.Develop.Utility.DataManagment.Providers;
using Assets._Project.Develop.Utility.SceneManagment.SceneInputArgs;
using Assets._Project.Develop.Utility.WalletService;
using System;

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
    private WalletConfig _walletConfig;
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
        WalletConfig walletConfig,
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
        _walletConfig = walletConfig;
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
        _walletService.Add(CurrencyType.Coins, _walletConfig.GetValueForWinByType(CurrencyType.Coins));
        _winScreen.Show();
        EndGame();
    }

    private void OnLose()
    {
        if (_gameEnded)
            return;

        CurrencyType currencyType = CurrencyType.Coins;
        int amount = _walletConfig.GetValueForWinByType(currencyType);

        if (_walletService.CanSpend(currencyType, amount))
            _walletService.Spend(currencyType, amount);

        _counter.AddLose();

        _loseScreen.Show();

        EndGame();
    }

    private void EndGame()
    {
        _gameEnded = true;
        _coroutinePerformer.StartPerform(_playerDataProvider.Save());
    }

    private void OnChangeSceneRequested(string sceneName)
    {
        _coroutinePerformer.StartPerform(_loadSceneService.LoadAsync(sceneName, _gameplayInputArgs));
    }
}
