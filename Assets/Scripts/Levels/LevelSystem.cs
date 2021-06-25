using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ZombieRun.Levels
{
    using Utils;

    public class LevelSystem : MonoSingleton<LevelSystem>
    {
        [SerializeField] private Transform _root = null;
        [SerializeField] private List<LevelData> _levels = new List<LevelData>();

        public void LoadNextLevel(LevelData data)
        {
            var nextLevel = GetNextLevel();

            var level = Instantiate(nextLevel.prefab, _root.transform);
        }

        public LevelData GetNextLevel()
        {
            if (PlayerPrefs.HasKey("lastLevel"))
                return GetFirstLevel();

            var lastLevelId = PlayerPrefs.GetString("lastLevel");
            var lastLevel = _levels.SingleOrDefault(x => x.id == lastLevelId);
            var nextLevelId = _levels.IndexOf(lastLevel) + 1;

            if (nextLevelId > _levels.Count - 1 || _levels[nextLevelId] == null)
                return GetFirstLevel();

            return _levels[nextLevelId];
        }

        public void SetLastLevelPlayed(LevelData level)
        {
            PlayerPrefs.SetString("lastLevel", level.id);
        }

        private LevelData GetFirstLevel()
        {
            return _levels.FirstOrDefault();
        }
    }
}