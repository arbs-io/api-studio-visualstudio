using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Windows.Forms.Design;
using ApiStudioIO.Common.Models.Http;
using Microsoft.VisualStudio.Modeling.Diagrams;

namespace ApiStudioIO
{
    using DslModeling = Microsoft.VisualStudio.Modeling;

    public class ApiStudioComponentUITypeEditor<TDomainEntity, TPropertyEntity>
        : CollectionEditor
        where TDomainEntity : DslModeling.ModelElement
        where TPropertyEntity : IHttpResource
    {
        private TDomainEntity _domainEntity;

        public ApiStudioComponentUITypeEditor(Type t) : base(t)
        {
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            _ = context ?? throw new ArgumentNullException(nameof(context));
            _ = provider ?? throw new ArgumentNullException(nameof(provider));
            _ = value ?? throw new ArgumentNullException(nameof(value));

            Debug.Assert(provider.GetService(typeof(IWindowsFormsEditorService)) is IWindowsFormsEditorService,
                "Couldn't get a reference to the editor service");

            if (context.Instance is PresentationElement pel)
                _domainEntity = pel.ModelElement as TDomainEntity;
            else
                _domainEntity = context.Instance as TDomainEntity;

            Debug.Assert(_domainEntity != null, "Expecting a DomainEntity");

            return base.EditValue(context, provider, value);
        }

        protected override object SetItems(object editValue, object[] value)
        {
            var propertyEntities = new List<TPropertyEntity>();
            foreach (var apiStudioObject in value)
                if (apiStudioObject is TPropertyEntity entity)
                    propertyEntities.Add(entity);
            ApiStudioComponentTransactionManager.Save(_domainEntity, propertyEntities);

            return base.SetItems(editValue, value);
        }
    }
}