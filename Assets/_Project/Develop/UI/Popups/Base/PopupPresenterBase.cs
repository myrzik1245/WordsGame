using Assets._Project.Develop.UI.Factories;
using System;

namespace Assets._Project.Develop.UI.Popups
{
    public abstract class PopupPresenterBase : IPresenter
    {
        public event Action<PopupPresenterBase> CloseRequest;
        protected abstract PopupViewBase View { get; }

        public virtual void Initialize()
        {
        }

        public virtual void Dispose()
        {
            View.CloseRequest -= OnCloseRequest;
        }

        public void Show()
        {
            OnStartShow();
            View.Show();
            OnEndShow();
        }

        public void Hide()
        {
            OnStartHide();
            View.Hide();
            OnEndHide();
        }

        protected virtual void OnStartShow()
        {
            View.CloseRequest += OnCloseRequest;
        }

        protected virtual void OnEndShow()
        {
        }

        protected virtual void OnStartHide()
        {
            View.CloseRequest -= OnCloseRequest;
        }

        protected virtual void OnEndHide()
        {
        }

        protected void OnCloseRequest()
        {
            CloseRequest?.Invoke(this);
        }
    }
}
