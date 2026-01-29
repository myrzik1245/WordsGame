using System;
using UnityEngine;

namespace Assets._Project.Develop.Utility.Reactive
{
    public class ReactiveVariable<T> : IReadOnlyReactiveVariable<T> where T : IEquatable<T>
    {
        public event Action<T> Changed;

        private T _value;

        public ReactiveVariable(T value = default)
        {
            Value = value;
        }

        public T Value
        {
            get => _value;
            set
            {
                T oldValue = _value;

                _value = value;

                if (_value.Equals(oldValue) == false)
                {
                    Debug.Log($"ReactiveVariable {_value}");
                    Changed?.Invoke(_value);
                }
            }
        }
    }
}