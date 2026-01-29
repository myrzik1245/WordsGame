using Assets._Project.Develop.Infrastructure.DI;
using Assets._Project.Develop.Infrastructure.Registration;
using Assets._Project.Develop.Utility.SceneManagment.SceneInputArgs;
using System.Collections;

namespace Assets._Project.Develop.Infrastructure.EntryPoint.SceneEntryPoints
{
    public class MainMenuEntryPoint : SceneEntryPoint
    {
        public override IEnumerator Initialize(DIContainer container, IInputSceneArgs inputSceneArgs)
        {
            MainMenuRegistrations.Register(container);

            yield break;
        }

        public override IEnumerator Run()
        {
            yield break;
        }
    }
}
