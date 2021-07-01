using System.Collections.Generic;
using UnityEngine;

namespace ZombieRun.Entities.Spawn
{
    using Utils;

    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] _prefabs = null;
        [SerializeField] private Transform _root = null;
        [SerializeField] private Transform _rootOfSpawnPoints = null;
        [Range(0, 50)]
        [SerializeField] private int _maxAmount = 30;

        public GameObject LastSpawned { get; private set; }
        public Transform RootOfSpawnPositions => _rootOfSpawnPoints;

        private List<GameObject> _spawnedObjects = new List<GameObject>();
        private Transform[] _spawnPoints = null;

        public void Respawn()
        {
            DestroyAll();
            FindSpawnPositions();

            for (var i = 0; i < _maxAmount; i++)
            {
                if (i > _spawnPoints.Length - 1)
                    return;

                Spawn(_spawnPoints[i]);
            }
        }

        private void Spawn(Transform spawnPoint)
        {
            var obj = Instantiate(_prefabs.GetRandom(), spawnPoint.position, spawnPoint.rotation, _root);

            LastSpawned = obj;
            _spawnedObjects.Add(LastSpawned);
        }

        private void DestroyAll()
        {
            if (Application.isPlaying == false)
                return;

            foreach (GameObject obj in _spawnedObjects)
                Destroy(obj);
        }

        private void FindSpawnPositions()
        {
            _spawnPoints = new Transform[_rootOfSpawnPoints.childCount];
            for (var i = 0; i < _spawnPoints.Length; i++)
            {
                _spawnPoints[i] = _rootOfSpawnPoints.GetChild(i);
            }
        }
    }
}