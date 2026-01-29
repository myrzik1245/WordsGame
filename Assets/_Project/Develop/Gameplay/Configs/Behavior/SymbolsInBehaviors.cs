using System;
using System.Linq;
using UnityEngine;

namespace Assets._Project.Develop.Gameplay.Configs.Behavior
{
    [CreateAssetMenu(fileName = "SymbolsInBehavior", menuName = "Scriptable Objects/SymbolsInBehavior")]
    public class SymbolsInBehaviors : ScriptableObject
    {
        [SerializeField] private SymbolsInBehavior[] _behaviors;

        public string GetSymbolsByBehavior(Behaviors behaviorType)
        {
            SymbolsInBehavior symbolsInBehavior = _behaviors.FirstOrDefault(item => item.Behavior == behaviorType);

            if (symbolsInBehavior == null)
                throw new NotSupportedException($"{nameof(behaviorType)} not supported");

            return symbolsInBehavior.Symbols;
        }

        [Serializable]
        private class SymbolsInBehavior
        {
            [field: SerializeField] public Behaviors Behavior { get; private set; }
            [field: SerializeField] public string Symbols { get; private set; }
        }
    }
}