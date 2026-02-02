using Assets._Project.Develop.Utility.Reactive;
using System;

namespace Assets._Project.Develop.Gameplay.Rules
{
    public interface IGameRules : IDisposable
    {
        event Action Win;
        event Action Lose;

        public IReadOnlyReactiveVariable<string> GeneratedMessage { get; }

        public void Start();
    }
}
