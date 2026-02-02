using Assets._Project.Develop.Configs.Gameplay;
using Assets._Project.Develop.Gameplay;
using Assets._Project.Develop.Gameplay.Configs.Behavior;
using Assets._Project.Develop.Gameplay.Configs.Difficulty;
using Assets._Project.Develop.Gameplay.Rules;
using Assets._Project.Develop.Gameplay.Screens;
using Assets._Project.Develop.Gameplay.SequenceSymbolsGenerator;
using Assets._Project.Develop.Gameplay.SymbolInputReader;
using Assets._Project.Develop.Infrastructure.DI;
using Assets._Project.Develop.UI.Factories;
using Assets._Project.Develop.UI.MainMenu;
using Assets._Project.Develop.UI.Root;
using Assets._Project.Develop.Utility.ConfigsManagment;
using Assets._Project.Develop.Utility.CoroutinePerformer;
using Assets._Project.Develop.Utility.Counters;
using Assets._Project.Develop.Utility.DataManagment.Providers;
using Assets._Project.Develop.Utility.InputService;
using Assets._Project.Develop.Utility.LoadScreen;
using Assets._Project.Develop.Utility.ResourceLoader;
using Assets._Project.Develop.Utility.SceneManagment;
using Assets._Project.Develop.Utility.SceneManagment.SceneInputArgs;
using Assets._Project.Develop.Utility.Timer;
using Assets._Project.Develop.Utility.WaitScreen;
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
            container.Register(CreateUIRoot).AsSingle().NonLazy();
            container.Register(CreateGameplayPresentersFactory).AsSingle();
            container.Register(CreateGameplayScreen).AsSingle().NonLazy();

            container.Initialize();
        }

        private static GameplayPresenter CreateGameplayScreen(DIContainer container)
        {
            UIRoot uiRoot = container.Resolve<UIRoot>();
            ViewsFactory viewsFactory = container.Resolve<ViewsFactory>();
            GameplayPresentersFactory presentersFactory = container.Resolve<GameplayPresentersFactory>();

            GameplayView view = viewsFactory.Create<GameplayView>(ViewIDs.GameplayView, uiRoot.Hud);
            GameplayPresenter presenter = presentersFactory.CreateGameplayPresenter(view);

            return presenter;
        }

        private static GameplayPresentersFactory CreateGameplayPresentersFactory(DIContainer container)
        {
            return new GameplayPresentersFactory(container);
        }

        private static UIRoot CreateUIRoot(DIContainer container)
        {
            ResourcesLoader resourcesLoader = container.Resolve<ResourcesLoader>();
            UIRoot prefab = resourcesLoader.Load<UIRoot>("UI/Root/UIRoot");

            return GameObject.Instantiate(prefab);
        }

        private static Game CreateGame(DIContainer container)
        {
            ConfigsProvider resourcesLoader = container.Resolve<ConfigsProvider>();
            MoneyOnEndGameConfig moneyOnEndGameConfig = resourcesLoader.GetConfig<MoneyOnEndGameConfig>();

            return new Game(
                container.Resolve<IGameRules>(),
                container.Resolve<WinScreen>(),
                container.Resolve<LoseScreen>(),
                container.Resolve<ICoroutinePerformer>(),
                container.Resolve<LoadSceneService>(),
                container.Resolve<WinLoseCounter>(),
                container.Resolve<WalletService>(),
                container.Resolve<PlayerDataProvider>(),
                moneyOnEndGameConfig,
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
                container.Resolve<SequenceSymbolsGeneratorService>(),
                container.Resolve<ISymbolInputReader>(),
                difficultiesSettings.GetTimeByDifficulty(_inputArgs.Difficulty));
        }

        private static SequenceSymbolsGeneratorService CreateGenerator(DIContainer container)
        {
            ConfigsProvider configsProvider = container.Resolve<ConfigsProvider>();
            SymbolsInBehaviors symbolsInBehaviors = configsProvider.GetConfig<SymbolsInBehaviors>();
            DifficultiesSettings difficultiesSettings = configsProvider.GetConfig<DifficultiesSettings>();

            return new SequenceSymbolsGeneratorService(
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
