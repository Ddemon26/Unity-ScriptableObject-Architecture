using UnityEditor;
using UnityEngine;

namespace ScriptableArchitect.Variables
{
    public class ReferenceDrawer : PropertyDrawer
    {
        private readonly string[] popupOptions = { "Use Constant", "Use Variable" };
        private GUIStyle popupStyle;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EnsurePopupStyleInitialized();
            label = BeginPropertyDrawing(position, label, property);
            position = AdjustPositionForLabel(position, label);

            if (BeginPropertyChangeCheck())
            {
                DrawPropertyDropdownAndField(position, property);
                EndPropertyChangeCheck(property);
            }

            EndPropertyDrawing();
        }

        private void EnsurePopupStyleInitialized()
        {
            popupStyle ??= new GUIStyle(GUI.skin.GetStyle("PaneOptions")) { imagePosition = ImagePosition.ImageOnly };
        }

        private GUIContent BeginPropertyDrawing(Rect position, GUIContent label, SerializedProperty property)
        {
            return EditorGUI.BeginProperty(position, label, property);
        }

        private Rect AdjustPositionForLabel(Rect position, GUIContent label)
        {
            return EditorGUI.PrefixLabel(position, label);
        }

        private bool BeginPropertyChangeCheck()
        {
            EditorGUI.BeginChangeCheck();
            return true; // Always true, helps to keep structure and allows for future conditions
        }

        private void DrawPropertyDropdownAndField(Rect position, SerializedProperty property)
        {
            var useConstant = property.FindPropertyRelative("useConstant");
            var constantValue = property.FindPropertyRelative("constantValue");
            var assetVariable = property.FindPropertyRelative("assetVariable");

            Rect buttonRect = CreateDropdownButtonRect(position);
            position = AdjustPositionForField(position, buttonRect);

            int result = DrawPopup(buttonRect, useConstant.boolValue ? 0 : 1);
            useConstant.boolValue = result == 0;

            DrawPropertyField(position, useConstant.boolValue ? constantValue : assetVariable);
        }

        private Rect CreateDropdownButtonRect(Rect position)
        {
            var buttonRect = new Rect(position);
            buttonRect.yMin += popupStyle.margin.top;
            buttonRect.width = popupStyle.fixedWidth + popupStyle.margin.right;
            position.xMin = buttonRect.xMax;
            return buttonRect;
        }

        private Rect AdjustPositionForField(Rect position, Rect buttonRect)
        {
            EditorGUI.indentLevel = 0;
            position.xMin = buttonRect.xMax;
            return position;
        }

        private int DrawPopup(Rect buttonRect, int selectedIndex)
        {
            return EditorGUI.Popup(buttonRect, selectedIndex, popupOptions, popupStyle);
        }

        private void DrawPropertyField(Rect position, SerializedProperty property)
        {
            EditorGUI.PropertyField(position, property, GUIContent.none);
        }

        private void EndPropertyChangeCheck(SerializedProperty property)
        {
            if (EditorGUI.EndChangeCheck())
                property.serializedObject.ApplyModifiedProperties();
        }

        private void EndPropertyDrawing()
        {
            EditorGUI.indentLevel = 1; // Reset to default or previous indent level if needed
            EditorGUI.EndProperty();
        }
    }
}
