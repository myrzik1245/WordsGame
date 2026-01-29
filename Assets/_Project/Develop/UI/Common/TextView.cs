using Assets._Project.Develop.UI.Factories;
using TMPro;
using UnityEngine;

namespace Assets._Project.Develop.UI.Common
{
    public class TextView : MonoBehaviour, IView
    {
        [SerializeField] private TMP_Text _text;

        public void SetText(string text)
        {
            _text.text = text;
        }
    }
}