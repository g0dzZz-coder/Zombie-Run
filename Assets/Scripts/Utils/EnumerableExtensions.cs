using System;
using System.Collections.Generic;
using UnityEngine;

namespace ZombieRun.Utils
{
    public static class EnumerableExtensions
    {
        public static T GetClosest<T>(this IEnumerable<T> enumerable, Vector3 position) where T : Component
        {
            if (enumerable == null)
                throw new ArgumentNullException(nameof(enumerable));

            T closest = null;
            var lastClosestDistance = Mathf.Infinity;

            foreach (T element in enumerable)
            {
                if (element == null)
                    continue;

                var distance = Vector3.Distance(element.transform.position, position);
                if (distance < lastClosestDistance)
                {
                    lastClosestDistance = distance;
                    closest = element;
                }
            }

            return closest;
        }
    }
}
