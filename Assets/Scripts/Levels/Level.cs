using UnityEngine;

namespace ZombieRun.Levels
{
    public class Level : MonoBehaviour
    {
        public LevelData Data { get; private set; }

        public void Init(LevelData data)
        {
            Data = data;
        }
    }
}