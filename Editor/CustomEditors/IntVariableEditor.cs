using ScriptableArchitect.Variables;
using UnityEditor;

[CustomEditor(typeof(IntVariable))]
public class IntVariableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var script = (IntVariable)target;

        if (script.useMinMaxSlider)
        {
            EditorGUI.BeginChangeCheck();
            var newValue = EditorGUILayout.IntSlider("Value", script.Value, script.minValue, script.maxValue);
            if (EditorGUI.EndChangeCheck())
            {
                script.SetValue(newValue);
            }
        }
    }
}
