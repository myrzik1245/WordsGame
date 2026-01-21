namespace Assets._Project.Develop.Utility.WalletService
{
    public interface IReadOnlySlot
    {
        public CurrencyType Type { get; }
        public IReadOnlyReactiveVariable<int> Amount { get; }
    }
}
