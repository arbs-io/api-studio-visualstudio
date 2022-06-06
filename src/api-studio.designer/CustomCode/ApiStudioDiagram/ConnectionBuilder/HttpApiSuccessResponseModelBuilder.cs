// The MIT License (MIT)
//
// Copyright (c) 2022 Andrew Butson
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

using System;
using System.Diagnostics;
using DslModeling = Microsoft.VisualStudio.Modeling;

namespace ApiStudioIO
{
    public static partial class HttpApiSuccessResponseModelBuilder
    {
        #region Connection Methods

        /// <summary>
        ///     Make a connection between the given pair of source and target elements
        /// </summary>
        /// <param name="source">The model element to use as the source of the connection</param>
        /// <param name="target">The model element to use as the target of the connection</param>
        /// <returns>A link representing the created connection</returns>
        public static DslModeling.ElementLink Connect(DslModeling.ModelElement source, DslModeling.ModelElement target)
        {
            _ = source ?? throw new ArgumentNullException(nameof(source));
            _ = target ?? throw new ArgumentNullException(nameof(target));

            if (CanAcceptSourceAndTarget(source, target) && source is HttpApi sourceAccepted &&
                target is DataModel targetAccepted)
            {
                DslModeling.ElementLink result = new HttpApiSuccessResponseModel(sourceAccepted, targetAccepted);
                if (DslModeling.DomainClassInfo.HasNameProperty(result))
                    DslModeling.DomainClassInfo.SetUniqueName(result);
                sourceAccepted.SetDefaults(); // Set Api Studio Defaults

                return result;
            }

            Debug.Fail("Having agreed that the connection can be accepted we should never fail to make one.");
            throw new InvalidOperationException();
        }

        #endregion Connection Methods

        #region Accept Connection Methods

        /// <summary>
        ///     Test whether a given model element is acceptable to this ConnectionBuilder as the source of a connection.
        /// </summary>
        /// <param name="candidate">The model element to test.</param>
        /// <returns>Whether the element can be used as the source of a connection.</returns>
        public static bool CanAcceptSource(DslModeling.ModelElement candidate)
        {
            switch (candidate)
            {
                case null:
                    return false;
                case HttpApi _:
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        ///     Test whether a given model element is acceptable to this ConnectionBuilder as the target of a connection.
        /// </summary>
        /// <param name="candidate">The model element to test.</param>
        /// <returns>Whether the element can be used as the target of a connection.</returns>
        public static bool CanAcceptTarget(DslModeling.ModelElement candidate)
        {
            switch (candidate)
            {
                case null:
                    return false;
                case DataModel _:
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        ///     Test whether a given pair of model elements are acceptable to this ConnectionBuilder as the source and target of a
        ///     connection
        /// </summary>
        /// <param name="candidateSource">The model element to test as a source</param>
        /// <param name="candidateTarget">The model element to test as a target</param>
        /// <returns>Whether the elements can be used as the source and target of a connection</returns>
        public static bool CanAcceptSourceAndTarget(DslModeling.ModelElement source, DslModeling.ModelElement target)
        {
            _ = source ?? throw new ArgumentNullException(nameof(source));
            _ = target ?? throw new ArgumentNullException(nameof(target));

            // If the source wasn't accepted then there's no point checking targets.
            // If there is no target then the source controls the accept.
            if (CanAcceptSource(source) && CanAcceptTarget(target) && source is HttpApi sourceHttpApi &&
                target is DataModel targetDataModel)
                if (HttpApiSuccessResponseModel.GetLinks(sourceHttpApi, targetDataModel).Count == 0)
                    return true;
            return false;
        }

        #endregion Accept Connection Methods
    }
}