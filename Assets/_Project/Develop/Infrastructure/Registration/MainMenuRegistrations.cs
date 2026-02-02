using Assets._Project.Develop.Gameplay.Configs.Behavior;
using Assets._Project.Develop.Gameplay.Configs.Difficulty;
using Assets._Project.Develop.Infrastructure.DI;
using Assets._Project.Develop.MainMenu.ResetProgress;
using Assets._Project.Develop.MainMenu.Selectors;
using Assets._Project.Develop.UI.Factories;
using Assets._Project.Develop.UI.MainMenu;
using Assets._Project.Develop.UI.Popups.Project;
using Assets._Project.Develop.UI.Root;
using Assets._Project.Develop.Utility.CoroutinePerformer;
using Assets._Project.Develop.Utility.DataManagment.Providers;
using Assets._Project.Develop.Utility.ResourceLoader;
using Assets._Project.Develop.Utility.WalletService;
using UnityEngine;

namespace Assets._Project.Develop.Infrastructure.Registration
{
    public class MainMenuRegistrations
    {
        public static void Register(DIContainer container)
        {
            container.Register(CreatePopupService).AsSingle();
            container.Register(CreateResetProgressService).AsSingle();
            container.Register(CreateDifficultiesSelector).AsSingle();
            container.Register(CreateBehavioursSelector).AsSingle();
            container.Register(CreateMainMenuScreenPresenter).AsSingle().NonLazy();
            container.Register(CreateMainMenuPresentersFactory).AsSingle();
            container.Register(CreateUIRoot).AsSingle().NonLazy();

            container.Initialize();
        }

        private static MainMenuPopupService CreatePopupService(DIContainer container)
        {
            return new MainMenuPopupService(
                container.Resolve<ProjectPresentersFactory>(),
                container.Resolve<ViewsFactory>(),
                container.Resolve<UIRoot>().Popups);
        }

        private static ResetProgressService CreateResetProgressService(DIContainer container)
        {
            return new ResetProgressService(
                container.Resolve<WalletService>(),
                container.Resolve<PlayerDataProvider>(),
                container.Resolve<ICoroutinePerformer>());
        }

        private static Selector<Difficulties> CreateDifficultiesSelector(DIContainer container)
        {
            return new Selector<Difficulties>();
        }

        private static Selector<Behaviors> CreateBehavioursSelector(DIContainer container)
        {
            return new Selector<Behaviors>();
        }

        private static MainMenuPresenter CreateMainMenuScreenPresenter(DIContainer container)
        {
            UIRoot uiRoot = container.Resolve<UIRoot>();
            ViewsFactory viewsFactory = container.Resolve<ViewsFactory>();
            MainMenuPresentersFactory presentersFactory = container.Resolve<MainMenuPresentersFactory>();

            MainMenuView view = viewsFactory.Create<MainMenuView>(ViewIDs.MainMenuView, uiRoot.Hud);
            MainMenuPresenter presenter = presentersFactory.CreateMainMenuPresenter(view);

            return presenter;
        }

        private static MainMenuPresentersFactory CreateMainMenuPresentersFactory(DIContainer container)
        {
            return new MainMenuPresentersFactory(container);
        }

        private static UIRoot CreateUIRoot(DIContainer container)
        {
            ResourcesLoader resourcesLoader = container.Resolve<ResourcesLoader>();
            UIRoot prefab = resourcesLoader.Load<UIRoot>("UI/Root/UIRoot");

            return GameObject.Instantiate(prefab);
        }
    }
}
