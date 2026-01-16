using System.Collections;
using UnityEngine;

namespace Assets._Project.Develop.Utility.CoroutinePerformer
{
    public class CoroutinePerformer : MonoBehaviour, ICoroutinePerformer
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public Coroutine StartPerform(IEnumerator coroutine)
        {
            return StartCoroutine(coroutine);
        }

        public void StopPerform(Coroutine coroutine)
        {
            StopCoroutine(coroutine);
        }
    }
}