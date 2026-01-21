using Assets._Project.Develop.Gameplay.Rules;
using Assets._Project.Develop.Infrastructure.DI;
using Assets._Project.Develop.Utility.CoroutinePerformer;
using Assets._Project.Develop.Utility.Counters;
using Assets._Project.Develop.Utility.DataManagment.Providers;
using Assets._Project.Develop.Utility.ResourceLoader;
using Assets._Project.Develop.Utility.SceneManagment.SceneInputArgs;
using Assets._Project.Develop.Utility.WalletService;
using UnityEngine;

namespace Assets._Project.Develop.Infrastructure.Registration
{
    public class GameplayRegistrations
    {
        private static GameplayInputArgs _inputArgs;

        public static void Register(DIContainer container, GameplayInputArgs inputArgs)
        {
            _inputArgs = inputArgs;

            container.Register(CreateGame).AsSingle();
            container.Register(CreateLoseScreen).AsSingle();
            container.Register(CreateWinScreen).AsSingle();
            container.Register(CreateSymbolInputReader).AsSingle();
            container.Register(CreateGameRules).AsSingle();
            container.Register(CreateWaitScreen).AsSingle();
            container.Register(CreateGenerator).AsSingle();

            container.CreateNonLaziesRegistrations();
        }

        private static Game CreateGame(DIContainer container)
        {
             return new Game(
                container.Resolve<IGameRules>(),
                container.Resolve<WinScreen>(),
                container.Resolve<LoseScreen>(),
                container.Resolve<ICoroutinePerformer>(),
                container.Resolve<LoadSceneService>(),
                container.Resolve<WinLoseCounter>(),
                container.Resolve<WalletService>(),
                container.Resolve<PlayerDataProvider>(),
                _inputArgs);
        }

        private static LoseScreen CreateLoseScreen(DIContainer container)
        {
            ResourcesLoader resourceLoader = container.Resolve<ResourcesLoader>();

            LoseScreen winScreenPrefab = resourceLoader.Load<LoseScreen>("Gameplay/Screens/LoseScreen");
            LoseScreen instance = GameObject.Instantiate(winScreenPrefab);

            instance.Initialize(
                container.Resolve<IInputService>());

            return instance;
        }

        private static WinScreen CreateWinScreen(DIContainer container)
        {
            ResourcesLoader resourceLoader = container.Resolve<ResourcesLoader>();

            WinScreen winScreenPrefab = resourceLoader.Load<WinScreen>("Gameplay/Screens/WinScreen");
            WinScreen instance = GameObject.Instantiate(winScreenPrefab);

            instance.Initialize(
                container.Resolve<IInputService>());

            return instance;
        }

        private static ISymbolInputReader CreateSymbolInputReader(DIContainer container)
        {
            ResourcesLoader resourceLoader = container.Resolve<ResourcesLoader>();

            SymbolInputReader inputReaderPrefab = resourceLoader.Load<SymbolInputReader>("Gameplay/InputReader");
            SymbolInputReader instance = GameObject.Instantiate(inputReaderPrefab);

            instance.Initialize(
                container.Resolve<IInputService>());

            return instance;
        }

        private static IGameRules CreateGameRules(DIContainer container)
        {
            ConfigsProvider configsProvider = container.Resolve<ConfigsProvider>();
            DifficultiesSettings difficultiesSettings = configsProvider.GetConfig<DifficultiesSettings>();

            return new GameRules(
                container.Resolve<ITimer>(),
                container.Resolve<SequenceSymbolsGenerator>(),
                container.Resolve<ISymbolInputReader>(),
                difficultiesSettings.GetTimeByDifficulty(_inputArgs.Difficulty));
        }

        private static SequenceSymbolsGenerator CreateGenerator(DIContainer container)
        {
            ConfigsProvider configsProvider = container.Resolve<ConfigsProvider>();
            SymbolsInBehaviors symbolsInBehaviors = configsProvider.GetConfig<SymbolsInBehaviors>();
            DifficultiesSettings difficultiesSettings = configsProvider.GetConfig<DifficultiesSettings>();

            return new SequenceSymbolsGenerator(
                symbolsInBehaviors.GetSymbolsByBehavior(_inputArgs.Behavior),
                difficultiesSettings.GetSymbolsCountByDifficulty(_inputArgs.Difficulty));
        }

        private static IWaitScreen CreateWaitScreen(DIContainer container)
        {
            ResourcesLoader resourceLoader = container.Resolve<ResourcesLoader>();

            StandartWaitScreen waitScreenPrefab = resourceLoader.Load<StandartWaitScreen>("Utility/WaitScreen");
            StandartWaitScreen instance = GameObject.Instantiate(waitScreenPrefab);

            instance.Initialize(
                container.Resolve<IInputService>(),
                container.Resolve<ILoadScreen>());

            return instance;
        }
    }
}
