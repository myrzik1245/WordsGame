using Assets._Project.Develop.UI.Factories;
using UnityEngine;

namespace Assets._Project.Develop.UI.Popups.Project
{
    public class MainMenuPopupService : PopupService
    {
        public MainMenuPopupService(
            ProjectPresentersFactory projectPresentersFactory,
            ViewsFactory viewsFactory,
            Transform popupLayer) : base(projectPresentersFactory, viewsFactory)
        {
            PopupLayer = popupLayer;
        }

        protected override Transform PopupLayer { get; }
    }
}
