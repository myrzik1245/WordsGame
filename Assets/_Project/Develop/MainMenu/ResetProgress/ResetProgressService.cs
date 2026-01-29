using Assets._Project.Develop.Utility.CoroutinePerformer;
using Assets._Project.Develop.Utility.DataManagment.Providers;
using Assets._Project.Develop.Utility.WalletService;

namespace Assets._Project.Develop.MainMenu.ResetProgress
{
    public class ResetProgressService
    {
        private readonly WalletService _walletService;
        private readonly PlayerDataProvider _playerDataProvider;
        private readonly ICoroutinePerformer _coroutinePerformer;

        public ResetProgressService(
            WalletService walletService,
            PlayerDataProvider playerDataProvider,
            ICoroutinePerformer coroutinePerformer)
        {
            _walletService = walletService;
            _playerDataProvider = playerDataProvider;
            _coroutinePerformer = coroutinePerformer;
        }

        public void Reset()
        {
            _coroutinePerformer.StartPerform(_playerDataProvider.ResetAsync());
        }
    }
}