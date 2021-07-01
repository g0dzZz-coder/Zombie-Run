using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ZombieRun.Utils
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Returns the closest component to the given position
        /// </summary>
        /// <typeparam name="T">Required component</typeparam>
        /// <param name="enumerable">Collection to search</param>
        /// <param name="position">Position to search</param>
        /// <returns>Closest component</returns>
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

                var distance = (element.transform.position - position).sqrMagnitude;
                if (distance < lastClosestDistance)
                {
                    lastClosestDistance = distance;
                    closest = element;
                }
            }

            return closest;
        }

        /// <summary>
        /// Returns the specified components from the collection.
        /// </summary>
        /// <typeparam name="T">Searched components</typeparam>
        /// <typeparam name="K">Primary components</typeparam>
        /// <param name="enumerable">Collection to search</param>
        /// <returns>List of found components</returns>
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

        /// <summary>
        /// Returns a random item from the collection.
        /// </summary>
        /// <typeparam name="T">Collection type</typeparam>
        /// <param name="array">Collection</param>
        /// <returns>Random element</returns>
        public static T GetRandom<T>(this T[] array)
        {
            return array[Random.Range(0, array.Length)];
        }
    }
}
