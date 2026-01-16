using System;
using UnityEngine;

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
