using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombieRun.Misc
{
    [CreateAssetMenu(fileName = "Effect", menuName = "Settings/Effect", order = 51)]
    public class Effect : ScriptableObject
    {
        public ParticleSystem _prefab = null;
    }
}