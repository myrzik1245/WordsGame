using Assets._Project.Develop.Configs.Meta;
using Assets._Project.Develop.Utility.CoroutinePerformer;
using Assets._Project.Develop.Utility.DataManagment.Providers;
using Assets._Project.Develop.Utility.UpdateService;
using Assets._Project.Develop.Utility.WalletService;

namespace Assets._Project.Develop.MainMenu.ResetProgress
{
    public class ResetProgressService : IUpdatable
    {
        private WalletService _walletService;
        private IInputService _inputService;
        private PlayerDataProvider _playerDataProvider;
        private ICoroutinePerformer _coroutinePerformer;
        private ResetProgressConfigs _resetProgressConfigs;

        public ResetProgressService(
            WalletService walletService,
            IInputService inputService,
            PlayerDataProvider playerDataProvider,
            ICoroutinePerformer coroutinePerformer,
            ResetProgressConfigs resetProgressConfigs)
        {
            _walletService = walletService;
            _inputService = inputService;
            _playerDataProvider = playerDataProvider;
            _coroutinePerformer = coroutinePerformer;
            _resetProgressConfigs = resetProgressConfigs;
        }

        public void Update(float deltaTime)
        {
            if (_inputService.ResetStats.Down)
            {
                int spendAmount = _resetProgressConfigs.CoinsForReset;

                if (_walletService.CanSpend(CurrencyType.Coins, spendAmount))
                {
                    _walletService.Spend(CurrencyType.Coins, spendAmount);
                    _coroutinePerformer.StartPerform(_playerDataProvider.ResetAsync());
                }
            }
        }
    }
}