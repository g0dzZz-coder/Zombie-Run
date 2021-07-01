using UnityEngine;

namespace ZombieRun.Levels
{
    [CreateAssetMenu(fileName = "Level", menuName = "Settings/Level", order = 51)]
    public class LevelData : ScriptableObject
    {
        [SerializeField] private string _id = string.Empty;
        [SerializeField] private string _name = string.Empty;
        public Level prefab = null;

        public string Id => _id;
        public string Name => _name;
    }
}