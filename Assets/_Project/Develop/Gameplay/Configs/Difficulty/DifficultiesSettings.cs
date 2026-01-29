using System;
using System.Linq;
using UnityEngine;

namespace Assets._Project.Develop.Gameplay.Configs.Difficulty
{
    [CreateAssetMenu(fileName = "DifficultiesSettings", menuName = "Scriptable Objects/DifficultiesSettings")]
    public class DifficultiesSettings : ScriptableObject
    {
        [SerializeField] private DifficultySettings[] _difficulties;

        public int GetSymbolsCountByDifficulty(Difficulties difficulty)
        {
            return GetSettingsByDifficulty(difficulty).SymbolsCount;
        }

        public float GetTimeByDifficulty(Difficulties difficulty)
        {
            return GetSettingsByDifficulty(difficulty).Time;
        }

        private DifficultySettings GetSettingsByDifficulty(Difficulties difficulty)
        {
            DifficultySettings difficultySettings = _difficulties.FirstOrDefault(item => item.Difficulty == difficulty);

            if (difficultySettings == null)
                throw new NotSupportedException($"{nameof(difficulty)} not supported");

            return difficultySettings;
        }

        [Serializable]
        private class DifficultySettings
        {
            [field: SerializeField] public Difficulties Difficulty { get; private set; }
            [field: SerializeField] public int SymbolsCount { get; private set; }
            [field: SerializeField] public float Time { get; private set; }
        }
    }
}