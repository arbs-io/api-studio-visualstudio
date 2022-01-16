﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiStudioIO.CodeGeneration.AzureFunction.v1.Templates {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ApiStudioIO.CodeGeneration.AzureFunction.v1.Templates.Resource", typeof(Resource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to namespace {{TOKEN_OAS_NAMESPACE}}
        ///{
        ///    using System.Net;
        ///    using System.Threading.Tasks;
        ///    using Microsoft.Azure.Functions.Worker;
        ///    using Microsoft.Azure.Functions.Worker.Http;
        ///    using Microsoft.Extensions.Logging;
        ///
        ///    public partial class {{TOKEN_OAS_CLASS_NAME}}
        ///    {
        ///        private readonly ILogger _logger;
        ///        public {{TOKEN_OAS_CLASS_NAME}}(ILoggerFactory loggerFactory)
        ///        {
        ///            _logger = loggerFactory.CreateLogger&lt;{{TOKEN_OAS_CLASS_NAME}}&gt;();
        ///        }
        ///
        ///    [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string HttpTrigger {
            get {
                return ResourceManager.GetString("HttpTrigger", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to namespace {{TOKEN_OAS_NAMESPACE}}
        ///{
        ///    using System;
        ///    using System.Net;
        ///    using System.Threading.Tasks;
        ///
        ///    using Microsoft.Azure.Functions.Worker;
        ///    using Microsoft.Azure.Functions.Worker.Http;
        ///    using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
        ///    using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
        ///    using Microsoft.OpenApi.Models;
        ///
        ///    using SecurityFlows;
        ///    using Models;
        ///
        ///    public partial class {{TOKEN_OAS_CLASS_NAME}}
        ///    {
        ///        [Function(n [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string HttpTriggerDesigner {
            get {
                return ResourceManager.GetString("HttpTriggerDesigner", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to #nullable enable
        ///namespace {{TOKEN_OAS_NAMESPACE}}
        ///{
        ///    using System;
        ///    using System.Collections.Generic;
        ///    using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
        ///
        ///    public class {{TOKEN_OAS_CLASS_NAME}}
        ///    {
        ///        [OpenApiProperty(Description = &quot;Example of required uuid&quot;, Default = &quot;5571596d-dd42-4fb6-8c20-2620cc43d432&quot;, Nullable = false)]
        ///        public Guid Identifier { get; set; } = new Guid(&quot;5571596d-dd42-4fb6-8c20-2620cc43d432&quot;);
        ///
        ///        [OpenApiProperty(Description = [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Model {
            get {
                return ResourceManager.GetString("Model", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Configurations;
        ///using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
        ///using Microsoft.OpenApi.Models;
        ///using System;
        ///
        ///namespace Configurations
        ///{
        ///    public class OpenApiConfigurationOptions : DefaultOpenApiConfigurationOptions
        ///    {
        ///        public override OpenApiInfo Info { get; set; } = new OpenApiInfo()
        ///        {
        ///            Version = @&quot;{{TOKEN_OAS_VERSION}}&quot;,
        ///            Title = @&quot;{{TOKEN_OAS_TITLE}}&quot;,
        ///            Description = @&quot;{ [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string OpenApiConfigurationOptions {
            get {
                return ResourceManager.GetString("OpenApiConfigurationOptions", resourceCulture);
            }
        }
    }
}
