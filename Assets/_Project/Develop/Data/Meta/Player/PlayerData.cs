using Assets._Project.Develop.Utility.WalletService;
using System.Collections.Generic;

namespace Assets._Project.Develop.Data.Meta.Player
{
    public class PlayerData : ISaveData
    {
        public Dictionary<CurrencyType, int> WalletData;
        public int WinCounter;
        public int LoseCounter;
    }
}