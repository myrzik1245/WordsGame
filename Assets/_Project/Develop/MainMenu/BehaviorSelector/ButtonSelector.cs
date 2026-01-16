using Assets._Project.Develop.Utility.CoroutinePerformer;
using Assets._Project.Develop.Utility.SceneManagment.SceneInputArgs;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSelector : MonoBehaviour
{
    [SerializeField] private Button _letterButton;
    [SerializeField] private Button _numbersButton;

    private LoadSceneService _loadSceneService;
    private ICoroutinePerformer _coroutinePerformer;
    private IDifficultiesSelector _difficultiesSelector;

    public void Initialize(
        LoadSceneService loadSceneService,
        ICoroutinePerformer coroutinePerformer,
        IDifficultiesSelector difficultiesSelector)
    {
        _loadSceneService = loadSceneService;
        _coroutinePerformer = coroutinePerformer;
        _difficultiesSelector = difficultiesSelector;

        _letterButton.onClick.AddListener(SelectLetter);
        _numbersButton.onClick.AddListener(SelectNumbers);
    }

    private void OnDestroy()
    {
        _letterButton.onClick.RemoveListener(SelectLetter);
        _numbersButton.onClick.RemoveListener(SelectNumbers);
    }

    private void SelectLetter()
    {
        _coroutinePerformer.StartPerform(
            _loadSceneService.LoadAsync(
                Scenes.Gameplay,
                new GameplayInputArgs(Behaviors.Letters, _difficultiesSelector.Selected)));
    }

    private void SelectNumbers()
    {
        _coroutinePerformer.StartPerform(
            _loadSceneService.LoadAsync(
                Scenes.Gameplay,
                new GameplayInputArgs(Behaviors.Numbers, _difficultiesSelector.Selected)));
    }
}
