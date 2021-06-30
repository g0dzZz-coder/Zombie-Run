using UnityEngine;

namespace ZombieRun.Misc
{
    [CreateAssetMenu(fileName = "Effect", menuName = "Misc/Effect")]
    public class Effect : ScriptableObject
    {
        public GameObject prefab = null;
        public float lifeTime = 2f;
    }
}