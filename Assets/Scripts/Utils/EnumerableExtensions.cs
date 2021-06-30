using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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

        public static List<T> GetComponents<T, K>(this IEnumerable<K> enumerable) where T : Component where K : Component
        {
            if (enumerable == null)
                throw new ArgumentNullException(nameof(enumerable));

            var result = new List<T>();

            foreach (K element in enumerable)
            {
                if (element == null)
                    continue;

                if (element.TryGetComponent(out T component) == false)
                    continue;

                result.Add(component);
            }

            return result;
        }

        public static T GetRandom<T>(this T[] array)
        {
            return array[Random.Range(0, array.Length)];
        }
    }
}
