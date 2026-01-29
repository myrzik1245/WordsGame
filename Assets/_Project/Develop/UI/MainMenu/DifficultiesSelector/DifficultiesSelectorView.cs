using Assets._Project.Develop.Gameplay.Configs.Difficulty;
using Assets._Project.Develop.UI.Factories;
using System;
using UnityEngine;

namespace Assets._Project.Develop.UI.DifficultiesSelector
{
    public class DifficultiesSelectorView : MonoBehaviour, IView
    {
        public event Action<Difficulties> DifficuiesSelected;

        public void SelectEasy()
        {
            DifficuiesSelected?.Invoke(Difficulties.Easy);
        }

        public void SelectNormal()
        {
            DifficuiesSelected?.Invoke(Difficulties.Normal);
        }

        public void SelectHard()
        {
            DifficuiesSelected?.Invoke(Difficulties.Hard);
        }
    }
}
