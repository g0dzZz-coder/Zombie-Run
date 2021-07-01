using System.Collections.Generic;
using UnityEngine;

namespace ZombieRun.Entities.Spawn
{
    using Utils;

    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] _prefabs = null;
        [SerializeField] private Transform _root = null;
        [SerializeField] private Transform _rootOfSpawnPositions = null;
        [Range(0, 50)]
        [SerializeField] private int _requiredAmount;

        public GameObject LastSpawned { get; private set; }
        public Transform RootOfSpawnPositions => _rootOfSpawnPositions;

        private List<GameObject> _spawnedObjects = new List<GameObject>();
        private Transform[] _spawnPositions = null;
        private int _lastIndex;

        public void Respawn()
        {
            DestroyAll();
            FindSpawnPositions();

            for (_lastIndex = 0; _lastIndex < _requiredAmount; _lastIndex++)
            {
                if (_lastIndex > _spawnPositions.Length - 1)
                    return;

                Spawn();
            }
        }

        private void Spawn()
        {
            var obj = Instantiate(_prefabs.GetRandom(), _root);
            obj.transform.position = _spawnPositions[_lastIndex].position;

            LastSpawned = obj;
            _spawnedObjects.Add(LastSpawned);
        }

        private void DestroyAll()
        {
            if (Application.isPlaying == false)
                return;

            foreach (GameObject obj in _spawnedObjects)
                Destroy(obj);

            _lastIndex = 0;
        }

        private void FindSpawnPositions()
        {
            _spawnPositions = new Transform[_rootOfSpawnPositions.childCount];
            for (var i = 0; i < _spawnPositions.Length; i++)
            {
                _spawnPositions[i] = _rootOfSpawnPositions.GetChild(i);
            }
        }
    }
}