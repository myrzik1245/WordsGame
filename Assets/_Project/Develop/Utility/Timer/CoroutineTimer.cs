using Assets._Project.Develop.Utility.CoroutinePerformer;
using System;
using System.Collections;
using UnityEngine;

namespace Assets._Project.Develop.Utility.Timer
{
    public class CoroutineTimer : ITimer
    {
        public event Action TimeEnded;

        private float _startTime;
        private ICoroutinePerformer _coroutinePerformer;
        private Coroutine _process;

        public CoroutineTimer(ICoroutinePerformer coroutineRunner)
        {
            _coroutinePerformer = coroutineRunner;
        }

        public float TimeValue { get; private set; }

        public void Restart()
        {
            TimeValue = _startTime;

            Start();
        }

        public void Start()
        {
            if (_process == null)
                _process = _coroutinePerformer.StartPerform(TimerProcess());
        }

        public void SetTime(float time)
        {
            if (time <= 0)
                throw new ArgumentOutOfRangeException($"Time <= 0 {nameof(time)}");

            TimeValue = _startTime = time;
        }

        private IEnumerator TimerProcess()
        {
            while (TimeValue >= 0)
            {
                TimeValue -= Time.deltaTime;
                yield return null;
            }

            _process = null;
            TimeEnded?.Invoke();
        }

        public void Stop()
        {
            if (_process != null)
            {
                _coroutinePerformer.StopPerform(_process);
                _process = null;
            }
        }
    }
}