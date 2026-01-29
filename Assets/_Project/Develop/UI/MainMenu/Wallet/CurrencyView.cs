using Assets._Project.Develop.UI.Common;
using Assets._Project.Develop.UI.Factories;
using UnityEngine;

namespace Assets._Project.Develop.UI.Wallet
{
    public class CurrencyView : MonoBehaviour, IView
    {
        [SerializeField] private IconView _iconView;
        [SerializeField] private TextView _textView;

        public void SetIcon(Sprite icon)
        {
            _iconView.SetSprite(icon);
        }

        public void SetText(string text)
        {
            _textView.SetText(text);
        }
    }
}