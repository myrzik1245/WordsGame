using System;
using TMPro;
using UnityEngine;

namespace Assets._Project.Develop.UI.Popups
{
    public class ConfirmPopupView : MonoBehaviour
    {
        public event Action Confirmed;
        public event Action Canceled;

        [SerializeField] private TMP_Text _messageText;

        public void SetMessage(string message)
        {
            _messageText.text = message;
        }

        public void Confirm()
        {
            Confirmed?.Invoke();
        }

        public void Cancel()
        {
            Canceled?.Invoke();
        }
    }
}