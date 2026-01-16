using Assets._Project.Develop.Gameplay.Rules;
using System;

public class Game : IDisposable
{
    private Screen _winScreen;
    private Screen _loseScreen;
    private IGameRules _rules;
    private bool _gameEnded = false;

    public Game(IGameRules rules, Screen winScreen, Screen loseScreen)
    {
        _rules = rules;
        _winScreen = winScreen;
        _loseScreen = loseScreen;

        _rules.Win += OnWin;
        _rules.Lose += OnLose;
    }

    public void Dispose()
    {
        _rules.Dispose();

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
}
