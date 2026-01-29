using Assets._Project.Develop.Utility.WalletService;
using System;
using System.Linq;
using UnityEngine;

namespace Assets._Project.Develop.Configs.Gameplay
{
    [CreateAssetMenu(fileName = "MoneyOnEndGameConfig", menuName = "Scriptable Objects/MoneyOnEndGameConfig")]
    public class MoneyOnEndGameConfig : ScriptableObject
    {
        [SerializeField] private Currency[] _currencies;

        public int GetValueForWinByType(CurrencyType type)
        {
            return _currencies.First(curreency => curreency.Type == type).AddOnWin;
        }

        public int GetValueForLoseByType(CurrencyType type)
        {
            return _currencies.First(curreency => curreency.Type == type).SpendOnLose;
        }

        [Serializable]
        private class Currency
        {
            [field: SerializeField] public CurrencyType Type { get; private set; }
            [field: SerializeField] public int AddOnWin { get; private set; }
            [field: SerializeField] public int SpendOnLose { get; private set; }
        }
    }
}