using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ZombieRun.Levels
{
    using Utils;

    public class LevelSystem : MonoSingleton<LevelSystem>
    {
        [SerializeField] private List<LevelData> levels = new List<LevelData>();

        public void LoadLevel(LevelData data)
        {
            
        }

        public LevelData GetLastPlayedLevel()
        {
            if (PlayerPrefs.HasKey("lastLevel"))
                return null;

            var level = levels.SingleOrDefault(x => x.id == PlayerPrefs.GetString("lastLevel"));

            return level;
        }

        public void SetLastLevelPlayed(LevelData level)
        {
            PlayerPrefs.SetString("lastLevel", level.id);
        }
    }
}