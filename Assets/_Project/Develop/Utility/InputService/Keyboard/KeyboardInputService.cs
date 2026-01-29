using UnityEngine;

namespace Assets._Project.Develop.Utility.InputService.KeyboardInputService
{
    public class KeyboardInputService : IInputService
    {
        public KeyboardInputService()
        {
            NextMessage = new KeyboardKey(KeyCode.Space);
            Continue = new KeyboardKey(KeyCode.Space);
            ShowStats = new KeyboardKey(KeyCode.S);
            ResetStats = new KeyboardKey(KeyCode.R);
        }

        public bool AnyKey => Input.anyKey;
        public string InputString => Input.inputString;
        public IKey Continue { get; private set; }
        public IKey NextMessage { get; private set; }
        public IKey ShowStats { get; private set; }
        public IKey ResetStats { get; private set; }
    }
}