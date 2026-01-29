using UnityEngine;

namespace Assets._Project.Develop.Utility.InputService.KeyboardInputService
{
    public class KeyboardKey : IKey
    {
        private KeyCode _keyCode;

        public KeyboardKey(KeyCode keyCode)
        {
            _keyCode = keyCode;
        }

        public bool Down => Input.GetKeyDown(_keyCode);
        public bool Pressing => Input.GetKey(_keyCode);
        public bool Up => Input.GetKeyUp(_keyCode);
    }
}