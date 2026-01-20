using System;

public class WinScreen : Screen
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
            ChangeSceneReauested?.Invoke(Scenes.MainMenu);
    }
}
