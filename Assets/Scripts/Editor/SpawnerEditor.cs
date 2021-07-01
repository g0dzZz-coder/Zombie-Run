using UnityEditor;
using UnityEngine;

namespace ZombieRun.Editor
{
    using Entities.Spawn;
    using Editor = UnityEditor.Editor;

    [CustomEditor(typeof(Spawner))]
    public class SpawnerEditor : Editor
    {
        private Spawner _spawner;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isEditor;

            _spawner = target as Spawner;

            if (GUILayout.Button("Spawn"))
            {
                _spawner.Respawn();
            }

            if (GUILayout.Button("Destroy All"))
            {
                DestroyAll();
            }
        }

        private void DestroyAll()
        {
            for (var i = _spawner.transform.childCount - 1; i >= 0; i--)
            {
                var child = _spawner.transform.GetChild(i);
                if (child == _spawner.RootOfSpawnPositions)
                    continue;

                DestroyImmediate(child.gameObject);
            }
        }
    }
}