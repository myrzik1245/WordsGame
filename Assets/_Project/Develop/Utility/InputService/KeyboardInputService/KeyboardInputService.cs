using UnityEngine;

public class KeyboardInputService : IInputService
{
    public KeyboardInputService()
    {
        NextMessage = new KeyboardKey(KeyCode.Space);
        Continue = new KeyboardKey(KeyCode.Space);
    }
    public bool AnyKey => Input.anyKey;
    public string InputString => Input.inputString;
    public IKey Continue { get; private set; }
    public IKey NextMessage { get; private set; }
}
