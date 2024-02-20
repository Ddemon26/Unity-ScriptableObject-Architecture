using ScriptableArchitect.Variables;
using UnityEditor;

[CustomEditor(typeof(FloatVariable))]
public class FloatVariableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        FloatVariable script = (FloatVariable)target;

        if (script.UseMinMaxSlider)
        {
            EditorGUI.BeginChangeCheck();
            var newValue = EditorGUILayout.Slider("Value", script.Value, script.MinValue, script.MaxValue);
            if (EditorGUI.EndChangeCheck())
            {
                script.SetValue(newValue);
            }
        }
    }
}
