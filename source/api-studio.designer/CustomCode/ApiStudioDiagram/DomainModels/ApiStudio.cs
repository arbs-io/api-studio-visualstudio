namespace ApiStudioIO
{
    using Microsoft.VisualStudio.Modeling;
    using System;
    using DslModeling = global::Microsoft.VisualStudio.Modeling;

    public partial class ApiStudio
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="store">Store where new element is to be created.</param>
        /// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
        public ApiStudio(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
            : this(store?.DefaultPartitionForClass(DomainClassId), propertyAssignments)
        {
            SetIdentifierValue();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="partition">Partition where new element is to be created.</param>
        /// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
        public ApiStudio(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
            : base(partition, propertyAssignments)
        {
            SetIdentifierValue();
        }

        private void SetIdentifierValue()
        {
            if (Identifier.ToString() == "00000000-0000-0000-0000-000000000000")
            {
                using (Transaction t = Store.TransactionManager.BeginTransaction("ApiStudio.SetIdentifierValue"))
                {
                    Identifier = Guid.NewGuid();
                    t.Commit();
                }
            }
        }

        public string GetTitleValue()
        {
            return $@"{Vendor} {Product} - {ApiName} v{Version}";
        }
    }
}