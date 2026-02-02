using Assets._Project.Develop.Gameplay.Rules;
using Assets._Project.Develop.UI.Common;
using Assets._Project.Develop.UI.Factories;

namespace Assets._Project.Develop.UI.MainMenu
{
    public class GenerateMessagePresenter : IPresenter
    {
        private readonly TextView _view;
        private readonly IGameRules _gameRules;

        public GenerateMessagePresenter(TextView view, IGameRules gameRules)
        {
            _view = view;
            _gameRules = gameRules;
        }

        public void Initialize()
        {
            _view.SetText(_gameRules.GeneratedMessage.Value);

            _gameRules.GeneratedMessage.Changed += OnGeneratedMessageChanged;
        }

        public void Dispose()
        {
            _gameRules.GeneratedMessage.Changed -= OnGeneratedMessageChanged;
        }

        private void OnGeneratedMessageChanged(string message)
        {
            _view.SetText(message);
        }
    }
}
