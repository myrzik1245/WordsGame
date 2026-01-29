using Assets._Project.Develop.UI.Factories;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Project.Develop.UI.MainMenu
{
    public class ResetProgressView : MonoBehaviour, IView
    {
        public event Action ResetButtonClicked;

        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _price;

        public void ResetButton()
        {
            ResetButtonClicked?.Invoke();
        }

        public void SetPrice(int price)
        {
            _price.text = price.ToString();
        }

        public void Unlock()
        {
            _button.interactable = true;
        }
    }
}