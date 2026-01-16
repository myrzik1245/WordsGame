using Assets._Project.Develop.Utility.CoroutinePerformer;
using Assets._Project.Develop.Utility.SceneManagment.SceneInputArgs;

public class LoseScreen : Screen
{
    private IInputService _inputService;
    private ICoroutinePerformer _coroutinePerformer;
    private LoadSceneService _loadSceneService;
    private GameplayInputArgs _gameplayInputArgs;

    public void Initialize(
        IInputService inputService,
        ICoroutinePerformer coroutinePerformer,
        LoadSceneService loadSceneService,
        GameplayInputArgs gameplayInputArgs)
    {
        _inputService = inputService;
        _coroutinePerformer = coroutinePerformer;
        _loadSceneService = loadSceneService;
        _gameplayInputArgs = gameplayInputArgs;
    }

    private void Update()
    {
        if (_inputService.Continue.Down)
            _coroutinePerformer.StartPerform(_loadSceneService.LoadAsync(Scenes.Gameplay, _gameplayInputArgs));
    }
}
