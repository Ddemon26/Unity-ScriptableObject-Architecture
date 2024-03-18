using ScriptableArchitect.Events;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EventChannel), true)]
public class EventEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Raise"))
        {
            ((EventChannel)target).Invoke(new Empty());
        }
    }
}