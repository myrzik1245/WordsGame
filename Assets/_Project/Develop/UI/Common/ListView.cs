using Assets._Project.Develop.UI.Factories;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.UI.Common
{
    public class ListView<TView> : MonoBehaviour where TView : MonoBehaviour, IView
    {
        [SerializeField] private Transform _parant;

        private List<TView> _elements = new();

        public void Add(TView viewElement)
        {
            viewElement.transform.SetParent(_parant);
            _elements.Add(viewElement);
        }

        public void Remove(TView viewElement)
        {
            viewElement.transform.SetParent(null);
            _elements.Remove(viewElement);
        }
    }
}
