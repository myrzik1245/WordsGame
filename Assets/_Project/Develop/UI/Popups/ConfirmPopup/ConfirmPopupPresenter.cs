using System;

namespace Assets._Project.Develop.UI.Popups.ConfirmPopup
{
    public class ConfirmPopupPresenter
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

        public void Enable()
        {
            _view.Canceled += _onCancel;
            _view.Confirmed += _onConfirm;
            _view.SetMessage(_message);
        }

        public void Disable()
        {
            _view.Canceled -= _onCancel;
            _view.Confirmed -= _onConfirm;
            _view.SetMessage(_message);
        }
    }
}