using System.Text;
using UnityEngine;

public class SequenceSymbolsGenerator
{
    private string _symbols;
    private int _count;

    public SequenceSymbolsGenerator(string symbols, int count)
    {
        _symbols = symbols;
        _count = count;
    }

    public string Generate()
    {
        StringBuilder stringBuilder = new StringBuilder();

        for (int i = 0; i < _count; i++)
        {
            int randomIndex = Random.Range(0, _symbols.Length);

            stringBuilder.Append(_symbols[randomIndex]);
        }

        return stringBuilder.ToString();
    }
}
