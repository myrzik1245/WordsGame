using Assets._Project.Develop.Infrastructure.DI;
using Assets._Project.Develop.Utility.ConfigsManagment;
using Assets._Project.Develop.Utility.CoroutinePerformer;
using Assets._Project.Develop.Utility.DataManagment.Keys;
using Assets._Project.Develop.Utility.DataManagment.SaveLoadService;
using Assets._Project.Develop.Utility.DataManagment.Serializator;
using Assets._Project.Develop.Utility.DataManagment.Storage;
using Assets._Project.Develop.Utility.ResourceLoader;
using Assets._Project.Develop.Utility.WalletService;
using UnityEngine;

namespace Assets._Project.Develop.Infrastructure.Registration
{
    public class ProjectRegistrations
    {
        public static void Register(DIContainer container)
        {
            container.Register(CreateWalletService).AsSingle();
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

        private static Wallet CreateWalletService(DIContainer container)
        {
            return new Wallet();
        }

        private static ISaveLoadService CreateSaveLoadService(DIContainer container)
        {
            return new SaveLoadSerivce(
                new JsonUtilitySerializator(),
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

            ConfigsProvider configsProvider = container.Resolve<ConfigsProvider>();

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
