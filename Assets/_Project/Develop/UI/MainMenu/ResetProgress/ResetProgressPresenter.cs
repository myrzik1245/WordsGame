using Assets._Project.Develop.Configs.Meta;
using Assets._Project.Develop.MainMenu.ResetProgress;
using Assets._Project.Develop.UI.Factories;
using Assets._Project.Develop.Utility.WalletService;

namespace Assets._Project.Develop.UI.MainMenu.ResetProgress
{
    public class ResetProgressPresenter : IPresenter
    {
        private readonly ResetProgressView _view;
        private readonly ResetProgressService _resetService;
        private readonly WalletService _walletService;
        private readonly ShopConfig _shopConfig;

        public ResetProgressPresenter(
            ResetProgressView view,
            ResetProgressService resetService,
            WalletService walletService,
            ShopConfig shopConfig)
        {
            _view = view;
            _resetService = resetService;
            _walletService = walletService;
            _shopConfig = shopConfig;
        }

        public void Initialize()
        {
            int spendAmount = _shopConfig.CoinsForReset;

            if (_walletService.CanSpend(CurrencyType.Coins, spendAmount))
                _view.Unlock();

            _view.SetPrice(spendAmount);

            _view.ResetButtonClicked += OnResetButtonClicked;
        }

        public void Dispose()
        {
            _view.ResetButtonClicked -= OnResetButtonClicked;
        }

        private void OnResetButtonClicked()
        {
            int spendAmount = _shopConfig.CoinsForReset;

            if (_walletService.CanSpend(CurrencyType.Coins, spendAmount))
            {
                _walletService.Spend(CurrencyType.Coins, spendAmount);
                _resetService.Reset();
            }
        }
    }
}
