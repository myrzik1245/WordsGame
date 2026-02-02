using Assets._Project.Develop.UI.Factories;
using System.Collections.Generic;

namespace Assets._Project.Develop.UI.MainMenu
{
    public class GameplayPresenter : IPresenter
    {
        private readonly GameplayView _view;
        private readonly List<IPresenter> _presenters = new();
        private readonly GameplayPresentersFactory _presenterFactory;

        public GameplayPresenter(
            GameplayView view,
            GameplayPresentersFactory presenterFactory)
        {
            _view = view;
            _presenterFactory = presenterFactory;
        }

        public void Initialize()
        {
            _presenters.Add(_presenterFactory.CreateGenerateMessagePresenter(_view.GeneratorView));
            _presenters.Add(_presenterFactory.CreateInputPresenter(_view.InputView));

            foreach (IPresenter presenter in _presenters)
                presenter.Initialize();
        }

        public void Dispose()
        {
            foreach (IPresenter presenter in _presenters)
                presenter.Dispose();
        }
    }
}
