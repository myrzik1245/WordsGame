using Assets._Project.Develop.Infrastructure.DI;
using Assets._Project.Develop.Infrastructure.EntryPoint;
using Assets._Project.Develop.Utility.SceneManagment.SceneInputArgs;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneService
{
    private ILoadScreen _loadScreen;
    private DIContainer _projectContainer;

    public LoadSceneService(ILoadScreen loadScreen, DIContainer container)
    {
        _loadScreen = loadScreen;
        _projectContainer = container;
    }

    public IEnumerator LoadAsync(string sceneName, IInputSceneArgs inputSceneArgs = null)
    {
        _loadScreen.Show();

        AsyncOperation loadEmptySceneOperation = SceneManager.LoadSceneAsync(Scenes.Empty);
        AsyncOperation loadTargetSceneOperation = SceneManager.LoadSceneAsync(sceneName);

        yield return new WaitWhile(() => loadEmptySceneOperation.isDone == false);
        yield return new WaitWhile(() => loadTargetSceneOperation.isDone == false);

        SceneEntryPoint sceneEntryPoint = GameObject.FindObjectOfType<SceneEntryPoint>();

        if (sceneEntryPoint == null)
            throw new NullReferenceException($"Scene entry point not found");

        DIContainer sceneContainer = new DIContainer(_projectContainer);

        yield return sceneEntryPoint.Initialize(sceneContainer, inputSceneArgs);

        _loadScreen.Hide();

        yield return sceneEntryPoint.Run();
    }
}
