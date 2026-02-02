using Assets._Project.Develop.UI.Factories;
using System;
using UnityEngine;

namespace Assets._Project.Develop.UI.Popups
{
    public class PopupViewBase : MonoBehaviour, IPopupView
    {
        public event Action CloseRequest;

        [SerializeField] private CanvasGroup _canvasGroup;

        public void Show()
        {
            OnStartShow();
            _canvasGroup.alpha = 1;
            OnEndShow();
        }

        public void Hide()
        {
            OnStartHide();
            _canvasGroup.alpha = 0;
            OnEndHide();
        }

        public void OnCloseButtonClicked()
        {
            CloseRequest?.Invoke();
        }

        protected virtual void OnStartShow()
        {
        }

        protected virtual void OnEndShow()
        {
        }

        protected virtual void OnStartHide()
        {
        }

        protected virtual void OnEndHide()
        {
        }
    }
}
