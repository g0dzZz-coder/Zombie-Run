using UnityEngine;

namespace ZombieRun.Utils
{
    public static class TransformExtensions
    {
        public static float GetDistanceTo(this Transform source, Transform target)
        {
            return (source.position - target.position).sqrMagnitude;
        }
    }
}