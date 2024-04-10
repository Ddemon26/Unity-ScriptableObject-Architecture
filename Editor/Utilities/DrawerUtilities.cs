// ----------------------------------------------------------------------------
// Created by: TentCity Software
// Author: Damon Fedorick
// Date: 01/01/2024
// Version: 1.0.1
// 
// Copyright (c) 2023 TentCity Software. All rights reserved.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
// ----------------------------------------------------------------------------

using UnityEditor;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace ScriptableArchitect.Editor
{
    public static class DrawerUtilities
    {
        /// <summary>
        /// Begins the drawing of a property.
        /// </summary>
        /// <param name="position">The rectangle (Rect) on the screen to use for the property field.</param>
        /// <param name="label">The label of this property.</param>
        /// <param name="property">The SerializedProperty to make a field for.</param>
        /// <returns>A GUIContent representing the label to use for the property field.</returns>
        /// <remarks>
        /// This method is a direct forwarding to EditorGUI's BeginProperty.
        /// </remarks>
        public static GUIContent BeginPropertyDrawing(Rect position, GUIContent label, SerializedProperty property) =>
            EditorGUI.BeginProperty(position, label, property);

        /// <summary>
        /// Adjusts the position for the label.
        /// </summary>
        /// <param name="position">The rectangle (Rect) on the screen to use for the label.</param>
        /// <param name="label">The label of this property.</param>
        /// <returns>A Rect representing the adjusted position for the label.</returns>
        /// <remarks>
        /// This method is a direct forwarding to EditorGUI's PrefixLabel.
        /// </remarks>
        public static Rect AdjustPositionForLabel(Rect position, GUIContent label) =>
            EditorGUI.PrefixLabel(position, label);

        /// <summary>
        /// Adjusts the position for the field.
        /// </summary>
        /// <param name="position">The rectangle (Rect) on the screen to use for the field.</param>
        /// <param name="buttonRect">The rectangle (Rect) representing the button.</param>
        /// <returns>A Rect representing the adjusted position for the field.</returns>
        /// <remarks>
        /// The indent level should be managed by the caller if needed.
        /// </remarks>
        public static Rect AdjustPositionForField(Rect position, Rect buttonRect)
        {
            position.xMin = buttonRect.xMax;
            return position;
        }

        /// <summary>
        /// Draws a property field.
        /// </summary>
        /// <param name="position">The rectangle (Rect) on the screen to use for the property field.</param>
        /// <param name="property">The SerializedProperty to draw a field for.</param>
        /// <remarks>
        /// This method simplifies the process by removing the unnecessary GUIContent.none parameter.
        /// It is a direct forwarding to EditorGUI's PropertyField.
        /// </remarks>
        public static void DrawPropertyField(Rect position, SerializedProperty property) =>
            EditorGUI.PropertyField(position, property, GUIContent.none);

        /// <summary>
        /// Ends the property change check.
        /// </summary>
        /// <param name="property">The SerializedProperty to apply modified properties for.</param>
        /// <remarks>
        /// If there are changes in the EditorGUI, it applies the modified properties to the serialized object.
        /// </remarks>
        public static void EndPropertyChangeCheck(SerializedProperty property)
        {
            if (EditorGUI.EndChangeCheck())
                property.serializedObject.ApplyModifiedProperties();
        }

        /// <summary>
        /// Ends the drawing of a property.
        /// </summary>
        /// <remarks>
        /// This method is a direct forwarding to EditorGUI's EndProperty.
        /// The setting of indentLevel is removed as it should not be the responsibility of EndPropertyDrawing.
        /// </remarks>
        public static void EndPropertyDrawing() =>
            EditorGUI.EndProperty();

        /// <summary>
        /// Evaluates the condition of a ConditionalHideAttribute.
        /// </summary>
        /// <param name="conditionalHideAttribute">The ConditionalHideAttribute to evaluate.</param>
        /// <param name="property">The SerializedProperty to use for the evaluation.</param>
        /// <returns>A boolean representing the result of the evaluation.</returns>
        /// <remarks>
        /// This method simplifies the evaluation process by directly calling the needed method without an intermediate step.
        /// </remarks>
        public static bool EvaluateCondition(ConditionalHideAttribute conditionalHideAttribute,
            SerializedProperty property) =>
            // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
            GetConditionalHideAttributeResult(conditionalHideAttribute, property);

        public static void SetGuiEnabledState(bool enabled, System.Action drawAction)
        {
            var wasEnabled = GUI.enabled;
            GUI.enabled = enabled;
            drawAction.Invoke();
            GUI.enabled = wasEnabled;
        }

        // This method is already streamlined and conditional; no redundancy to remove.
        public static void DrawPropertyIfNeeded(Rect position, SerializedProperty property, GUIContent label,
            ConditionalHideAttribute conditionalHideAttribute, bool enabled)
        {
            if (!conditionalHideAttribute.HideInInspector || enabled)
                EditorGUI.PropertyField(position, property, label, true);
        }

        /// <summary>
        /// Gets the result of the ConditionalHideAttribute evaluation.
        /// </summary>
        /// <param name="conditionalHideAttribute">The ConditionalHideAttribute to evaluate.</param>
        /// <param name="property">The SerializedProperty to use for the evaluation.</param>
        /// <returns>A boolean representing the result of the evaluation.</returns>
        /// <remarks>
        /// This method retrieves the condition path and the source property value, and then evaluates the property visibility.
        /// </remarks>
        private static bool GetConditionalHideAttributeResult(ConditionalHideAttribute conditionalHideAttribute,
            SerializedProperty property)
        {
            var conditionPath = GetConditionPath(property, conditionalHideAttribute);
            var sourcePropertyValue = property.serializedObject.FindProperty(conditionPath);
            // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
            return EvaluatePropertyVisibility(sourcePropertyValue, conditionalHideAttribute);
        }

        /// <summary>
        /// Gets the condition path for the given property and ConditionalHideAttribute.
        /// </summary>
        /// <param name="property">The SerializedProperty to use for the condition path.</param>
        /// <param name="conditionalHideAttribute">The ConditionalHideAttribute to use for the condition path.</param>
        /// <returns>A string representing the condition path.</returns>
        /// <remarks>
        /// This method replaces the property name in the property path with the ConditionalSourceField of the ConditionalHideAttribute.
        /// </remarks>
        private static string GetConditionPath(SerializedProperty property,
            ConditionalHideAttribute conditionalHideAttribute) =>
            property.propertyPath.Replace(property.name, conditionalHideAttribute.ConditionalSourceField);

        /// <summary>
        /// Evaluates the visibility of a property based on the provided SerializedProperty and ConditionalHideAttribute.
        /// </summary>
        /// <param name="sourcePropertyValue">The SerializedProperty to evaluate.</param>
        /// <param name="conditionalHideAttribute">The ConditionalHideAttribute to use for the evaluation.</param>
        /// <returns>A boolean representing the visibility of the property. If the source property is not found, it assumes visibility.</returns>
        /// <remarks>
        /// This method checks if the source property is not null and returns its boolean value. If the source property is null, it logs a warning and returns true.
        /// </remarks>
        private static bool EvaluatePropertyVisibility(SerializedProperty sourcePropertyValue,
            ConditionalHideAttribute conditionalHideAttribute)
        {
            if (sourcePropertyValue != null) return sourcePropertyValue.boolValue;
            // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
            Debug.LogWarning(
                $"Unable to find the property with name: {conditionalHideAttribute.ConditionalSourceField}");
            return true; // Assume visibility if property is not found
        }

        /// <summary>
        /// Calculates the height of a property field.
        /// </summary>
        /// <param name="property">The SerializedProperty to calculate the height for.</param>
        /// <param name="label">The GUIContent representing the label of the property.</param>
        /// <param name="conditionalHideAttribute">The ConditionalHideAttribute to use for the calculation.</param>
        /// <param name="enabled">A boolean representing whether the property is enabled.</param>
        /// <returns>A float representing the height of the property field. If the property is not supposed to be shown in the inspector or is not enabled, it returns 0.</returns>
        /// <remarks>
        /// This method checks if the property is not supposed to be hidden in the inspector or if it is enabled, and then returns the property height. Otherwise, it returns 0.
        /// </remarks>
        public static float CalculatePropertyHeight(SerializedProperty property, GUIContent label,
            ConditionalHideAttribute conditionalHideAttribute, bool enabled)
        {
            return !conditionalHideAttribute.HideInInspector || enabled
                ? EditorGUI.GetPropertyHeight(property, label)
                : 0;
        }
    }
}