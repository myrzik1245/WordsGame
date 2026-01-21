
public interface IInputService
{
    string InputString { get; }
    IKey NextMessage { get; }
    IKey Continue { get; }
    IKey ShowStats { get; }
    IKey ResetStats { get; }
    bool AnyKey { get; }
}
