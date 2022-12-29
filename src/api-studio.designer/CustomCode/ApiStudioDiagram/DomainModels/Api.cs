// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System;

namespace ApiStudioIO
{
    using DslModeling = Microsoft.VisualStudio.Modeling;

    public partial class Api
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="store">Store where new element is to be created.</param>
        /// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
        protected Api(DslModeling.Store store, params DslModeling.PropertyAssignment[] propertyAssignments)
            : this(store?.DefaultPartitionForClass(DomainClassId), propertyAssignments)
        {
            SetIdentifierValue();
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="partition">Partition where new element is to be created.</param>
        /// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
        protected Api(DslModeling.Partition partition, params DslModeling.PropertyAssignment[] propertyAssignments)
            : base(partition, propertyAssignments)
        {
            SetIdentifierValue();
        }

        private void SetIdentifierValue()
        {
            if (Identifier.ToString() != "00000000-0000-0000-0000-000000000000") return;
            using (var t = Store.TransactionManager.BeginTransaction("Api.SetIdentifierValue"))
            {
                Identifier = Guid.NewGuid();
                t.Commit();
            }
        }

        public virtual string GetDisplayNameValue()
        {
            return "";
        }
    }
}