using Assets._Project.Develop.Data.Meta.Player;
using Assets._Project.Develop.Utility.DataManagment;
using Assets._Project.Develop.Utility.DataManagment.Providers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets._Project.Develop.Utility.WalletService
{
    public class WalletService : IReadOnlyWallet
    {
        private PlayerDataProvider _playerDataProvider;
        private Dictionary<CurrencyType, Slot> _slots = new Dictionary<CurrencyType, Slot>();

        public WalletService(PlayerDataProvider playerDataProvider)
        {
            _playerDataProvider = playerDataProvider;

            foreach (CurrencyType type in Enum.GetValues(typeof(CurrencyType)))
                _slots.Add(type, new Slot(type));

            foreach (Slot slot in _slots.Values)
            {
                _playerDataProvider.RegisterWriter(slot);
                _playerDataProvider.RegisterReader(slot);
            }
        }

        public IReadOnlySlot GetSlotByType(CurrencyType type)
        {
            return GetSlot(type);
        }

        public IReadOnlySlot[] GetSlots()
        {
            return _slots.Values.ToArray();
        }

        public void Add(CurrencyType type, int amount)
        {
            Slot slot = GetSlot(type);

            slot.Add(amount);
        }

        public bool CanSpend(CurrencyType type, int amount)
        {
            Slot slot = GetSlot(type);

            return slot.CanSpend(amount);
        }

        public void Spend(CurrencyType type, int amount)
        {
            Slot slot = GetSlot(type);
            
            if (CanSpend(type, amount) == false)
                throw new InvalidOperationException("Insufficient funds to spend the requested amount.");

            slot.Spend(amount);
        }

        private Slot GetSlot(CurrencyType type)
        {
            return _slots.First(slot => slot.Key == type).Value;
        }
    }
}
