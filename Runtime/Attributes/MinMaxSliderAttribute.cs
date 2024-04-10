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
using UnityEngine;

/// <summary>
/// This class is used to create a slider with a minimum and maximum value in the Unity inspector.
/// </summary>
// ReSharper disable once CheckNamespace
public class MinMaxSliderAttribute : PropertyAttribute
{
    /// <summary>
    /// The minimum value of the slider.
    /// </summary>
    public float Min { get; private set; }

    /// <summary>
    /// The maximum value of the slider.
    /// </summary>
    public float Max { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="MinMaxSliderAttribute"/> class.
    /// </summary>
    /// <param name="min">The minimum value of the slider.</param>
    /// <param name="max">The maximum value of the slider.</param>
    public MinMaxSliderAttribute(float min, float max)
    {
        Min = min;
        Max = max;
    }
}