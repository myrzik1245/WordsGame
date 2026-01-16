using Assets._Project.Develop.Gameplay.Rules;
using System;
using UnityEngine;

public class GameRules : IGameRules
{
    public event Action Win;
    public event Action Lose;

    private ITimer _timer;
    private SequenceSymbolsGenerator _symbolsGenerator;
    private ISymbolInputReader _inputReader;

    private string _generatedMessage;
    private int _index = 0;
    private bool _isActive = false;

    public GameRules(
        ITimer timer,
        SequenceSymbolsGenerator symbolsGenerator,
        ISymbolInputReader inputReader,
        float timeToLose)
    {
        _timer = timer;
        _symbolsGenerator = symbolsGenerator;
        _inputReader = inputReader;

        _inputReader.CharInputed += OnSymbolInputed;
        _timer.TimeEnded += OnTimeEnded;

        _timer.SetTime(timeToLose);
    }

    public void Start()
    {
        _timer.Start();

        _generatedMessage = _symbolsGenerator.Generate();

        Debug.Log(_generatedMessage);

        _isActive = true;
    }

    public void Dispose()
    {
        _timer.TimeEnded -= OnTimeEnded;
        _inputReader.CharInputed -= OnSymbolInputed;
    }

    private void OnTimeEnded()
    {
        Lose?.Invoke();
    }

    private void OnSymbolInputed(char inputSymbol)
    {
        if (_isActive == false)
            return;

        if (_index >= _generatedMessage.Length)
            return;

        if (inputSymbol == _generatedMessage[_index])
        {
            _index++;

            if (_index >= _generatedMessage.Length)
                Win?.Invoke();
        }
        else
        {
            Lose?.Invoke();
        }
    }
}
