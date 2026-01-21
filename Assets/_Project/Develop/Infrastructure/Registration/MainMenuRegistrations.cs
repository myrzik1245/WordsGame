using Assets._Project.Develop.Infrastructure.DI;
using Assets._Project.Develop.MainMenu.WalletView;
using Assets._Project.Develop.MainMenu.WinLoseCounterView;
using Assets._Project.Develop.Utility.Counters;
using Assets._Project.Develop.Utility.ResourceLoader;
using Assets._Project.Develop.Utility.WalletService;
using UnityEngine;

namespace Assets._Project.Develop.Infrastructure.Registration
{
    public class MainMenuRegistrations
    {
        public static void Register(DIContainer container)
        {
            container.Register(CreateConsoleWalletView).AsSingle().NonLazy();
            container.Register(CreateConsoleWinLoseCounterView).AsSingle().NonLazy();
            container.Register(CreateDifficultiesSelector).AsSingle();
        }

        private static ConsoleWalletView CreateConsoleWalletView (DIContainer container)
        {
            ResourcesLoader resourcesLoader = container.Resolve<ResourcesLoader>();

            ConsoleWalletView prefab 
                = resourcesLoader.Load<ConsoleWalletView>("MainMenu/WalletView");

            ConsoleWalletView instance = GameObject.Instantiate(prefab);

            instance.Initialize(
                container.Resolve<IInputService>(),
                container.Resolve<WalletService>());

            return instance;
        }

        private static ConsoleWinLoseCounterView CreateConsoleWinLoseCounterView(DIContainer container)
        {
            ResourcesLoader resourcesLoader = container.Resolve<ResourcesLoader>();

            ConsoleWinLoseCounterView prefab 
                = resourcesLoader.Load<ConsoleWinLoseCounterView>("MainMenu/WinLoseCounterView");

            ConsoleWinLoseCounterView instance = GameObject.Instantiate(prefab);

            instance.Initialize(
                container.Resolve<IInputService>(),
                container.Resolve<WinLoseCounter>());

            return instance;
        }

        private static IDifficultiesSelector CreateDifficultiesSelector(DIContainer container)
        {
            ResourcesLoader resourceLoader = container.Resolve<ResourcesLoader>();
            ButtonDifficultiesSelector winScreenPrefab = 
                resourceLoader.Load<ButtonDifficultiesSelector>("MainMenu/ButtonDifficultiesSelector");

            return GameObject.Instantiate(winScreenPrefab);
        }
    }
}
