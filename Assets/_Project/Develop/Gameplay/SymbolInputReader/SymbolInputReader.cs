using Assets._Project.Develop.Utility.InputService;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Gameplay.SymbolInputReader
{
    public class SymbolInputReader : MonoBehaviour, ISymbolInputReader
    {
        public event Action<char> CharInputed;

        private IInputService _inputService;

        public void Initialize(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Update()
        {
            string inputString = _inputService.InputString;

            if (string.IsNullOrEmpty(inputString) == false)
                foreach (char symbol in inputString)
                    CharInputed?.Invoke(symbol);
        }
    }
}