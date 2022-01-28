namespace ApiStudioIO
{
    using Microsoft.VisualStudio.Modeling;
    using System;
    using System.ComponentModel;
    using System.Reflection;
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

        //internal partial class SecuritySchemeTypePropertyHandler
        //{
        //    protected override void OnValueChanged(ApiStudio element, SecuritySchemeTypes oldValue, SecuritySchemeTypes newValue)
        //    {
        //        base.OnValueChanged(element, oldValue, newValue);
        //        if (element != null)
        //        {
        //            //element.SecurityAuthorizationUrl

        //            var propCollection = TypeDescriptor.GetProperties(element);
        //            PropertyDescriptor descriptor = propCollection["SecurityAuthorizationUrl"];

        //            BrowsableAttribute attrib = (BrowsableAttribute)descriptor.Attributes[typeof(BrowsableAttribute)];
        //            FieldInfo isBrow = attrib.GetType().GetField("browsable", BindingFlags.NonPublic | BindingFlags.Instance);
        //            //Condition to Show or Hide set here:
        //            isBrow.SetValue(attrib, false);
        //            //propertyGrid1.Refresh(); //Remember to refresh PropertyGrid to reflect your changes
                    
        //        }
        //    }
        //}
    }
}