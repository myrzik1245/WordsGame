using Assets._Project.Develop.Gameplay.Rules;
using Assets._Project.Develop.Gameplay.SymbolInputReader;
using Assets._Project.Develop.Infrastructure.DI;
using Assets._Project.Develop.UI.Common;
using Assets._Project.Develop.UI.Gameplay;
using Assets._Project.Develop.UI.MainMenu;

namespace Assets._Project.Develop.UI.Factories
{
    public class GameplayPresentersFactory
    {
        private readonly DIContainer _container;

        public GameplayPresentersFactory(DIContainer container)
        {
            _container = container;
        }

        public InputPresenter CreateInputPresenter(TextView view)
        {
            return new InputPresenter(
                _container.Resolve<ISymbolInputReader>(),
                view);
        }

        public GameplayPresenter CreateGameplayPresenter(GameplayView view)
        {
            return new GameplayPresenter(
                view,
                _container.Resolve<GameplayPresentersFactory>());
        }

        public GenerateMessagePresenter CreateGenerateMessagePresenter(TextView view)
        {
            return new GenerateMessagePresenter(
                view,
                _container.Resolve<IGameRules>());
        }
    }
}
