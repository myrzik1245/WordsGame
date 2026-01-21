namespace Assets._Project.Develop.Infrastructure.DI
{
    public interface IRegistrationOptions
    {
        IRegistrationOptions AsSingle();
        IRegistrationOptions NonLazy();
    }
}
