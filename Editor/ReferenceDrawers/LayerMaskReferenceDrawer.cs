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

using ScriptableArchitect.Variables;
using UnityEditor;

// ReSharper disable once CheckNamespace
namespace ScriptableArchitect.Editor
{
    /// <summary>
    /// A custom property drawer for LayerMaskReference.
    /// </summary>
    /// <remarks>
    /// This class inherits from the <see cref="ScriptableArchitect.Editor.ReferenceDrawer"/> class and is used to create a custom property drawer for LayerMaskReference.
    /// The [CustomPropertyDrawer(typeof(LayerMaskReference))] attribute indicates that this drawer is used for LayerMaskReference properties.
    /// </remarks>
    /// <seealso cref="ScriptableArchitect.Editor.ReferenceDrawer"/>
    [CustomPropertyDrawer(typeof(LayerMaskReference))]
    public class LayerMaskReferenceDrawer : ReferenceDrawer
    {
    }
}