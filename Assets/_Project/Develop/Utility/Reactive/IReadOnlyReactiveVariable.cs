
using System;

public interface IReadOnlyReactiveVariable<T>
{
    event Action<T> Changed;

    T Value { get; }
}
