using System.Collections;
using UnityEngine;

namespace ZombieRun.Utils
{
    public class DistanceComparer : IComparer
    {
        private Transform _compareTransform;

        public DistanceComparer(Transform compareTransform)
        {
            _compareTransform = compareTransform;
        }

        public int Compare(object x, object y)
        {
            var xCollider = x as Collider;
            var yCollider = y as Collider;

            var offset = xCollider.transform.position - _compareTransform.position;
            var xDistance = offset.sqrMagnitude;

            offset = yCollider.transform.position - _compareTransform.position;
            var yDistance = offset.sqrMagnitude;

            return xDistance.CompareTo(yDistance);
        }
    }
}