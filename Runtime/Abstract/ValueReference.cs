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

// ReSharper disable once CheckNamespace

namespace ScriptableArchitect.Variables
{
    /// <summary>
    /// Represents a reference to a value that can either be a constant or a variable asset.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <typeparam name="TAsset">The type of the asset variable, which must be a ValueAsset of TValue.</typeparam>
    public abstract class ValueReference<TValue, TAsset> where TAsset : ValueAsset<TValue>
    {
        /// <summary>
        /// Determines whether to use the constant value or the asset variable.
        /// </summary>
        // ReSharper disable once FieldCanBeMadeReadOnly.Global
        // ReSharper disable once MemberCanBeProtected.Global
        public bool useConstant = true;

        /// <summary>
        /// The constant value to use if useConstant is true.
        /// </summary>
        // ReSharper disable once MemberCanBeProtected.Global
        public TValue constantValue;

        /// <summary>
        /// The asset variable to use if useConstant is false.
        /// </summary>
        // ReSharper disable once UnassignedField.Global
        public TAsset assetVariable;

        /// <summary>
        /// Default constructor.
        /// </summary>
        // ReSharper disable once PublicConstructorInAbstractClass
        public ValueReference()
        {
        }

        /// <summary>
        /// Constructor that sets the constant value and sets useConstant to true.
        /// </summary>
        /// <param name="value">The constant value to set.</param>
        // ReSharper disable once PublicConstructorInAbstractClass
        public ValueReference(TValue value)
        {
            useConstant = true;
            constantValue = value;
        }

        /// <summary>
        /// Gets the value, which is either the constant value or the asset variable's value, depending on useConstant and whether the asset variable is null.
        /// </summary>
        public TValue Value => useConstant || assetVariable == null ? constantValue : assetVariable.value;

        /// <summary>
        /// Sets the value, either to the constant value if useConstant is true, or to the asset variable's value if useConstant is false.
        /// </summary>
        /// <param name="value">The value to set.</param>
        public void SetRefValue(TValue value)
        {
            if (useConstant)
                constantValue = value;
            else
                assetVariable.value = value;
        }

        /// <summary>
        /// Gets the value, which is either the constant value or the asset variable's value, depending on useConstant and whether the asset variable is null.
        /// </summary>
        /// <returns>The value.</returns>
        public TValue GetValue() => Value;

        /// <summary>
        /// Implicit conversion operator from a ValueReference to a TValue. If the reference is null, the default value for TValue is returned. Otherwise, the Value property of the reference is returned.
        /// </summary>
        /// <param name="reference">The ValueReference to convert.</param>
        public static implicit operator TValue(ValueReference<TValue, TAsset> reference) =>
            reference == null ? default : reference.Value;
    }
}