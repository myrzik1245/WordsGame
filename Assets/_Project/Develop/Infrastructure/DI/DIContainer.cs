using System;
using System.Collections.Generic;

namespace Assets._Project.Develop.Infrastructure.DI
{
    public class DIContainer : IDisposable
    {
        private readonly Dictionary<Type, Registration> _container = new();
        private readonly List<Type> _requests = new();
        private readonly DIContainer _parantContainer;

        public DIContainer(DIContainer parantContainer = null)
        {
            _parantContainer = parantContainer;
        }

        public IRegistrationOptions Register<T>(Func<DIContainer, T> creator)
        {
            if (_container.ContainsKey(typeof(T)))
            {
                if (_parantContainer != null && _parantContainer._container.ContainsKey(typeof(T)))

                throw new InvalidOperationException($"container already contains {typeof(T)}");
            }

            Registration registration = new Registration(container => creator.Invoke(container));
            _container.Add(typeof(T), registration);

            return registration;
        }

        public T Resolve<T>()
        {
            if (_requests.Contains(typeof(T)))
                throw new InvalidOperationException($"Cycle resolve {typeof(T)}");

            _requests.Add(typeof(T));

            try
            {
                if (_container.TryGetValue(typeof(T), out Registration registration))
                    return (T)registration.CreateInstance(this);

                if (_parantContainer != null)
                    return _parantContainer.Resolve<T>();
            }
            finally
            {
                _requests.Remove(typeof(T));
            }

            throw new InvalidOperationException($"Registration {typeof(T)} not exists");
        }

        public void Initialize()
        {
            foreach (Registration registration in _container.Values)
            {
                if (registration.IsNonLazy)
                    registration.CreateInstance(this);

                registration.Initialize();
            }
        }

        public void Dispose()
        {
            foreach (Registration registration in _container.Values)
                registration.Dispose();
        }
    }
}