namespace Assets._Project.Develop.Utility.WalletService
{
    public interface IReadOnlyWallet
    {
        IReadOnlySlot GetSlotByType(CurrencyType type);
        IReadOnlySlot[] GetSlots();
    }
}
