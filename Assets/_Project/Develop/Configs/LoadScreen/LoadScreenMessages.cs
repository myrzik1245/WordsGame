using UnityEngine;

[CreateAssetMenu(fileName = "LoadScreenMessages", menuName = "Scriptable Objects/LoadScreenMessages")]
public class LoadScreenMessages : ScriptableObject
{
    [SerializeField] private string[] _messages;
    private int _index = 0;

    public string GetNextMessage()
    {
        _index++;

        if (_index >= _messages.Length)
            _index = 0;

        return _messages[_index];
    }
}
