using Assets._Project.Develop.Data.Meta.Player;
using Assets._Project.Develop.Utility.DataManagment;
using Assets._Project.Develop.Utility.Reactive;
using System;
using System.Linq;

namespace Assets._Project.Develop.Utility.WalletService
{
    public class Slot : IReadOnlySlot, IDataWriter<PlayerData>, IDataReader<PlayerData>
    {
        private ReactiveVariable<int> _amount;

        public Slot(CurrencyType type)
        {
            Type = type;
            _amount = new ReactiveVariable<int>();
        }

        public CurrencyType Type { get; private set; }
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

        public void Write(PlayerData saveData)
        {
            saveData.WalletData[Type] = _amount.Value;
        }

        public void Read(PlayerData saveData)
        {
            _amount.Value = saveData.WalletData.First(item => item.Key == Type).Value;
        }
    }
}
