using System.Collections;
using UnityEngine;

namespace Assets._Project.Develop.Utility.CoroutinePerformer
{
    public interface ICoroutinePerformer
    {
        Coroutine StartPerform(IEnumerator coroutine);
        void StopPerform(Coroutine coroutine);
    }
}