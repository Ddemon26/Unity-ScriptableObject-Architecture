using ScriptableArchitect.Variables;
using UnityEditor;

[CustomEditor(typeof(FloatVariable))]
public class FloatVariableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var script = (FloatVariable)target;

        if (script.useMinMaxSlider)
        {
            EditorGUI.BeginChangeCheck();
            var newValue = EditorGUILayout.Slider("Value", script.value, script.minValue, script.maxValue);
            if (EditorGUI.EndChangeCheck())
            {
                script.SetValue(newValue);
            }
        }
    }
}
