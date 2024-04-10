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
    /// <summary>
    /// Custom property drawer for the ConditionalHideAttribute.
    /// </summary>
    /// <remarks>
    /// This class overrides the OnGUI and GetPropertyHeight methods of the PropertyDrawer class.
    /// It uses the ConditionalHideAttribute to determine whether to draw the property and calculate its height.
    /// </remarks>
    [CustomPropertyDrawer(typeof(ConditionalHideAttribute))]
    public class ConditionalHidePropertyDrawer : PropertyDrawer
    {
        /// <summary>
        /// Overrides the OnGUI method for the property drawer.
        /// </summary>
        /// <param name="position">The rectangle (Rect) on the screen to use for the property field.</param>
        /// <param name="property">The SerializedProperty to draw a field for.</param>
        /// <param name="label">The label of this property.</param>
        /// <remarks>
        /// This method retrieves the ConditionalHideAttribute from the property drawer's attribute field.
        /// It then evaluates the condition of the attribute using the DrawerUtilities.EvaluateCondition method.
        /// If the condition is met (i.e., the property should be enabled), it sets the GUI enabled state and draws the property if needed.
        /// The GUI enabled state is set using the DrawerUtilities.SetGuiEnabledState method, which takes a delegate to draw the property if needed.
        /// The property is drawn if needed using the DrawerUtilities.DrawPropertyIfNeeded method.
        /// </remarks>
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var conditionalHideAttribute = GetAttribute();
            // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
            var enabled = DrawerUtilities.EvaluateCondition(conditionalHideAttribute, property);

            DrawerUtilities.SetGuiEnabledState(enabled,
                () => DrawerUtilities.DrawPropertyIfNeeded(position, property, label, conditionalHideAttribute,
                    enabled));
        }

        /// <summary>
        /// Retrieves the ConditionalHideAttribute from the property drawer's attribute field.
        /// </summary>
        /// <returns>A ConditionalHideAttribute representing the attribute of the property drawer.</returns>
        /// <remarks>
        /// This method casts the attribute field of the property drawer to a ConditionalHideAttribute and returns it.
        /// </remarks>
        private ConditionalHideAttribute GetAttribute() => (ConditionalHideAttribute)attribute;

        /// <summary>
        /// Overrides the GetPropertyHeight method for the property drawer.
        /// </summary>
        /// <param name="property">The SerializedProperty to calculate the height for.</param>
        /// <param name="label">The GUIContent representing the label of the property.</param>
        /// <returns>A float representing the height of the property field. If the property is not supposed to be shown in the inspector or is not enabled, it returns 0.</returns>
        /// <remarks>
        /// This method retrieves the ConditionalHideAttribute from the property drawer's attribute field using the GetAttribute method.
        /// It then evaluates the condition of the attribute using the DrawerUtilities.EvaluateCondition method.
        /// If the condition is met (i.e., the property should be enabled), it calculates and returns the property height using the DrawerUtilities.CalculatePropertyHeight method.
        /// </remarks>
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var conditionalHideAttribute = GetAttribute();
            // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
            var enabled = DrawerUtilities.EvaluateCondition(conditionalHideAttribute, property);

            return DrawerUtilities.CalculatePropertyHeight(property, label, conditionalHideAttribute, enabled);
        }
    }
}