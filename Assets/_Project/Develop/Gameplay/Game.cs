using Assets._Project.Develop.Gameplay.Rules;
using Assets._Project.Develop.Utility.CoroutinePerformer;
using Assets._Project.Develop.Utility.SceneManagment.SceneInputArgs;
using System;

public class Game : IDisposable
{
    private Screen _winScreen;
    private Screen _loseScreen;
    private IGameRules _rules;
    private ICoroutinePerformer _coroutinePerformer;
    private LoadSceneService _loadSceneService;
    private GameplayInputArgs _gameplayInputArgs;
    private bool _gameEnded = false;

    public Game(
        IGameRules rules,
        Screen winScreen,
        Screen loseScreen,
        ICoroutinePerformer coroutinePerformer,
        LoadSceneService loadSceneService,
        GameplayInputArgs gameplayInputArgs)
    {
        _rules = rules;
        _winScreen = winScreen;
        _loseScreen = loseScreen;
        _coroutinePerformer = coroutinePerformer;
        _loadSceneService = loadSceneService;
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

        _winScreen.Show();
        EndGame();
    }

    private void OnLose()
    {
        if (_gameEnded)
            return;

        _loseScreen.Show();
        EndGame();
    }

    private void EndGame()
    {
        _gameEnded = true;
    }

    private void OnChangeSceneRequested(string sceneName)
    {
        _coroutinePerformer.StartPerform(_loadSceneService.LoadAsync(sceneName, _gameplayInputArgs));
    }
}
