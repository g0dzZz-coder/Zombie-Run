using UnityEngine;

namespace ZombieRun.Misc
{
    [CreateAssetMenu(fileName = "Effect", menuName = "Misc/Effect")]
    public class Effect : ScriptableObject
    {
        public GameObject prefab = null;

        [Range(0.1f, 10f)]
        public float lifeTime = 2f;
    }
}