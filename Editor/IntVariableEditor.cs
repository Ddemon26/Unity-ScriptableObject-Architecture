using ScriptableArchitect.Variables;
using UnityEditor;

[CustomEditor(typeof(IntVariable))]
public class IntVariableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        IntVariable script = (IntVariable)target;

        if (script.UseMinMaxSlider)
        {
            EditorGUI.BeginChangeCheck();
            var newValue = EditorGUILayout.IntSlider("Value", script.Value, script.MinValue, script.MaxValue);
            if (EditorGUI.EndChangeCheck())
            {
                script.SetValue(newValue);
            }
        }
    }
}
