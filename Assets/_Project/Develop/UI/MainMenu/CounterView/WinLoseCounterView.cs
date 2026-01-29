using Assets._Project.Develop.UI.Common;
using Assets._Project.Develop.UI.Factories;
using UnityEngine;

namespace Assets._Project.Develop.UI.CounterView
{
    public class WinLoseCounterView : MonoBehaviour, IView
    {
        [SerializeField] private TextView _winText;
        [SerializeField] private TextView _loseText;

        public void SetWin(int value)
        {
            _winText.SetText(value.ToString());
        }

        public void SetLose(int value)
        {
            _loseText.SetText(value.ToString());
        }
    }
}