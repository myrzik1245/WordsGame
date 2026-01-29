using Assets._Project.Develop.Gameplay.Configs.Difficulty;
using Assets._Project.Develop.MainMenu.Selectors;
using Assets._Project.Develop.UI.Factories;

namespace Assets._Project.Develop.UI.DifficultiesSelector
{
    public class DifficultiesPresenter : IPresenter
    {
        private readonly DifficultiesSelectorView _difficultiesSelectorView;
        private readonly Selector<Difficulties> _selector;

        public DifficultiesPresenter(
            DifficultiesSelectorView difficultiesSelectorView,
            Selector<Difficulties> selector)
        {
            _difficultiesSelectorView = difficultiesSelectorView;
            _selector = selector;
        }

        public void Initialize()
        {
            _difficultiesSelectorView.DifficuiesSelected += OnSelect;
        }

        public void Dispose()
        {
            _difficultiesSelectorView.DifficuiesSelected -= OnSelect;
        }

        private void OnSelect(Difficulties difficulties)
        {
            _selector.Select(difficulties);
        }
    }
}
