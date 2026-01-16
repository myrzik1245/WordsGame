using System;

public interface ISymbolInputReader
{
    event Action<char> CharInputed;
}
