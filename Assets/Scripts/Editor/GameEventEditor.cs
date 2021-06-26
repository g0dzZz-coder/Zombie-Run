using UnityEditor;
using UnityEngine;

namespace ZombieRun.Editor
{
    using Misc;
    using Editor = UnityEditor.Editor;

    [CustomEditor(typeof(GameEvent))]
    public class GameEventEditor : Editor
    {

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            var gameEvent = target as GameEvent;

            if (GUILayout.Button("Raise"))
            {
                gameEvent.Invoke();
            }
        }
    }
}