
public interface IInputService
{
    string InputString { get; }
    IKey NextMessage { get; }
    IKey Continue { get; }
    bool AnyKey { get; }
}
