using Assets._Project.Develop.Infrastructure.DI;
using Assets._Project.Develop.Infrastructure.Registration;
using Assets._Project.Develop.Utility.CoroutinePerformer;
using System.Collections;
using UnityEngine;

namespace Assets._Project.Develop.Infrastructure.EntryPoint
{
    public class EntryPoint : MonoBehaviour
    {
        private void Awake()
        {
            DIContainer projectContainer = new DIContainer();

            ProjectRegistrations.Register(projectContainer);

            projectContainer.Resolve<ICoroutinePerformer>().StartPerform(Initialize(projectContainer));
        }

        private IEnumerator Initialize(DIContainer container)
        {
            ILoadScreen loadScreen = container.Resolve<ILoadScreen>();

            loadScreen.Show();

            ConfigsProvider configsProvider = container.Resolve<ConfigsProvider>();
            LoadSceneService loadSceneService = container.Resolve<LoadSceneService>();
            
            yield return new WaitForSeconds(2);
            yield return configsProvider.LoadAsync();
            yield return loadSceneService.LoadAsync(Scenes.MainMenu);

            loadScreen.Hide();
        }
    }
}