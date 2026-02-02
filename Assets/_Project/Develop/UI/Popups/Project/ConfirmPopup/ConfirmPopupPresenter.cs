using System;

namespace Assets._Project.Develop.UI.Popups.ConfirmPopup
{
    public class ConfirmPopupPresenter : PopupPresenterBase
    {
        private readonly ConfirmPopupView _view;
        private readonly string _message;
        private readonly Action _onConfirm;
        private readonly Action _onCancel;

        public ConfirmPopupPresenter(ConfirmPopupView view, string message, Action onConfirm, Action onCancel)
        {
            _view = view;
            _message = message;
            _onConfirm = onConfirm;
            _onCancel = onCancel;
        }

        public override void Initialize()
        {
            base.Initialize();

            _view.ConfirmedRequest += OnConfirm;
            _view.CloseRequest += OnCancel;
            _view.SetMessage(_message);
        }

        public override void Dispose()
        {
            _view.ConfirmedRequest -= OnConfirm;
            _view.CloseRequest -= OnCancel;
            base.Dispose();
        }

        protected override PopupViewBase View => _view;

        private void OnConfirm()
        {
            _onConfirm?.Invoke();
            OnCloseRequest();
        }
        
        private void OnCancel()
        {
            _onCancel?.Invoke();
            OnCloseRequest();
        }
    }
}