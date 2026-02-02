using System;
using TMPro;
using UnityEngine;

namespace Assets._Project.Develop.UI.Popups
{
    public class ConfirmPopupView : PopupViewBase
    {
        public event Action ConfirmedRequest;

        [SerializeField] private TMP_Text _messageText;

        public void SetMessage(string message)
        {
            _messageText.text = message;
        }

        public void OnConfirmButtonClicked()
        {
            ConfirmedRequest?.Invoke();
        }
    }
}