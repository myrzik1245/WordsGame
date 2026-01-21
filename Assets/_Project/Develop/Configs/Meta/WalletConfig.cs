using Assets._Project.Develop.Utility.WalletService;
using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets._Project.Develop.Configs.Meta
{
    [CreateAssetMenu(fileName = "WalletConfig", menuName = "Scriptable Objects/WalletConfig")]
    public class WalletConfig : ScriptableObject
    {
        [SerializeField] private Currency[] _currencies;

        public int GetStartValueByType(CurrencyType type)
        {
            return _currencies.First(curreency => curreency.Type == type).StartValue;
        }

        public int GetValueForWinByType(CurrencyType type)
        {
            return _currencies.First(curreency => curreency.Type == type).AddForWin;
        }

        public int GetValueForLoseByType(CurrencyType type)
        {
            return _currencies.First(curreency => curreency.Type == type).SpendForLose;
        }

        [Serializable]
        private class Currency
        {
            [field: SerializeField] public CurrencyType Type { get; private set; }
            [field: SerializeField] public int StartValue { get; private set; }
            [field: SerializeField] public int AddForWin { get; private set; }
            [field: SerializeField] public int SpendForLose { get; private set; }
        }
    }
}