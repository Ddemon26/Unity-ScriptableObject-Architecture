using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(ConditionalHideAttribute))]
public class ConditionalHidePropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        ConditionalHideAttribute conditionalHideAttribute = (ConditionalHideAttribute)attribute;
        bool enabled = GetConditionalHideAttributeResult(conditionalHideAttribute, property);

        bool wasEnabled = GUI.enabled;
        GUI.enabled = enabled;
        if (!conditionalHideAttribute.HideInInspector || enabled)
        {
            EditorGUI.PropertyField(position, property, label, true);
        }
        GUI.enabled = wasEnabled;
    }

    private bool GetConditionalHideAttributeResult(ConditionalHideAttribute conditionalHideAttribute, SerializedProperty property)
    {
        bool enabled = true;
        string propertyPath = property.propertyPath; // Gets the full path of the property.
        string conditionPath = propertyPath.Replace(property.name, conditionalHideAttribute.ConditionalSourceField); // Replaces the property name with the conditional source field's name.
        SerializedProperty sourcePropertyValue = property.serializedObject.FindProperty(conditionPath);

        if (sourcePropertyValue != null)
        {
            enabled = sourcePropertyValue.boolValue;
        }
        else
        {
            Debug.LogWarning("Unable to find the property with name: " + conditionalHideAttribute.ConditionalSourceField);
        }
        return enabled;
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        ConditionalHideAttribute conditionalHideAttribute = (ConditionalHideAttribute)attribute;
        bool enabled = GetConditionalHideAttributeResult(conditionalHideAttribute, property);

        if (!conditionalHideAttribute.HideInInspector || enabled)
        {
            return EditorGUI.GetPropertyHeight(property, label);
        }

        // If not drawing the property, return a height of 0.
        return 0;
    }
}