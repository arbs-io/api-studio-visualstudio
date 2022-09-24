// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

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
            if (CanAcceptSource(source)
                && CanAcceptTarget(target)
                && source is HttpApi sourceHttpApi
                && target is DataModel targetDataModel
                && HttpApiSuccessResponseModel.GetLinks(sourceHttpApi, targetDataModel).Count == 0)
                return true;
            return false;
        }

        #endregion Accept Connection Methods
    }
}