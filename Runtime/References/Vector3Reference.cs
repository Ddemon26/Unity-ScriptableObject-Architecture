﻿// ----------------------------------------------------------------------------
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

using UnityEngine;

// ReSharper disable once CheckNamespace
namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// Represents a reference to a Vector3 value, which can be stored in a Vector3Variable asset.
    /// </summary>
    [System.Serializable]
    public class Vector3Reference : ValueReference<Vector3, Vector3Variable>
    {
        /// <summary>
        /// Default constructor for Vector3Reference.
        /// </summary>
        public Vector3Reference()
        {
        }

        /// <summary>
        /// Constructor that sets the constant Vector3 value.
        /// </summary>
        /// <param name="value">The constant Vector3 value to set.</param>
        /// <remarks>
        /// This constructor allows you to create a new instance of <see cref="Vector3Reference"/> with a specific value.
        /// </remarks>
        public Vector3Reference(Vector3 value) : base(value)
        {
        }
    }
}