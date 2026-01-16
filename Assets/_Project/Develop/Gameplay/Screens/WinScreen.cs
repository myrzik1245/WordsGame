using Assets._Project.Develop.Utility.CoroutinePerformer;

public class WinScreen : Screen
{
    private IInputService _inputService;
    private ICoroutinePerformer _coroutinePerformer;
    private LoadSceneService _loadSceneService;

    public void Initialize(
        IInputService inputService,
        ICoroutinePerformer coroutinePerformer,
        LoadSceneService loadSceneService)
    {
        _inputService = inputService;
        _coroutinePerformer = coroutinePerformer;
        _loadSceneService = loadSceneService;
    }

    private void Update()
    {
        if (_inputService.Continue.Down)
            _coroutinePerformer.StartPerform(_loadSceneService.LoadAsync(Scenes.MainMenu));
    }
}
