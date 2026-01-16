using System;

namespace Assets._Project.Develop.Infrastructure.DI
{
    public class Registration
    {
        private Func<DIContainer, object> _creator;
        private object _instance;
        private bool _asSingle = false;

        public Registration(Func<DIContainer, object> creator)
        {
            _creator = creator;
        }

        public object CreateInstance(DIContainer container)
        {
            if (_instance != null && _asSingle)
                return _instance;

            if (_creator == null)
                throw new InvalidOperationException($"Registration don't have creator");

            _instance = _creator.Invoke(container);

            return _instance;
        }

        public void AsSingle()
        {
            _asSingle = true;
        }
    }
}