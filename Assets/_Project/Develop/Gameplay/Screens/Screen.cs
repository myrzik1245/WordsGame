using System;
using UnityEngine;

namespace Assets._Project.Develop.Gameplay.Screens
{
    public abstract class Screen : MonoBehaviour
    {
        public abstract event Action<string> ChangeSceneReauested;

        private void Awake()
        {
            Hide();
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}