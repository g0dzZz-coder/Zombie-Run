using UnityEngine;

namespace ZombieRun.Levels
{
    [CreateAssetMenu(fileName = "Level", menuName = "Settings/Level", order = 51)]
    public class LevelData : ScriptableObject
    {
        public string id = string.Empty;
        public Level prefab = null;
    }
}