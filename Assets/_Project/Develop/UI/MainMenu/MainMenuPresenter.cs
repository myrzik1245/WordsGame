using Assets._Project.Develop.Gameplay.Configs.Behavior;
using Assets._Project.Develop.Gameplay.Configs.Difficulty;
using Assets._Project.Develop.MainMenu.Selectors;
using Assets._Project.Develop.UI.Factories;
using Assets._Project.Develop.Utility.CoroutinePerformer;
using Assets._Project.Develop.Utility.SceneManagment;
using Assets._Project.Develop.Utility.SceneManagment.SceneInputArgs;
using System.Collections.Generic;

namespace Assets._Project.Develop.UI.MainMenu
{
    public class MainMenuPresenter : IPresenter
    {
        private readonly MainMenuView _view;
        private readonly MainMenuPresentersFactory _presentersFactory;
        private readonly ICoroutinePerformer _coroutinePerformer;
        private readonly LoadSceneService _loadSceneService;
        private readonly Selector<Behaviors> _behaviourSelector;
        private readonly Selector<Difficulties> _difficultiesSelector;
        
        private readonly List<IPresenter> _presenters = new();

        public MainMenuPresenter(
            MainMenuView view,
            MainMenuPresentersFactory presentersFactory,
            ICoroutinePerformer coroutinePerformer,
            LoadSceneService loadSceneService,
            Selector<Behaviors> behaviourSelector,
            Selector<Difficulties> difficultiesSelector)
        {
            _view = view;
            _presentersFactory = presentersFactory;
            _coroutinePerformer = coroutinePerformer;
            _loadSceneService = loadSceneService;
            _behaviourSelector = behaviourSelector;
            _difficultiesSelector = difficultiesSelector;
        }

        public void Initialize()
        {
            _presenters.Add(_presentersFactory.CreateWalletPresenter(_view.Wallet));
            _presenters.Add(_presentersFactory.CreateWinLoseCounterPresenter(_view.WinLoseCounter));
            _presenters.Add(_presentersFactory.CreateBehaviourSelectorPresenter(_view.BehaviorSelector));
            _presenters.Add(_presentersFactory.CreateDifficultiesPresenter(_view.DifficultiesSelector));
            _presenters.Add(_presentersFactory.CreateResetProgressPresenter(_view.ProgressReset));

            foreach (IPresenter presenter in _presenters)
                presenter.Initialize();

            _view.PlayButtonClicked += OnPlayButtonClicked;
        }

        public void Dispose()
        {
            foreach (IPresenter presenter in _presenters)
                presenter.Dispose();

            _view.PlayButtonClicked -= OnPlayButtonClicked;
        }

        private void OnPlayButtonClicked()
        {
            GameplayInputArgs gameplayInputArgs
                = new GameplayInputArgs(_behaviourSelector.Selected, _difficultiesSelector.Selected);

            _coroutinePerformer.StartPerform(_loadSceneService.LoadAsync(Scenes.Gameplay, gameplayInputArgs));
        }
    }
}
