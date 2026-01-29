using Assets._Project.Develop.Utility.Reactive;
using System;

namespace Assets._Project.Develop.Utility.Counters
{
    public class Counter
    {
        private ReactiveVariable<int> _count = new ReactiveVariable<int>();
        public IReadOnlyReactiveVariable<int> Count => _count;

        public void Add()
        {
            _count.Value++;
        }

        public void SetCount(int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException();

            _count.Value = count;
        }
    }
}