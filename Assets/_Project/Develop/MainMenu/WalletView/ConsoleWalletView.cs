using Assets._Project.Develop.Utility.WalletService;
using UnityEngine;

namespace Assets._Project.Develop.MainMenu.WalletView
{
    public class ConsoleWalletView : MonoBehaviour
    {
        private IInputService _inputService;
        private IReadOnlyWallet _wallet;

        public void Initialize(IInputService inputService, IReadOnlyWallet wallet)
        {
            _inputService = inputService;
            _wallet = wallet;
        }

        private void Update()
        {
            if (_inputService.ShowStats.Down)
                Debug.Log($"Coins: {_wallet.GetSlotByType(CurrencyType.Coins).Amount.Value}");
        }
    }
}