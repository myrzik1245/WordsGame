using Assets._Project.Develop.Gameplay.Configs.Behavior;
using Assets._Project.Develop.MainMenu.Selectors;
using Assets._Project.Develop.UI.Factories;

namespace Assets._Project.Develop.UI.BehaviourSelector
{
    public class BehaviourSelectorPresenter : IPresenter
    {
        private readonly BehaviourSelectorView _view;
        private readonly Selector<Behaviors> _selector;

        public BehaviourSelectorPresenter(BehaviourSelectorView view, Selector<Behaviors> selector)
        {
            _view = view;
            _selector = selector;
        }

        public void Initialize()
        {
            _view.BehaviorSelected += OnSelectBehaviour;
        }

        public void Dispose()
        {
            _view.BehaviorSelected -= OnSelectBehaviour;
        }

        private void OnSelectBehaviour(Behaviors behavior)
        {
            _selector.Select(behavior);
        }
    }
}
