using Assets._Project.Develop.Infrastructure.DI;
using Assets._Project.Develop.Infrastructure.Registration;
using Assets._Project.Develop.Utility.SceneManagment.SceneInputArgs;
using System.Collections;
using System;
using Assets._Project.Develop.Gameplay.Rules;

namespace Assets._Project.Develop.Infrastructure.EntryPoint
{
    public class GameplayEntryPoint : SceneEntryPoint
    {
        private DIContainer _container;
        private Game _game;

        public override IEnumerator Initialize(DIContainer container, IInputSceneArgs inputSceneArgs)
        {
            _container = container;

            if (inputSceneArgs is not GameplayInputArgs gameplaySceneArgs)
                throw new ArgumentException($"{nameof(gameplaySceneArgs)} is not {typeof(GameplayInputArgs)}");

            GameplayRegistrations.Register(_container, gameplaySceneArgs);

            _game = new Game(
                container.Resolve<IGameRules>(),
                container.Resolve<WinScreen>(),
                container.Resolve<LoseScreen>());

            yield break;
        }

        public override IEnumerator Run()
        {
            IWaitScreen waitScreen = _container.Resolve<IWaitScreen>();

            yield return waitScreen.Wait();

            _game.Start();
        }

        private void OnDestroy()
        {
            _game.Dispose();
        }
    }
}
