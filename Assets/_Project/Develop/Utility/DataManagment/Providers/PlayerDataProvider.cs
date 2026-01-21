using Assets._Project.Develop.Data.Meta.Player;
using Assets._Project.Develop.Utility.DataManagment.SaveLoadService;
using Assets._Project.Develop.Utility.WalletService;

namespace Assets._Project.Develop.Utility.DataManagment.Providers
{
    public class PlayerDataProvider : DataProvider<PlayerData>
    {
        public PlayerDataProvider(ISaveLoadService saveLoadService) : base(saveLoadService)
        {
        }

        protected override PlayerData GetDefaultData()
        {
            return new PlayerData()
            {
                WalletData = new()
                {
                    { CurrencyType.Coins, 10 }
                }
            };
        }
    }
}
