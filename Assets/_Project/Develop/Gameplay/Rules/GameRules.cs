using Assets._Project.Develop.Gameplay.SequenceSymbolsGenerator;
using Assets._Project.Develop.Gameplay.SymbolInputReader;
using Assets._Project.Develop.Utility.Reactive;
using Assets._Project.Develop.Utility.Timer;
using System;

namespace Assets._Project.Develop.Gameplay.Rules
{
    public class GameRules : IGameRules
    {
        public event Action Win;
        public event Action Lose;

        private ITimer _timer;
        private SequenceSymbolsGeneratorService _symbolsGenerator;
        private ISymbolInputReader _inputReader;

        private ReactiveVariable<string> _generatedMessage = new ReactiveVariable<string>(string.Empty);

        private int _index = 0;
        private bool _isActive = false;

        public GameRules(
            ITimer timer,
            SequenceSymbolsGeneratorService symbolsGenerator,
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

        public IReadOnlyReactiveVariable<string> GeneratedMessage => _generatedMessage;

        public void Start()
        {
            _timer.Start();

            _generatedMessage.Value = _symbolsGenerator.Generate();

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

            if (_index >= _generatedMessage.Value.Length)
                return;

            if (inputSymbol == _generatedMessage.Value[_index])
            {
                _index++;

                if (_index >= _generatedMessage.Value.Length)
                    Win?.Invoke();
            }
            else
            {
                Lose?.Invoke();
            }
        }
    }
}