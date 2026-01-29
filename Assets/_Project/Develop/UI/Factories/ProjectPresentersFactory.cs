using Assets._Project.Develop.UI.Popups;
using Assets._Project.Develop.UI.Popups.ConfirmPopup;
using System;

namespace Assets._Project.Develop.UI.Factories
{
    public class ProjectPresentersFactory
    {
        public ProjectPresentersFactory()
        {
        }

        public ConfirmPopupPresenter CreateConfirmPopup(
            ConfirmPopupView view,
            string message,
            Action onConfirm,
            Action onCancel)
        {
            return new ConfirmPopupPresenter(
                view,
                message,
                onConfirm,
                onCancel);
        }
    }
}
