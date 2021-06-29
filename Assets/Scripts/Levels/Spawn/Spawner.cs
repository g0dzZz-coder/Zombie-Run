using System.Collections.Generic;
using UnityEngine;

namespace ZombieRun.Entities.Spawn
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab = null;
        [SerializeField] private Transform _root = null;
        [SerializeField] private Transform[] _spawnPositions = null;
        [Range(0, 20)]
        [SerializeField] private int _requiredAmount;

        public GameObject LastSpawned { get; private set; }

        private List<GameObject> _spawnedObjects = new List<GameObject>();
        private int _lastIndex;

        public void Respawn()
        {
            DestroyAll();

            for (_lastIndex = 0; _lastIndex < _requiredAmount; _lastIndex++)
            {
                if (_lastIndex > _spawnPositions.Length - 1)
                    return;

                Spawn();
            }
        }

        protected void Spawn()
        {
            var obj = Instantiate(_prefab, _root);
            obj.transform.position = _spawnPositions[_lastIndex].position;

            LastSpawned = obj;
            _spawnedObjects.Add(LastSpawned);
        }

        protected void DestroyAll()
        {
            foreach (GameObject obj in _spawnedObjects)
                Destroy(obj);

            _lastIndex = 0;
        }
    }
}