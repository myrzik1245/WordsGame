using Assets._Project.Develop.Infrastructure.DI;
using Assets._Project.Develop.Infrastructure.Registration;
using Assets._Project.Develop.Utility.CoroutinePerformer;
using Assets._Project.Develop.Utility.SceneManagment.SceneInputArgs;
using System.Collections;
using UnityEngine;

namespace Assets._Project.Develop.Infrastructure.EntryPoint.SceneEntryPoints
{
    public class MainMenuEntryPoint : SceneEntryPoint
    {
        [SerializeField] private ButtonSelector _behaviorSelector;

        public override IEnumerator Initialize(DIContainer container, IInputSceneArgs inputSceneArgs)
        {
            MainMenuRegistrations.Register(container);

            _behaviorSelector.Initialize(
                container.Resolve<LoadSceneService>(),
                container.Resolve<ICoroutinePerformer>(),
                container.Resolve<IDifficultiesSelector>());

            yield break;
        }

        public override IEnumerator Run()
        {
            yield break;
        }
    }
}
