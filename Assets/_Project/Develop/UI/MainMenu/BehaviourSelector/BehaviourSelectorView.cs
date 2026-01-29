using Assets._Project.Develop.Gameplay.Configs.Behavior;
using Assets._Project.Develop.UI.Factories;
using System;
using UnityEngine;

namespace Assets._Project.Develop.UI.BehaviourSelector
{
    public class BehaviourSelectorView : MonoBehaviour, IView
    {
        public event Action<Behaviors> BehaviorSelected;

        public void SelectLetters()
        {
            BehaviorSelected?.Invoke(Behaviors.Letters);
        }

        public void SelectNumbers()
        {
            BehaviorSelected?.Invoke(Behaviors.Numbers);
        }
    }
}