using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ZombieRun.Levels
{
    [CreateAssetMenu(fileName = "LevelGroup", menuName = "Settings/LevelGroup", order = 51)]
    public class LevelGroup : ScriptableObject
    {
        [SerializeField] private List<LevelData> _levels = new List<LevelData>();

        public LevelData GetNextLevel()
        {
            if (PlayerPrefs.HasKey("lastLevel") == false)
                return GetFirstLevel();

            var lastLevelId = PlayerPrefs.GetString("lastLevel");
            var lastLevel = _levels.SingleOrDefault(x => x.Id == lastLevelId);
            var nextLevelId = _levels.IndexOf(lastLevel) + 1;

            if (nextLevelId > _levels.Count - 1 || _levels[nextLevelId] == null)
                return GetFirstLevel();

            return _levels[nextLevelId];
        }

        public void SetLastLevelPlayed(LevelData level)
        {
            PlayerPrefs.SetString("lastLevel", level.Id);
        }

        private LevelData GetFirstLevel()
        {
            return _levels.FirstOrDefault();
        }
    }
}