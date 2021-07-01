using UnityEngine;

namespace ZombieRun.Utils
{
    public static class LayerMaskExtensions
    {
        public static bool IsInLayerMask(this LayerMask mask, GameObject obj)
        {
            return (mask.value & (1 << obj.layer)) > 0;
        }
    }
}