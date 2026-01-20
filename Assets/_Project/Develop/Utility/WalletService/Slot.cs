using System;

namespace Assets._Project.Develop.Utility.WalletService
{
    public class Slot : IReadOnlySlot
    {
        private ReactiveVariable<int> _amount;

        public Slot(CurrnecyType type, int startAmount)
        {
            _amount = new ReactiveVariable<int>(startAmount);
        }

        public CurrnecyType Type { get; private set; }
        public IReadOnlyReactiveVariable<int> Amount => _amount;

        public void Add(int amount)
        {
            if (amount < 0)
                throw new ArgumentException("Amount to add cannot be negative.", nameof(amount));

            _amount.Value += amount;
        }

        public bool CanSpend(int amount)
        {
            return _amount.Value >= amount;
        }

        public void Spend(int amount)
        {
            if (amount < 0)
                throw new ArgumentException("Amount to spend cannot be negative.", nameof(amount));

            if (CanSpend(amount) == false)
                throw new InvalidOperationException("Insufficient funds to spend the requested amount.");

            _amount.Value -= amount;
        }
    }
}
