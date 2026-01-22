using Assets._Project.Develop.Data.Meta.Player;
using Assets._Project.Develop.Infrastructure.DI;
using Assets._Project.Develop.Infrastructure.Registration;
using Assets._Project.Develop.Utility.CoroutinePerformer;
using Assets._Project.Develop.Utility.DataManagment.Providers;
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

            yield return configsProvider.LoadAsync();

            container.CreateNonLaziesRegistrations();

            LoadSceneService loadSceneService = container.Resolve<LoadSceneService>();
            PlayerDataProvider playerDataProvider = container.Resolve<PlayerDataProvider>();

            yield return new WaitForSeconds(2);
            yield return playerDataProvider.LoadAsync();
            yield return loadSceneService.LoadAsync(Scenes.MainMenu);

            loadScreen.Hide();
        }
    }
}