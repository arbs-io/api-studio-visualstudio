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