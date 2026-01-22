using UnityEngine;

namespace Assets._Project.Develop.Configs.Meta
{
    [CreateAssetMenu(fileName = "ResetConfig", menuName = "Scriptable Objects/ResetConfig")]
    public class ResetProgressConfigs : ScriptableObject
    {
        [field: SerializeField, Min(0)] public int CoinsForReset { get; private set; }
    }
}