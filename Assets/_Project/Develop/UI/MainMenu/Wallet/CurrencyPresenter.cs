using Assets._Project.Develop.Configs.Utility;
using Assets._Project.Develop.UI.Factories;
using Assets._Project.Develop.Utility.WalletService;
using UnityEngine;

namespace Assets._Project.Develop.UI.Wallet
{
    public class CurrencyPresenter : IPresenter
    {
        private readonly CurrencyView _currencyView;
        private readonly IconsConfig _iconsConfig;
        private readonly IReadOnlySlot _walletSlot;

        public CurrencyPresenter(CurrencyView currencyView, IconsConfig iconsConfig, IReadOnlySlot walletSlot)
        {
            _currencyView = currencyView;
            _iconsConfig = iconsConfig;
            _walletSlot = walletSlot;
        }

        public void Initialize()
        {
            UpdateAmount(_walletSlot.Amount.Value);

            _walletSlot.Amount.Changed += UpdateAmount;

            _currencyView.SetIcon(_iconsConfig.GetCurrencySpriteByType(_walletSlot.Type));
        }

        public void Dispose()
        {
            _walletSlot.Amount.Changed -= UpdateAmount;
            Debug.Log("Dispose");
        }

        private void UpdateAmount(int amount)
        {
            Debug.Log($"UpdateAmount {amount}");

            _currencyView.SetText(amount.ToString());
        }
    }
}
