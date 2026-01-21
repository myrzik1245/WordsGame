using System;

namespace Assets._Project.Develop.Utility.Counters
{
    public class Counter
    {
        public int Count { get; private set; }

        public void Add()
        {
            Count++;
        }

        public void SetCount(int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException();

            Count = count;
        }
    }
}