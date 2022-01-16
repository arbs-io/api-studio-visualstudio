using Microsoft.VisualStudio.Modeling.Diagrams;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms.Design;
using DslModeling = Microsoft.VisualStudio.Modeling;

namespace ApiStudioIO
{
    using System;

    public class ApiStudioComponentUITypeEditor<TDomainEntity, TPropertyEntity>
        : System.ComponentModel.Design.CollectionEditor
            where TDomainEntity : DslModeling::ModelElement
            where TPropertyEntity : IApiStudioComponent
    {
        private TDomainEntity _domainEntity;

        public ApiStudioComponentUITypeEditor(Type t) : base(t)
        {
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            Debug.Assert(provider.GetService(typeof(IWindowsFormsEditorService)) is IWindowsFormsEditorService, "Couldn't get a reference to the editor service");

            if (context.Instance is PresentationElement pel)
            {
                _domainEntity = pel.ModelElement as TDomainEntity;
            }
            else
            {
                _domainEntity = context.Instance as TDomainEntity;
            }

            Debug.Assert(_domainEntity != null, "Expecting a DomainEntity");

            return base.EditValue(context, provider, value);
        }

        protected override object SetItems(object editValue, object[] managed)
        {
            var propertyEntities = new List<TPropertyEntity>();
            foreach (var apiStudioObject in managed)
            {
                if (apiStudioObject is TPropertyEntity entity)
                {
                    propertyEntities.Add(entity);
                }
            }
            ApiStudioComponentTransactionManager.Save(_domainEntity, propertyEntities);

            return base.SetItems(editValue, managed);
        }
    }
}