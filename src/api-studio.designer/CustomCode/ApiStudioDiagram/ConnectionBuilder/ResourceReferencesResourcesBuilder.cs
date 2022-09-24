// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Linq;

namespace ApiStudioIO
{
    using DslModeling = Microsoft.VisualStudio.Modeling;

    public static partial class ResourceReferencesResourcesBuilder
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

            if (CanAcceptSourceAndTarget(source, target) && source is Resource sourceAccepted &&
                target is Resource targetAccepted)
            {
                DslModeling.ElementLink result = new ResourceReferencesResources(sourceAccepted, targetAccepted);
                if (DslModeling.DomainClassInfo.HasNameProperty(result))
                    DslModeling.DomainClassInfo.SetUniqueName(result);
                SetResourceDefaults(targetAccepted); // Set Api Studio Defaults

                return result;
            }

            Debug.Fail("Having agreed that the connection can be accepted we should never fail to make one.");
            throw new InvalidOperationException();
        }

        #endregion Connection Methods

        #region Create Defaults

        private static void SetResourceDefaults(Resource resource)
        {
            resource.Apis
                .ToList()
                .ForEach(x => (x as HttpApi)?.SetDefaults());

            foreach (var childResource in resource.Resources) SetResourceDefaults(childResource);
        }

        #endregion Create Defaults

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
                case Resource _:
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
                case Resource _:
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
                && source is Resource sourceResource
                && target is Resource targetResource
                && ResourceReferencesResources.GetLinks(sourceResource, targetResource).Count == 0)
                return true;
            return false;
        }

        #endregion Accept Connection Methods
    }
}