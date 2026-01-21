using Assets._Project.Develop.Infrastructure.DI;
using Assets._Project.Develop.Infrastructure.Registration;
using Assets._Project.Develop.Utility.CoroutinePerformer;
using Assets._Project.Develop.Utility.Counters;
using Assets._Project.Develop.Utility.SceneManagment.SceneInputArgs;
using Assets._Project.Develop.Utility.WalletService;
using System.Collections;
using UnityEngine;

namespace Assets._Project.Develop.Infrastructure.EntryPoint.SceneEntryPoints
{
    public class MainMenuEntryPoint : SceneEntryPoint
    {
        [SerializeField] private ButtonSelector _behaviorSelector;

        private WalletService _walletService;
        private WinLoseCounter _winLoseCounter;

        public override IEnumerator Initialize(DIContainer container, IInputSceneArgs inputSceneArgs)
        {
            MainMenuRegistrations.Register(container);

            _behaviorSelector.Initialize(
                container.Resolve<LoadSceneService>(),
                container.Resolve<ICoroutinePerformer>(),
                container.Resolve<IDifficultiesSelector>());

            _walletService = container.Resolve<WalletService>();
            _winLoseCounter = container.Resolve<WinLoseCounter>();

            yield break;
        }

        public override IEnumerator Run()
        {
            yield break;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                int coins = _walletService.GetSlotByType(CurrencyType.Coins).Amount.Value;
                int win = _winLoseCounter.WinCount;
                int lose = _winLoseCounter.LoseCount;

                Debug.Log($"Coins: {coins}\nWin|Lose: {win}|{lose}");
            }
        }
    }
}
