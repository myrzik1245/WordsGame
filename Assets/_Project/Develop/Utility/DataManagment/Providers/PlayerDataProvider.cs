using Assets._Project.Develop.Configs.Meta;
using Assets._Project.Develop.Data.Meta.Player;
using Assets._Project.Develop.Utility.DataManagment.SaveLoadService;
using Assets._Project.Develop.Utility.WalletService;
using System;
using System.Collections.Generic;

namespace Assets._Project.Develop.Utility.DataManagment.Providers
{
    public class PlayerDataProvider : DataProvider<PlayerData>
    {
        private readonly WalletConfig _walletConfig;

        public PlayerDataProvider(ISaveLoadService saveLoadService, WalletConfig walletConfig) : base(saveLoadService)
        {
            _walletConfig = walletConfig;
        }

        protected override PlayerData GetDefaultData()
        {
            return new PlayerData()
            {
                WalletData = InitWalletData()
            };
        }

        private Dictionary<CurrencyType, int> InitWalletData()
        {
            Dictionary<CurrencyType, int> currencies = new Dictionary<CurrencyType, int>();

            foreach (CurrencyType type in Enum.GetValues(typeof(CurrencyType)))
                currencies.Add(type, _walletConfig.GetStartValueByType(type));

            return currencies;
        }
    }
}
