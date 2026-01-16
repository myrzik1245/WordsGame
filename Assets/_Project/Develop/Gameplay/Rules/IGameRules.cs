using System;

namespace Assets._Project.Develop.Gameplay.Rules
{
    public interface IGameRules : IDisposable
    {
        event Action Win;
        event Action Lose;

        public void Start();
    }
}
