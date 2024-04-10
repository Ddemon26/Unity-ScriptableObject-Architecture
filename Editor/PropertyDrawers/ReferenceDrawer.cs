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
    public class ReferenceDrawer : PropertyDrawer
    {
        /// <summary>
        /// The options for the dropdown in the property drawer.
        /// </summary>
        private readonly string[] popupOptions = { "Use Constant", "Use Variable" };

        /// <summary>
        /// The style for the dropdown in the property drawer.
        /// </summary>
        private GUIStyle popupStyle;

        /// <summary>
        /// Overrides the OnGUI method for the property drawer.
        /// </summary>
        /// <param name="position">The rectangle (Rect) on the screen to use for the property field.</param>
        /// <param name="property">The SerializedProperty to draw a field for.</param>
        /// <param name="label">The label of this property.</param>
        /// <remarks>
        /// This method initializes the popup style, begins the property drawing, adjusts the position for the label,
        /// checks for changes in the EditorGUI, draws the property dropdown and field, applies modified properties if there are changes,
        /// and ends the property drawing.
        /// </remarks>
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EnsurePopupStyleInitialized();
            label = DrawerUtilities.BeginPropertyDrawing(position, label, property);
            position = DrawerUtilities.AdjustPositionForLabel(position, label);

            EditorGUI.BeginChangeCheck();
            DrawPropertyDropdownAndField(position, property);
            if (EditorGUI.EndChangeCheck())
            {
                DrawerUtilities.EndPropertyChangeCheck(property);
            }

            DrawerUtilities.EndPropertyDrawing();
        }

        /// <summary>
        /// Ensures that the popup style is initialized.
        /// </summary>
        /// <remarks>
        /// This method initializes the popup style if it is not already initialized.
        /// The style is set to "PaneOptions" with the image position set to ImageOnly.
        /// </remarks>
        private void EnsurePopupStyleInitialized() => popupStyle ??= new GUIStyle(GUI.skin.GetStyle("PaneOptions"))
            { imagePosition = ImagePosition.ImageOnly };

        /// <summary>
        /// Draws a dropdown and a property field based on the selected option in the dropdown.
        /// </summary>
        /// <param name="position">The rectangle (Rect) on the screen to use for the dropdown and the property field.</param>
        /// <param name="property">The SerializedProperty to draw a field for.</param>
        /// <remarks>
        /// This method retrieves the 'useConstant', 'constantValue', and 'assetVariable' properties from the provided SerializedProperty.
        /// It then creates a dropdown button rect and adjusts the position for the field.
        /// The dropdown is drawn with the 'useConstant' value determining the selected index.
        /// The 'useConstant' value is then updated based on the result of the dropdown.
        /// Finally, a property field is drawn for either the 'constantValue' or 'assetVariable' based on the 'useConstant' value.
        /// </remarks>
        private void DrawPropertyDropdownAndField(Rect position, SerializedProperty property)
        {
            var useConstant = property.FindPropertyRelative("useConstant");
            var constantValue = property.FindPropertyRelative("constantValue");
            var assetVariable = property.FindPropertyRelative("assetVariable");

            var buttonRect = CreateDropdownButtonRect(position);
            position = DrawerUtilities.AdjustPositionForField(position, buttonRect);

            var result = DrawPopup(buttonRect, useConstant.boolValue ? 0 : 1);
            useConstant.boolValue = result == 0;

            DrawerUtilities.DrawPropertyField(position, useConstant.boolValue ? constantValue : assetVariable);
        }

        /// <summary>
        /// Creates a rectangle for the dropdown button.
        /// </summary>
        /// <param name="position">The rectangle (Rect) on the screen to use for the dropdown button.</param>
        /// <returns>A Rect representing the dropdown button.</returns>
        /// <remarks>
        /// This method creates a new rectangle based on the provided position.
        /// It adjusts the minimum y-coordinate and the width of the rectangle based on the popup style.
        /// The minimum x-coordinate of the position is then set to the maximum x-coordinate of the button rectangle.
        /// </remarks>
        private Rect CreateDropdownButtonRect(Rect position)
        {
            var buttonRect = new Rect(position);
            buttonRect.yMin += popupStyle.margin.top;
            buttonRect.width = popupStyle.fixedWidth + popupStyle.margin.right;
            position.xMin = buttonRect.xMax;
            return buttonRect;
        }

        /// <summary>
        /// Draws a popup with the provided button rectangle and selected index.
        /// </summary>
        /// <param name="buttonRect">The rectangle (Rect) on the screen to use for the popup.</param>
        /// <param name="selectedIndex">The index of the selected option in the popup.</param>
        /// <returns>An integer representing the selected index in the popup.</returns>
        /// <remarks>
        /// The method returns the result of drawing a popup with the button rectangle, selected index, popup options, and popup style.
        /// </remarks>
        private int DrawPopup(Rect buttonRect, int selectedIndex) =>
            EditorGUI.Popup(buttonRect, selectedIndex, popupOptions, popupStyle);
    }
}