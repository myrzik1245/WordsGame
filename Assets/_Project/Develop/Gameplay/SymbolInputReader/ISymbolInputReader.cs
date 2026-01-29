using System;

namespace Assets._Project.Develop.Gameplay.SymbolInputReader
{
    public interface ISymbolInputReader
    {
        event Action<char> CharInputed;
    }
}