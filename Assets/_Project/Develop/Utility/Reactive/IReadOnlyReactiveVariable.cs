using System;

namespace Assets._Project.Develop.Utility.Reactive
{
    public interface IReadOnlyReactiveVariable<T>
    {
        event Action<T> Changed;

        T Value { get; }
    }
}