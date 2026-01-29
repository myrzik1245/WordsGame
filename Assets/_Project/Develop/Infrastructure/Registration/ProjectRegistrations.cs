using Assets._Project.Develop.Configs.Meta;
using Assets._Project.Develop.Infrastructure.DI;
using Assets._Project.Develop.UI.Factories;
using Assets._Project.Develop.Utility.ConfigsManagment;
using Assets._Project.Develop.Utility.CoroutinePerformer;
using Assets._Project.Develop.Utility.Counters;
using Assets._Project.Develop.Utility.DataManagment.Keys;
using Assets._Project.Develop.Utility.DataManagment.Providers;
using Assets._Project.Develop.Utility.DataManagment.SaveLoadService;
using Assets._Project.Develop.Utility.DataManagment.Serializator;
using Assets._Project.Develop.Utility.DataManagment.Storage;
using Assets._Project.Develop.Utility.InputService;
using Assets._Project.Develop.Utility.InputService.KeyboardInputService;
using Assets._Project.Develop.Utility.LoadScreen;
using Assets._Project.Develop.Utility.ResourceLoader;
using Assets._Project.Develop.Utility.SceneManagment;
using Assets._Project.Develop.Utility.Timer;
using Assets._Project.Develop.Utility.UpdateService;
using Assets._Project.Develop.Utility.WalletService;
using UnityEngine;

namespace Assets._Project.Develop.Infrastructure.Registration
{
    public class ProjectRegistrations
    {
        public static void Register(DIContainer container)
        {
            container.Register(CreateViewsFactory).AsSingle();
            container.Register(CreateProjectPresentersFactory).AsSingle();
            container.Register(CreateUpdateService).AsSingle();
            container.Register(CreateWinLoseCounter).AsSingle().NonLazy();
            container.Register(CreateWalletService).AsSingle().NonLazy();
            container.Register(CreatePlayerDataProvider).AsSingle();
            container.Register(CreateSaveLoadService).AsSingle();
            container.Register(CreateTimer);
            container.Register(CreateConfigProvider).AsSingle();
            container.Register(CreateResourcesConfigsLoader).AsSingle();
            container.Register(CreateInputService).AsSingle();
            container.Register(CreateLoadSceneService).AsSingle();
            container.Register(CreateLoadScreen).AsSingle();
            container.Register(CreateResourceLoader).AsSingle();
            container.Register(CreateCoroutinePerformer).AsSingle();
        }

        private static ProjectPresentersFactory CreateProjectPresentersFactory(DIContainer container)
        {
            return new ProjectPresentersFactory();
        }

        private static ViewsFactory CreateViewsFactory(DIContainer container)
        {
            return new ViewsFactory(
                container.Resolve<ResourcesLoader>());
        }

        private static IUpdateService CreateUpdateService(DIContainer container)
        {
            ResourcesLoader resourceLoader = container.Resolve<ResourcesLoader>();

            UpdateService prefab = resourceLoader.Load<UpdateService>("Utility/UpdateService");
            UpdateService inctance = GameObject.Instantiate(prefab);

            return inctance;
        }

        private static WinLoseCounter CreateWinLoseCounter(DIContainer container)
        {
            return new WinLoseCounter(
                container.Resolve<PlayerDataProvider>());
        }

        private static WalletService CreateWalletService(DIContainer container)
        {
            return new WalletService(
                container.Resolve<PlayerDataProvider>());
        }

        private static PlayerDataProvider CreatePlayerDataProvider(DIContainer container)
        {
            ConfigsProvider configsProvider = container.Resolve<ConfigsProvider>();
            WalletConfig walletConfig = configsProvider.GetConfig<WalletConfig>();

            return new PlayerDataProvider(
                container.Resolve<ISaveLoadService>(),
                walletConfig);
        }

        private static ISaveLoadService CreateSaveLoadService(DIContainer container)
        {
            return new SaveLoadSerivce(
                new JsonSerializator(),
                new DataKeys(),
                new PlayerPrefsDataStorage());
        }

        private static ITimer CreateTimer(DIContainer container)
        {
            return new CoroutineTimer(
                container.Resolve<ICoroutinePerformer>());
        }

        private static ConfigsProvider CreateConfigProvider(DIContainer container)
        {
            return new ConfigsProvider(
                container.Resolve<ResourcesConfigLoader>());
        }

        private static ResourcesConfigLoader CreateResourcesConfigsLoader(DIContainer container)
        {
            return new ResourcesConfigLoader(
                container.Resolve<ResourcesLoader>());
        }

        private static IInputService CreateInputService(DIContainer container)
        {
            return new KeyboardInputService();
        }

        private static LoadSceneService CreateLoadSceneService(DIContainer container)
        {
            return new LoadSceneService(
                container.Resolve<ILoadScreen>(), container);
        }

        private static ILoadScreen CreateLoadScreen(DIContainer container)
        {
            ResourcesLoader resourceLoader = container.Resolve<ResourcesLoader>();

            LoadScreenWithMessage loadScreenPrefab = resourceLoader.Load<LoadScreenWithMessage>("Utility/LoadScreen");
            LoadScreenWithMessage loadScreen = GameObject.Instantiate(loadScreenPrefab);

            loadScreen.Initialize(
                container.Resolve<IInputService>());

            return loadScreen;
        }

        private static ResourcesLoader CreateResourceLoader(DIContainer container)
        {
            return new ResourcesLoader();
        }

        private static ICoroutinePerformer CreateCoroutinePerformer(DIContainer container)
        {
            ResourcesLoader resourceLoader = container.Resolve<ResourcesLoader>();
            CoroutinePerformer coroutinePerformerPrefab = resourceLoader.Load<CoroutinePerformer>("Utility/CorourinePerformer");

            return GameObject.Instantiate(coroutinePerformerPrefab);
        }
    }
}
