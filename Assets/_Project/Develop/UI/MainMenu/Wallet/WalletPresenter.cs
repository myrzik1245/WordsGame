using Assets._Project.Develop.UI.Factories;
using Assets._Project.Develop.Utility.WalletService;
using System.Collections.Generic;

namespace Assets._Project.Develop.UI.Wallet
{
    public class WalletPresenter : IPresenter
    {
        private readonly MainMenuPresentersFactory _mainMenuPresentersFactory;
        private readonly IReadOnlyWallet _wallet;
        private readonly ViewsFactory _viewsFactory;
        private readonly WalletView _view;

        private Dictionary<CurrencyPresenter, CurrencyView> _presentersMap = new();

        public WalletPresenter(
            MainMenuPresentersFactory mainMenuPresentersFactory,
            ViewsFactory viewsFactory,
            IReadOnlyWallet wallet,
            WalletView view)
        {
            _mainMenuPresentersFactory = mainMenuPresentersFactory;
            _wallet = wallet;
            _viewsFactory = viewsFactory;
            _view = view;
        }

        public void Initialize()
        {
            foreach (IReadOnlySlot slot in _wallet.GetSlots())
            {
                CurrencyView currencyView = _viewsFactory.Create<CurrencyView>(ViewIDs.Currency);
                _view.Add(currencyView);

                CurrencyPresenter currencyPresenter
                    = _mainMenuPresentersFactory.CreateCurrencyPresenter(currencyView, slot);

                _presentersMap.Add(currencyPresenter, currencyView);

                currencyPresenter.Initialize();
            }
        }

        public void Dispose()
        {
            foreach (KeyValuePair<CurrencyPresenter, CurrencyView> presentersView in _presentersMap)
            {
                presentersView.Key.Dispose();
                _viewsFactory.Disable(presentersView.Value);
            }
        }
    }
}
