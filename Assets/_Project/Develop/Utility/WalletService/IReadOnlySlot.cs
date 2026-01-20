namespace Assets._Project.Develop.Utility.WalletService
{
    public interface IReadOnlySlot
    {
        public CurrnecyType Type { get; }
        public IReadOnlyReactiveVariable<int> Amount { get; }
    }
}
