using Assets._Project.Develop.Utility.InputService;
using Assets._Project.Develop.Utility.SceneManagment;
using System;

namespace Assets._Project.Develop.Gameplay.Screens
{
    public class LoseScreen : Screen
    {
        public override event Action<string> ChangeSceneReauested;

        private IInputService _inputService;

        public void Initialize(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Update()
        {
            if (_inputService.Continue.Down)
                ChangeSceneReauested?.Invoke(Scenes.Gameplay);
        }
    }
}