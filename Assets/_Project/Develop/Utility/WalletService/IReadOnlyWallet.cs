namespace Assets._Project.Develop.Utility.WalletService
{
    public interface IReadOnlyWallet
    {
        IReadOnlySlot GetSlotByType(CurrnecyType type);
    }
}
