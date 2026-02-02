using Assets._Project.Develop.Configs.Meta;
using Assets._Project.Develop.Configs.Utility;
using Assets._Project.Develop.Gameplay.Configs.Behavior;
using Assets._Project.Develop.Gameplay.Configs.Difficulty;
using Assets._Project.Develop.Infrastructure.DI;
using Assets._Project.Develop.MainMenu.ResetProgress;
using Assets._Project.Develop.MainMenu.Selectors;
using Assets._Project.Develop.UI.BehaviourSelector;
using Assets._Project.Develop.UI.CounterView;
using Assets._Project.Develop.UI.DifficultiesSelector;
using Assets._Project.Develop.UI.MainMenu;
using Assets._Project.Develop.UI.MainMenu.ResetProgress;
using Assets._Project.Develop.UI.Popups.Project;
using Assets._Project.Develop.UI.Wallet;
using Assets._Project.Develop.Utility.ConfigsManagment;
using Assets._Project.Develop.Utility.CoroutinePerformer;
using Assets._Project.Develop.Utility.Counters;
using Assets._Project.Develop.Utility.SceneManagment;
using Assets._Project.Develop.Utility.WalletService;
using System;

namespace Assets._Project.Develop.UI.Factories
{
    public class MainMenuPresentersFactory
    {
        private readonly DIContainer _container;

        public MainMenuPresentersFactory(DIContainer container)
        {
            _container = container;
        }

        public ResetProgressPresenter CreateResetProgressPresenter(ResetProgressView view)
        {
            return new ResetProgressPresenter(
                view,
                _container.Resolve<ResetProgressService>(),
                _container.Resolve<WalletService>(),
                _container.Resolve<MainMenuPopupService>(),
                _container.Resolve<ConfigsProvider>().GetConfig<ShopConfig>());
        }

        public DifficultiesPresenter CreateDifficultiesPresenter(DifficultiesSelectorView view)
        {
            return new DifficultiesPresenter(
                view,
                _container.Resolve<Selector<Difficulties>>());
        }

        public BehaviourSelectorPresenter CreateBehaviourSelectorPresenter(BehaviourSelectorView view)
        {
            return new BehaviourSelectorPresenter(
                view,
                _container.Resolve<Selector<Behaviors>>());
        }

        public WinLoseCounterPresenter CreateWinLoseCounterPresenter(WinLoseCounterView view)
        {
            return new WinLoseCounterPresenter(
                _container.Resolve<WinLoseCounter>(),
                view);
        }

        public MainMenuPresenter CreateMainMenuPresenter(MainMenuView view)
        {
            return new MainMenuPresenter(
                view,
                _container.Resolve<MainMenuPresentersFactory>(),
                _container.Resolve<ICoroutinePerformer>(),
                _container.Resolve<LoadSceneService>(),
                _container.Resolve<Selector<Behaviors>>(),
                _container.Resolve<Selector<Difficulties>>());
        }

        public WalletPresenter CreateWalletPresenter(WalletView view)
        {
            return new WalletPresenter(
                this,
                _container.Resolve<ViewsFactory>(),
                _container.Resolve<WalletService>(),
                view);
        }

        public CurrencyPresenter CreateCurrencyPresenter(CurrencyView view, IReadOnlySlot slot)
        {
            return new CurrencyPresenter(
                view,
                _container.Resolve<ConfigsProvider>().GetConfig<IconsConfig>(),
                slot);
        }
    }
}
