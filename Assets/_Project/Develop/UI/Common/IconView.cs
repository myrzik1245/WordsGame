using Assets._Project.Develop.UI.Factories;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Project.Develop.UI.Common
{
    public class IconView : MonoBehaviour, IView
    {
        [SerializeField] private Image _image;

        public void SetSprite(Sprite sprite)
        {
            _image.sprite = sprite;
        }
    }
}