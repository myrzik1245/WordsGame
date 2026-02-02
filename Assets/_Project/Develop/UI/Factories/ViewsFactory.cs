using Assets._Project.Develop.Utility.ResourceLoader;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.UI.Factories
{
    public class ViewsFactory
    {
        private readonly ResourcesLoader _resourcesLoader;

        private readonly Dictionary<string, string> _viewsPaths = new()
        {
            { ViewIDs.Currency, "UI/MainMenu/Wallet/CurrencyView" },
            { ViewIDs.MainMenuView, "UI/MainMenu/MainMenuView" },
            { ViewIDs.GameplayView, "UI/Gameplay/GameplayView" },
            { ViewIDs.ConfirmPopup, "UI/Popups/ConfirmPopup" },
        };

        public ViewsFactory(ResourcesLoader resourcesLoader)
        {
            _resourcesLoader = resourcesLoader;
        }

        public TView Create<TView>(string viewID, Transform parant = null) where TView : MonoBehaviour, IView
        {
            if (_viewsPaths.TryGetValue(viewID, out var path))
            {
                TView prefab = _resourcesLoader.Load<TView>(path);
                TView instance = GameObject.Instantiate(prefab, parant);

                return instance;
            }

            throw new ArgumentException(nameof(viewID));
        }

        public void Disable<TView>(TView view) where TView : MonoBehaviour, IView
        {
            GameObject.Destroy(view.gameObject);
        }
    }
}