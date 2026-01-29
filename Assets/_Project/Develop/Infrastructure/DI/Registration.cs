using System;

namespace Assets._Project.Develop.Infrastructure.DI
{
    public class Registration : IRegistrationOptions
    {
        private Func<DIContainer, object> _creator;
        private object _instance;
        public bool IsAsSingle { get; private set; } = false;
        public bool IsNonLazy { get; private set; } = false;

        public Registration(Func<DIContainer, object> creator)
        {
            _creator = creator;
        }

        public void Initialize()
        {
            if (_instance != null)
                if (_instance is IInitializable initializable)
                    initializable.Initialize();
        }

        public void Dispose()
        {
            if (_instance != null)
                if (_instance is IDisposable disposable)
                    disposable.Dispose();
        }

        public object CreateInstance(DIContainer container)
        {
            if (_instance != null && IsAsSingle)
                return _instance;

            if (_creator == null)
                throw new InvalidOperationException($"Registration don't have creator");

            _instance = _creator.Invoke(container);

            return _instance;
        }

        public IRegistrationOptions NonLazy()
        {
            IsNonLazy = true;

            return this;
        }

        public IRegistrationOptions AsSingle()
        {
            IsAsSingle = true;

            return this;
        }
    }
}