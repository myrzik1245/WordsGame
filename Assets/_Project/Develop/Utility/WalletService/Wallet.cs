using Assets._Project.Develop.Utility.DataManagment.SaveLoadService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets._Project.Develop.Utility.WalletService
{
    public class Wallet : IReadOnlyWallet
    {
        private Dictionary<CurrnecyType, Slot> _slots = new Dictionary<CurrnecyType, Slot>();

        public Wallet(ISaveLoadService saveLoadSerivce)
        {
            //foreach (CurrnecyType type in Enum.GetValues(typeof(CurrnecyType)))
            //    _slots[type] = new Slot(type, startAmounts[type]);
        }

        public IReadOnlySlot GetSlotByType(CurrnecyType type)
        {
            return GetSlot(type);
        }

        public void Add(CurrnecyType type, int amount)
        {
            Slot slot = GetSlot(type);

            slot.Add(amount);
        }

        public bool CanSpend(CurrnecyType type, int amount)
        {
            Slot slot = GetSlot(type);

            return slot.CanSpend(amount);
        }

        public void Spend(CurrnecyType type, int amount)
        {
            Slot slot = GetSlot(type);
            
            if (CanSpend(type, amount) == false)
                throw new InvalidOperationException("Insufficient funds to spend the requested amount.");

            slot.Spend(amount);
        }

        private Slot GetSlot(CurrnecyType type)
        {
            return _slots.First(slot => slot.Key == type).Value;
        }
    }
}
