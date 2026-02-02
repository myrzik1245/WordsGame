using Assets._Project.Develop.Gameplay.SymbolInputReader;
using Assets._Project.Develop.UI.Common;
using Assets._Project.Develop.UI.Factories;

namespace Assets._Project.Develop.UI.Gameplay
{
    public class InputPresenter : IPresenter
    {
        private readonly ISymbolInputReader _symbolInputReader;
        private readonly TextView _view;

        private string _symbols = string.Empty;

        public InputPresenter(ISymbolInputReader symbolInputReader, TextView view)
        {
            _symbolInputReader = symbolInputReader;
            _view = view;
        }

        public void Initialize()
        {
            _symbolInputReader.CharInputed += OnCharInputed;
            _view.SetText(_symbols);
        }

        public void Dispose()
        {
            _symbolInputReader.CharInputed -= OnCharInputed;
        }

        private void OnCharInputed(char input)
        {
            _symbols += input;

            _view.SetText(_symbols);
        }
    }
}
