using Assets._Project.Develop.UI.Factories;
using Assets._Project.Develop.UI.Popups.ConfirmPopup;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.UI.Popups
{
    public abstract class PopupService : IDisposable
    {
        private readonly ProjectPresentersFactory _projectPresentersFactory;
        private readonly Dictionary<PopupPresenterBase, PopupViewBase> _presenterToView = new();

        protected readonly ViewsFactory ViewsFactory;

        protected PopupService(ProjectPresentersFactory projectPresentersFactory, ViewsFactory viewsFactory)
        {
            _projectPresentersFactory = projectPresentersFactory;
            ViewsFactory = viewsFactory;
        }

        protected abstract Transform PopupLayer { get; }

        public ConfirmPopupPresenter CreateConfirmPopup(string message, Action onConfirm, Action onCancel = null)
        {
            ConfirmPopupView view = ViewsFactory.Create<ConfirmPopupView>(ViewIDs.ConfirmPopup, PopupLayer);

            ConfirmPopupPresenter presenter = _projectPresentersFactory.CreateConfirmPopup(view, message, onConfirm, onCancel);

            OnPopupCreated(presenter, view);

            presenter.Initialize();
            presenter.Show();

            return presenter;
        }

        public void Close(PopupPresenterBase popup)
        {
            popup.CloseRequest -= Close;
            popup.Hide();
            DisposePopup(popup);
            _presenterToView.Remove(popup);
        }

        public void Dispose()
        {
            foreach (PopupPresenterBase popup in _presenterToView.Keys)
            {
                popup.CloseRequest -= Close;
                DisposePopup(popup);
            }

            _presenterToView.Clear();
        }

        protected void OnPopupCreated(PopupPresenterBase popup, PopupViewBase view)
        {
            _presenterToView.Add(popup, view);
            popup.Initialize();
            popup.Show();

            popup.CloseRequest += Close;
        }

        private void DisposePopup(PopupPresenterBase popup)
        {
            popup.Dispose();
            ViewsFactory.Disable(_presenterToView[popup]);
        }
    }
}
