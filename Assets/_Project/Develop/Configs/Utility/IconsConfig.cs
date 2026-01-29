using Assets._Project.Develop.Utility.WalletService;
using System;
using System.Linq;
using UnityEngine;

namespace Assets._Project.Develop.Configs.Utility
{
    [CreateAssetMenu(fileName = "IconsConfig", menuName = "Scriptable Objects/IconsConfig")]
    public class IconsConfig : ScriptableObject
    {
        [SerializeField] private CurrencyIcon[] _currencyIcons;

        public Sprite GetCurrencySpriteByType(CurrencyType currencyType)
        {
            return _currencyIcons.First(item => item.Type == currencyType).Icon;
        }

        [Serializable]
        private class CurrencyIcon
        {
            [field: SerializeField] public CurrencyType Type { get; private set; }
            [field: SerializeField] public Sprite Icon { get; private set; }
        }
    }
}