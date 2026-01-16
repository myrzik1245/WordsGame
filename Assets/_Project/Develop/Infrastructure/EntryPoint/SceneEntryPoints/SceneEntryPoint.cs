using Assets._Project.Develop.Infrastructure.DI;
using Assets._Project.Develop.Utility.SceneManagment.SceneInputArgs;
using System.Collections;
using UnityEngine;

namespace Assets._Project.Develop.Infrastructure.EntryPoint
{
    public abstract class SceneEntryPoint : MonoBehaviour
    {
        public abstract IEnumerator Initialize(DIContainer container, IInputSceneArgs inputSceneArgs = null);
        public abstract IEnumerator Run();
    }
}
