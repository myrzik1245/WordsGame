using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Utility.UpdateService
{
    public class UpdateService : MonoBehaviour, IUpdateService
    {
        private List<IUpdatable> _updatables = new();

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void Add(IUpdatable updatable)
        {
            if (_updatables.Contains(updatable))
                throw new InvalidOperationException();

            _updatables.Add(updatable);
        }

        public void Remove(IUpdatable updatable)
        {
            if (_updatables.Contains(updatable) == false)
                throw new InvalidOperationException();

            _updatables.Remove(updatable);
        }

        private void Update()
        {
            foreach (IUpdatable updatable in _updatables)
                updatable.Update(Time.deltaTime);
        }
    }
}