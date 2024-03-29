﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslDesign = global::Microsoft.VisualStudio.Modeling.Design;
using System;
using System.Diagnostics;
using System.Drawing.Design;
using System.Windows.Forms;
using DslDiagrams = global::Microsoft.VisualStudio.Modeling.Diagrams;

namespace ApiStudioIO
{
	/// <summary>
	/// Helper class used to create and initialize toolbox items for this DSL.
	/// </summary>
	/// <remarks>
	/// Double-derived class to allow easier code customization.
	/// </remarks>
	public partial class ApiStudioIOToolboxHelper : ApiStudioIOToolboxHelperBase 
	{
		/// <summary>
		/// Constructs a new ApiStudioIOToolboxHelper.
		/// </summary>
		public ApiStudioIOToolboxHelper(global::System.IServiceProvider serviceProvider)
			: base(serviceProvider) { }
	}
	
	/// <summary>
	/// Helper class used to create and initialize toolbox items for this DSL.
	/// </summary>
	
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable", Justification = "The store is disposed on domain shut down")]
	public abstract class ApiStudioIOToolboxHelperBase
	{
		/// <summary>
		/// Toolbox item filter string used to identify ApiStudioIO toolbox items.  
		/// </summary>
		/// <remarks>
		/// See the MSDN documentation for the ToolboxItemFilterAttribute class for more information on toolbox
		/// item filters.
		/// </remarks>
		public const string ToolboxFilterString = "ApiStudioIO.1.0";
		/// <summary>
		/// Toolbox item filter string used to identify ResourceAssociation connector tool.
		/// </summary>
		public const string ResourceAssociationFilterString = "ResourceAssociation.1.0";
		/// <summary>
		/// Toolbox item filter string used to identify HttpApiResourceTool connector tool.
		/// </summary>
		public const string HttpApiResourceToolFilterString = "HttpApiResourceTool.1.0";
		/// <summary>
		/// Toolbox item filter string used to identify HttpApiRequestTool connector tool.
		/// </summary>
		public const string HttpApiRequestToolFilterString = "HttpApiRequestTool.1.0";
		/// <summary>
		/// Toolbox item filter string used to identify HttpApiResponseTool connector tool.
		/// </summary>
		public const string HttpApiResponseToolFilterString = "HttpApiResponseTool.1.0";

	
		private global::System.Collections.Generic.Dictionary<string, DslDesign::ModelingToolboxItem> toolboxItemCache = new global::System.Collections.Generic.Dictionary<string, DslDesign::ModelingToolboxItem>();
		private DslModeling::Store toolboxStore;
		
		private global::System.IServiceProvider sp;
		
		/// <summary>
		/// Constructs a new ApiStudioIOToolboxHelperBase.
		/// </summary>
		protected ApiStudioIOToolboxHelperBase(global::System.IServiceProvider serviceProvider)
		{
			if(serviceProvider == null) throw new global::System.ArgumentNullException("serviceProvider");
			
			this.sp = serviceProvider;
		}
		
		/// <summary>
		/// Serivce provider used to access services from the hosting environment.
		/// </summary>
		protected global::System.IServiceProvider ServiceProvider
		{
			get
			{
				return this.sp;
			}
		}

		/// <summary>
		/// Returns the display name of the tab that should be opened by default when the editor is opened.
		/// </summary>
		public static string DefaultToolboxTabName
		{
			get
			{
				return global::ApiStudioIO.ApiStudioIODomainModel.SingletonResourceManager.GetString("ApiStudio - ResourcesToolboxTab", global::System.Globalization.CultureInfo.CurrentUICulture);
			}
		}
		
		
		/// <summary>
		/// Returns the toolbox items count in the default tool box tab.
		/// </summary>
		public static int DefaultToolboxTabToolboxItemsCount
		{
			get
			{
				return 5;
			}
		}
		

		/// <summary>
		/// Returns a list of custom toolbox items to be added dynamically
		/// </summary>
		public virtual global::System.Collections.Generic.IList<DslDesign::ModelingToolboxItem> CreateToolboxItems()
		{
			global::System.Collections.Generic.List<DslDesign::ModelingToolboxItem> toolboxItems = new global::System.Collections.Generic.List<DslDesign::ModelingToolboxItem>();
			return toolboxItems;
		}
		
		/// <summary>
		/// Creates an ElementGroupPrototype for the element tool corresponding to the given domain class id.
		/// Default behavior is to create a prototype containing an instance of the domain class.
		/// Derived classes may override this to add additional information to the prototype.
		/// </summary>
		protected virtual DslModeling::ElementGroupPrototype CreateElementToolPrototype(DslModeling::Store store, global::System.Guid domainClassId)
		{
			DslModeling::ModelElement element = store.ElementFactory.CreateElement(domainClassId);
			DslModeling::ElementGroup elementGroup = new DslModeling::ElementGroup(store.DefaultPartition);
			elementGroup.AddGraph(element, true);
			return elementGroup.CreatePrototype();
		}

		/// <summary>
		/// Returns instance of ModelingToolboxItem based on specified name.
		/// This method must be called from within a Transaction. Failure to do so will result in an exception
		/// </summary>
		/// <param name="itemId">unique name of desired ToolboxItem</param>
		/// <param name="store">Store to perform the operation against</param>
		/// <returns>An instance of ModelingToolboxItem if the itemId can be resolved, null otherwise</returns>
		public virtual DslDesign::ModelingToolboxItem GetToolboxItem(string itemId, DslModeling::Store store)
		{
			DslDesign::ModelingToolboxItem result = null;
			if (string.IsNullOrEmpty(itemId))
			{
				return null;
			}
			if (store == null)
			{
				return null;
			}
			global::System.Resources.ResourceManager resourceManager = global::ApiStudioIO.ApiStudioIODomainModel.SingletonResourceManager;
			global::System.Globalization.CultureInfo resourceCulture = global::System.Globalization.CultureInfo.CurrentUICulture;
			switch(itemId)
			{
				case "ApiStudioIO.ResourceAssociationToolboxItem":

					// Add ResourceAssociation connector tool.
					result = new DslDesign::ModelingToolboxItem(
						"ApiStudioIO.ResourceAssociationToolboxItem", // Unique identifier (non-localized) for the toolbox item.
						1, // Position relative to other items in the same toolbox tab.
						resourceManager.GetString("ResourceAssociationToolboxItem", resourceCulture), // Localized display name for the item.
						(global::System.Drawing.Bitmap)DslDiagrams::ImageHelper.GetImage(resourceManager.GetObject("ResourceAssociationToolboxBitmap", resourceCulture)), // Image displayed next to the toolbox item.				
						"ApiStudioIO.ApiStudio - ResourcesToolboxTab", // Unique identifier (non-localized) for the toolbox item tab.
						resourceManager.GetString("ApiStudio - ResourcesToolboxTab", resourceCulture), // Localized display name for the toolbox tab.
						"F1KeywordResourceToResource", // F1 help keyword for the toolbox item.
						resourceManager.GetString("ResourceAssociationToolboxTooltip", resourceCulture), // Localized tooltip text for the toolbox item.
						null, // Connector toolbox items do not have an underlying data object.
						new global::System.ComponentModel.ToolboxItemFilterAttribute[] { // Collection of ToolboxItemFilterAttribute objects that determine visibility of the toolbox item.
							new global::System.ComponentModel.ToolboxItemFilterAttribute(ToolboxFilterString, global::System.ComponentModel.ToolboxItemFilterType.Require), 
							new global::System.ComponentModel.ToolboxItemFilterAttribute(ResourceAssociationFilterString)
						});
					break;
				case "ApiStudioIO.ResourceCollectionToolToolboxItem":
					// Add ResourceCollectionTool shape tool.
					result = new DslDesign::ModelingToolboxItem(
						"ApiStudioIO.ResourceCollectionToolToolboxItem", // Unique identifier (non-localized) for the toolbox item.
						2, // Position relative to other items in the same toolbox tab.
						resourceManager.GetString("ResourceCollectionToolToolboxItem", resourceCulture), // Localized display name for the item.
						(global::System.Drawing.Bitmap)DslDiagrams::ImageHelper.GetImage(resourceManager.GetObject("ResourceCollectionToolToolboxBitmap", resourceCulture)), // Image displayed next to the toolbox item.
						"ApiStudioIO.ApiStudio - ResourcesToolboxTab", // Unique identifier (non-localized) for the toolbox item tab.
						resourceManager.GetString("ApiStudio - ResourcesToolboxTab", resourceCulture), // Localized display name for the toolbox tab.
						"F1KeywordResourceCollection", // F1 help keyword for the toolbox item.
						resourceManager.GetString("ResourceCollectionToolToolboxTooltip", resourceCulture), // Localized tooltip text for the toolbox item.
						CreateElementToolPrototype(store, global::ApiStudioIO.ResourceCollection.DomainClassId), // ElementGroupPrototype (data object) representing model element on the toolbox.
						new global::System.ComponentModel.ToolboxItemFilterAttribute[] { // Collection of ToolboxItemFilterAttribute objects that determine visibility of the toolbox item.
						new global::System.ComponentModel.ToolboxItemFilterAttribute(ToolboxFilterString, global::System.ComponentModel.ToolboxItemFilterType.Require) 
						});
					break;
				case "ApiStudioIO.ResourceInstanceToolToolboxItem":
					// Add ResourceInstanceTool shape tool.
					result = new DslDesign::ModelingToolboxItem(
						"ApiStudioIO.ResourceInstanceToolToolboxItem", // Unique identifier (non-localized) for the toolbox item.
						3, // Position relative to other items in the same toolbox tab.
						resourceManager.GetString("ResourceInstanceToolToolboxItem", resourceCulture), // Localized display name for the item.
						(global::System.Drawing.Bitmap)DslDiagrams::ImageHelper.GetImage(resourceManager.GetObject("ResourceInstanceToolToolboxBitmap", resourceCulture)), // Image displayed next to the toolbox item.
						"ApiStudioIO.ApiStudio - ResourcesToolboxTab", // Unique identifier (non-localized) for the toolbox item tab.
						resourceManager.GetString("ApiStudio - ResourcesToolboxTab", resourceCulture), // Localized display name for the toolbox tab.
						"F1KeywordResourceInstance", // F1 help keyword for the toolbox item.
						resourceManager.GetString("ResourceInstanceToolToolboxTooltip", resourceCulture), // Localized tooltip text for the toolbox item.
						CreateElementToolPrototype(store, global::ApiStudioIO.ResourceInstance.DomainClassId), // ElementGroupPrototype (data object) representing model element on the toolbox.
						new global::System.ComponentModel.ToolboxItemFilterAttribute[] { // Collection of ToolboxItemFilterAttribute objects that determine visibility of the toolbox item.
						new global::System.ComponentModel.ToolboxItemFilterAttribute(ToolboxFilterString, global::System.ComponentModel.ToolboxItemFilterType.Require) 
						});
					break;
				case "ApiStudioIO.ResourceAttributeToolToolboxItem":
					// Add ResourceAttributeTool shape tool.
					result = new DslDesign::ModelingToolboxItem(
						"ApiStudioIO.ResourceAttributeToolToolboxItem", // Unique identifier (non-localized) for the toolbox item.
						4, // Position relative to other items in the same toolbox tab.
						resourceManager.GetString("ResourceAttributeToolToolboxItem", resourceCulture), // Localized display name for the item.
						(global::System.Drawing.Bitmap)DslDiagrams::ImageHelper.GetImage(resourceManager.GetObject("ResourceAttributeToolToolboxBitmap", resourceCulture)), // Image displayed next to the toolbox item.
						"ApiStudioIO.ApiStudio - ResourcesToolboxTab", // Unique identifier (non-localized) for the toolbox item tab.
						resourceManager.GetString("ApiStudio - ResourcesToolboxTab", resourceCulture), // Localized display name for the toolbox tab.
						"F1KeywordResourceAttribute", // F1 help keyword for the toolbox item.
						resourceManager.GetString("ResourceAttributeToolToolboxTooltip", resourceCulture), // Localized tooltip text for the toolbox item.
						CreateElementToolPrototype(store, global::ApiStudioIO.ResourceAttribute.DomainClassId), // ElementGroupPrototype (data object) representing model element on the toolbox.
						new global::System.ComponentModel.ToolboxItemFilterAttribute[] { // Collection of ToolboxItemFilterAttribute objects that determine visibility of the toolbox item.
						new global::System.ComponentModel.ToolboxItemFilterAttribute(ToolboxFilterString, global::System.ComponentModel.ToolboxItemFilterType.Require) 
						});
					break;
				case "ApiStudioIO.ResourceActionToolToolboxItem":
					// Add ResourceActionTool shape tool.
					result = new DslDesign::ModelingToolboxItem(
						"ApiStudioIO.ResourceActionToolToolboxItem", // Unique identifier (non-localized) for the toolbox item.
						5, // Position relative to other items in the same toolbox tab.
						resourceManager.GetString("ResourceActionToolToolboxItem", resourceCulture), // Localized display name for the item.
						(global::System.Drawing.Bitmap)DslDiagrams::ImageHelper.GetImage(resourceManager.GetObject("ResourceActionToolToolboxBitmap", resourceCulture)), // Image displayed next to the toolbox item.
						"ApiStudioIO.ApiStudio - ResourcesToolboxTab", // Unique identifier (non-localized) for the toolbox item tab.
						resourceManager.GetString("ApiStudio - ResourcesToolboxTab", resourceCulture), // Localized display name for the toolbox tab.
						"F1KeywordResourceAction", // F1 help keyword for the toolbox item.
						resourceManager.GetString("ResourceActionToolToolboxTooltip", resourceCulture), // Localized tooltip text for the toolbox item.
						CreateElementToolPrototype(store, global::ApiStudioIO.ResourceAction.DomainClassId), // ElementGroupPrototype (data object) representing model element on the toolbox.
						new global::System.ComponentModel.ToolboxItemFilterAttribute[] { // Collection of ToolboxItemFilterAttribute objects that determine visibility of the toolbox item.
						new global::System.ComponentModel.ToolboxItemFilterAttribute(ToolboxFilterString, global::System.ComponentModel.ToolboxItemFilterType.Require) 
						});
					break;
				case "ApiStudioIO.HttpApiResourceToolToolboxItem":

					// Add HttpApiResourceTool connector tool.
					result = new DslDesign::ModelingToolboxItem(
						"ApiStudioIO.HttpApiResourceToolToolboxItem", // Unique identifier (non-localized) for the toolbox item.
						1, // Position relative to other items in the same toolbox tab.
						resourceManager.GetString("HttpApiResourceToolToolboxItem", resourceCulture), // Localized display name for the item.
						(global::System.Drawing.Bitmap)DslDiagrams::ImageHelper.GetImage(resourceManager.GetObject("HttpApiResourceToolToolboxBitmap", resourceCulture)), // Image displayed next to the toolbox item.				
						"ApiStudioIO.ApiStudio - HTTP APIsToolboxTab", // Unique identifier (non-localized) for the toolbox item tab.
						resourceManager.GetString("ApiStudio - HTTP APIsToolboxTab", resourceCulture), // Localized display name for the toolbox tab.
						"F1KeywordResourceToHttpApi", // F1 help keyword for the toolbox item.
						resourceManager.GetString("HttpApiResourceToolToolboxTooltip", resourceCulture), // Localized tooltip text for the toolbox item.
						null, // Connector toolbox items do not have an underlying data object.
						new global::System.ComponentModel.ToolboxItemFilterAttribute[] { // Collection of ToolboxItemFilterAttribute objects that determine visibility of the toolbox item.
							new global::System.ComponentModel.ToolboxItemFilterAttribute(ToolboxFilterString, global::System.ComponentModel.ToolboxItemFilterType.Require), 
							new global::System.ComponentModel.ToolboxItemFilterAttribute(HttpApiResourceToolFilterString)
						});
					break;
				case "ApiStudioIO.HttpApiGetToolToolboxItem":
					// Add HttpApiGetTool shape tool.
					result = new DslDesign::ModelingToolboxItem(
						"ApiStudioIO.HttpApiGetToolToolboxItem", // Unique identifier (non-localized) for the toolbox item.
						2, // Position relative to other items in the same toolbox tab.
						resourceManager.GetString("HttpApiGetToolToolboxItem", resourceCulture), // Localized display name for the item.
						(global::System.Drawing.Bitmap)DslDiagrams::ImageHelper.GetImage(resourceManager.GetObject("HttpApiGetToolToolboxBitmap", resourceCulture)), // Image displayed next to the toolbox item.
						"ApiStudioIO.ApiStudio - HTTP APIsToolboxTab", // Unique identifier (non-localized) for the toolbox item tab.
						resourceManager.GetString("ApiStudio - HTTP APIsToolboxTab", resourceCulture), // Localized display name for the toolbox tab.
						"F1KeywordApiGetTool", // F1 help keyword for the toolbox item.
						resourceManager.GetString("HttpApiGetToolToolboxTooltip", resourceCulture), // Localized tooltip text for the toolbox item.
						CreateElementToolPrototype(store, global::ApiStudioIO.HttpApiGet.DomainClassId), // ElementGroupPrototype (data object) representing model element on the toolbox.
						new global::System.ComponentModel.ToolboxItemFilterAttribute[] { // Collection of ToolboxItemFilterAttribute objects that determine visibility of the toolbox item.
						new global::System.ComponentModel.ToolboxItemFilterAttribute(ToolboxFilterString, global::System.ComponentModel.ToolboxItemFilterType.Require) 
						});
					break;
				case "ApiStudioIO.HttpApiPutToolToolboxItem":
					// Add HttpApiPutTool shape tool.
					result = new DslDesign::ModelingToolboxItem(
						"ApiStudioIO.HttpApiPutToolToolboxItem", // Unique identifier (non-localized) for the toolbox item.
						3, // Position relative to other items in the same toolbox tab.
						resourceManager.GetString("HttpApiPutToolToolboxItem", resourceCulture), // Localized display name for the item.
						(global::System.Drawing.Bitmap)DslDiagrams::ImageHelper.GetImage(resourceManager.GetObject("HttpApiPutToolToolboxBitmap", resourceCulture)), // Image displayed next to the toolbox item.
						"ApiStudioIO.ApiStudio - HTTP APIsToolboxTab", // Unique identifier (non-localized) for the toolbox item tab.
						resourceManager.GetString("ApiStudio - HTTP APIsToolboxTab", resourceCulture), // Localized display name for the toolbox tab.
						"F1KeywordHttpApiPutTool", // F1 help keyword for the toolbox item.
						resourceManager.GetString("HttpApiPutToolToolboxTooltip", resourceCulture), // Localized tooltip text for the toolbox item.
						CreateElementToolPrototype(store, global::ApiStudioIO.HttpApiPut.DomainClassId), // ElementGroupPrototype (data object) representing model element on the toolbox.
						new global::System.ComponentModel.ToolboxItemFilterAttribute[] { // Collection of ToolboxItemFilterAttribute objects that determine visibility of the toolbox item.
						new global::System.ComponentModel.ToolboxItemFilterAttribute(ToolboxFilterString, global::System.ComponentModel.ToolboxItemFilterType.Require) 
						});
					break;
				case "ApiStudioIO.HttpApiPostToolToolboxItem":
					// Add HttpApiPostTool shape tool.
					result = new DslDesign::ModelingToolboxItem(
						"ApiStudioIO.HttpApiPostToolToolboxItem", // Unique identifier (non-localized) for the toolbox item.
						4, // Position relative to other items in the same toolbox tab.
						resourceManager.GetString("HttpApiPostToolToolboxItem", resourceCulture), // Localized display name for the item.
						(global::System.Drawing.Bitmap)DslDiagrams::ImageHelper.GetImage(resourceManager.GetObject("HttpApiPostToolToolboxBitmap", resourceCulture)), // Image displayed next to the toolbox item.
						"ApiStudioIO.ApiStudio - HTTP APIsToolboxTab", // Unique identifier (non-localized) for the toolbox item tab.
						resourceManager.GetString("ApiStudio - HTTP APIsToolboxTab", resourceCulture), // Localized display name for the toolbox tab.
						"F1KeywordHttpApiPostTool", // F1 help keyword for the toolbox item.
						resourceManager.GetString("HttpApiPostToolToolboxTooltip", resourceCulture), // Localized tooltip text for the toolbox item.
						CreateElementToolPrototype(store, global::ApiStudioIO.HttpApiPost.DomainClassId), // ElementGroupPrototype (data object) representing model element on the toolbox.
						new global::System.ComponentModel.ToolboxItemFilterAttribute[] { // Collection of ToolboxItemFilterAttribute objects that determine visibility of the toolbox item.
						new global::System.ComponentModel.ToolboxItemFilterAttribute(ToolboxFilterString, global::System.ComponentModel.ToolboxItemFilterType.Require) 
						});
					break;
				case "ApiStudioIO.HttpApiDeleteToolToolboxItem":
					// Add HttpApiDeleteTool shape tool.
					result = new DslDesign::ModelingToolboxItem(
						"ApiStudioIO.HttpApiDeleteToolToolboxItem", // Unique identifier (non-localized) for the toolbox item.
						5, // Position relative to other items in the same toolbox tab.
						resourceManager.GetString("HttpApiDeleteToolToolboxItem", resourceCulture), // Localized display name for the item.
						(global::System.Drawing.Bitmap)DslDiagrams::ImageHelper.GetImage(resourceManager.GetObject("HttpApiDeleteToolToolboxBitmap", resourceCulture)), // Image displayed next to the toolbox item.
						"ApiStudioIO.ApiStudio - HTTP APIsToolboxTab", // Unique identifier (non-localized) for the toolbox item tab.
						resourceManager.GetString("ApiStudio - HTTP APIsToolboxTab", resourceCulture), // Localized display name for the toolbox tab.
						"F1KeywordHttpApiDeleteTool", // F1 help keyword for the toolbox item.
						resourceManager.GetString("HttpApiDeleteToolToolboxTooltip", resourceCulture), // Localized tooltip text for the toolbox item.
						CreateElementToolPrototype(store, global::ApiStudioIO.HttpApiDelete.DomainClassId), // ElementGroupPrototype (data object) representing model element on the toolbox.
						new global::System.ComponentModel.ToolboxItemFilterAttribute[] { // Collection of ToolboxItemFilterAttribute objects that determine visibility of the toolbox item.
						new global::System.ComponentModel.ToolboxItemFilterAttribute(ToolboxFilterString, global::System.ComponentModel.ToolboxItemFilterType.Require) 
						});
					break;
				case "ApiStudioIO.HttpApiPatchToolToolboxItem":
					// Add HttpApiPatchTool shape tool.
					result = new DslDesign::ModelingToolboxItem(
						"ApiStudioIO.HttpApiPatchToolToolboxItem", // Unique identifier (non-localized) for the toolbox item.
						6, // Position relative to other items in the same toolbox tab.
						resourceManager.GetString("HttpApiPatchToolToolboxItem", resourceCulture), // Localized display name for the item.
						(global::System.Drawing.Bitmap)DslDiagrams::ImageHelper.GetImage(resourceManager.GetObject("HttpApiPatchToolToolboxBitmap", resourceCulture)), // Image displayed next to the toolbox item.
						"ApiStudioIO.ApiStudio - HTTP APIsToolboxTab", // Unique identifier (non-localized) for the toolbox item tab.
						resourceManager.GetString("ApiStudio - HTTP APIsToolboxTab", resourceCulture), // Localized display name for the toolbox tab.
						"F1KeywordApiGetTool", // F1 help keyword for the toolbox item.
						resourceManager.GetString("HttpApiPatchToolToolboxTooltip", resourceCulture), // Localized tooltip text for the toolbox item.
						CreateElementToolPrototype(store, global::ApiStudioIO.HttpApiPatch.DomainClassId), // ElementGroupPrototype (data object) representing model element on the toolbox.
						new global::System.ComponentModel.ToolboxItemFilterAttribute[] { // Collection of ToolboxItemFilterAttribute objects that determine visibility of the toolbox item.
						new global::System.ComponentModel.ToolboxItemFilterAttribute(ToolboxFilterString, global::System.ComponentModel.ToolboxItemFilterType.Require) 
						});
					break;
				case "ApiStudioIO.HttpApiHeadToolToolboxItem":
					// Add HttpApiHeadTool shape tool.
					result = new DslDesign::ModelingToolboxItem(
						"ApiStudioIO.HttpApiHeadToolToolboxItem", // Unique identifier (non-localized) for the toolbox item.
						7, // Position relative to other items in the same toolbox tab.
						resourceManager.GetString("HttpApiHeadToolToolboxItem", resourceCulture), // Localized display name for the item.
						(global::System.Drawing.Bitmap)DslDiagrams::ImageHelper.GetImage(resourceManager.GetObject("HttpApiHeadToolToolboxBitmap", resourceCulture)), // Image displayed next to the toolbox item.
						"ApiStudioIO.ApiStudio - HTTP APIsToolboxTab", // Unique identifier (non-localized) for the toolbox item tab.
						resourceManager.GetString("ApiStudio - HTTP APIsToolboxTab", resourceCulture), // Localized display name for the toolbox tab.
						"F1KeywordApiGetTool", // F1 help keyword for the toolbox item.
						resourceManager.GetString("HttpApiHeadToolToolboxTooltip", resourceCulture), // Localized tooltip text for the toolbox item.
						CreateElementToolPrototype(store, global::ApiStudioIO.HttpApiHead.DomainClassId), // ElementGroupPrototype (data object) representing model element on the toolbox.
						new global::System.ComponentModel.ToolboxItemFilterAttribute[] { // Collection of ToolboxItemFilterAttribute objects that determine visibility of the toolbox item.
						new global::System.ComponentModel.ToolboxItemFilterAttribute(ToolboxFilterString, global::System.ComponentModel.ToolboxItemFilterType.Require) 
						});
					break;
				case "ApiStudioIO.HttpApiOptionsToolToolboxItem":
					// Add HttpApiOptionsTool shape tool.
					result = new DslDesign::ModelingToolboxItem(
						"ApiStudioIO.HttpApiOptionsToolToolboxItem", // Unique identifier (non-localized) for the toolbox item.
						8, // Position relative to other items in the same toolbox tab.
						resourceManager.GetString("HttpApiOptionsToolToolboxItem", resourceCulture), // Localized display name for the item.
						(global::System.Drawing.Bitmap)DslDiagrams::ImageHelper.GetImage(resourceManager.GetObject("HttpApiOptionsToolToolboxBitmap", resourceCulture)), // Image displayed next to the toolbox item.
						"ApiStudioIO.ApiStudio - HTTP APIsToolboxTab", // Unique identifier (non-localized) for the toolbox item tab.
						resourceManager.GetString("ApiStudio - HTTP APIsToolboxTab", resourceCulture), // Localized display name for the toolbox tab.
						"F1KeywordApiGetTool", // F1 help keyword for the toolbox item.
						resourceManager.GetString("HttpApiOptionsToolToolboxTooltip", resourceCulture), // Localized tooltip text for the toolbox item.
						CreateElementToolPrototype(store, global::ApiStudioIO.HttpApiOptions.DomainClassId), // ElementGroupPrototype (data object) representing model element on the toolbox.
						new global::System.ComponentModel.ToolboxItemFilterAttribute[] { // Collection of ToolboxItemFilterAttribute objects that determine visibility of the toolbox item.
						new global::System.ComponentModel.ToolboxItemFilterAttribute(ToolboxFilterString, global::System.ComponentModel.ToolboxItemFilterType.Require) 
						});
					break;
				case "ApiStudioIO.HttpApiTraceToolToolboxItem":
					// Add HttpApiTraceTool shape tool.
					result = new DslDesign::ModelingToolboxItem(
						"ApiStudioIO.HttpApiTraceToolToolboxItem", // Unique identifier (non-localized) for the toolbox item.
						9, // Position relative to other items in the same toolbox tab.
						resourceManager.GetString("HttpApiTraceToolToolboxItem", resourceCulture), // Localized display name for the item.
						(global::System.Drawing.Bitmap)DslDiagrams::ImageHelper.GetImage(resourceManager.GetObject("HttpApiTraceToolToolboxBitmap", resourceCulture)), // Image displayed next to the toolbox item.
						"ApiStudioIO.ApiStudio - HTTP APIsToolboxTab", // Unique identifier (non-localized) for the toolbox item tab.
						resourceManager.GetString("ApiStudio - HTTP APIsToolboxTab", resourceCulture), // Localized display name for the toolbox tab.
						"F1KeywordApiGetTool", // F1 help keyword for the toolbox item.
						resourceManager.GetString("HttpApiTraceToolToolboxTooltip", resourceCulture), // Localized tooltip text for the toolbox item.
						CreateElementToolPrototype(store, global::ApiStudioIO.HttpApiTrace.DomainClassId), // ElementGroupPrototype (data object) representing model element on the toolbox.
						new global::System.ComponentModel.ToolboxItemFilterAttribute[] { // Collection of ToolboxItemFilterAttribute objects that determine visibility of the toolbox item.
						new global::System.ComponentModel.ToolboxItemFilterAttribute(ToolboxFilterString, global::System.ComponentModel.ToolboxItemFilterType.Require) 
						});
					break;
				case "ApiStudioIO.HttpApiRequestToolToolboxItem":

					// Add HttpApiRequestTool connector tool.
					result = new DslDesign::ModelingToolboxItem(
						"ApiStudioIO.HttpApiRequestToolToolboxItem", // Unique identifier (non-localized) for the toolbox item.
						10, // Position relative to other items in the same toolbox tab.
						resourceManager.GetString("HttpApiRequestToolToolboxItem", resourceCulture), // Localized display name for the item.
						(global::System.Drawing.Bitmap)DslDiagrams::ImageHelper.GetImage(resourceManager.GetObject("HttpApiRequestToolToolboxBitmap", resourceCulture)), // Image displayed next to the toolbox item.				
						"ApiStudioIO.ApiStudio - HTTP APIsToolboxTab", // Unique identifier (non-localized) for the toolbox item tab.
						resourceManager.GetString("ApiStudio - HTTP APIsToolboxTab", resourceCulture), // Localized display name for the toolbox tab.
						"F1KeywordHttpApiRequest", // F1 help keyword for the toolbox item.
						resourceManager.GetString("HttpApiRequestToolToolboxTooltip", resourceCulture), // Localized tooltip text for the toolbox item.
						null, // Connector toolbox items do not have an underlying data object.
						new global::System.ComponentModel.ToolboxItemFilterAttribute[] { // Collection of ToolboxItemFilterAttribute objects that determine visibility of the toolbox item.
							new global::System.ComponentModel.ToolboxItemFilterAttribute(ToolboxFilterString, global::System.ComponentModel.ToolboxItemFilterType.Require), 
							new global::System.ComponentModel.ToolboxItemFilterAttribute(HttpApiRequestToolFilterString)
						});
					break;
				case "ApiStudioIO.HttpApiResponseToolToolboxItem":

					// Add HttpApiResponseTool connector tool.
					result = new DslDesign::ModelingToolboxItem(
						"ApiStudioIO.HttpApiResponseToolToolboxItem", // Unique identifier (non-localized) for the toolbox item.
						11, // Position relative to other items in the same toolbox tab.
						resourceManager.GetString("HttpApiResponseToolToolboxItem", resourceCulture), // Localized display name for the item.
						(global::System.Drawing.Bitmap)DslDiagrams::ImageHelper.GetImage(resourceManager.GetObject("HttpApiResponseToolToolboxBitmap", resourceCulture)), // Image displayed next to the toolbox item.				
						"ApiStudioIO.ApiStudio - HTTP APIsToolboxTab", // Unique identifier (non-localized) for the toolbox item tab.
						resourceManager.GetString("ApiStudio - HTTP APIsToolboxTab", resourceCulture), // Localized display name for the toolbox tab.
						"F1KeywordHttpApiResponseStatusCode", // F1 help keyword for the toolbox item.
						resourceManager.GetString("HttpApiResponseToolToolboxTooltip", resourceCulture), // Localized tooltip text for the toolbox item.
						null, // Connector toolbox items do not have an underlying data object.
						new global::System.ComponentModel.ToolboxItemFilterAttribute[] { // Collection of ToolboxItemFilterAttribute objects that determine visibility of the toolbox item.
							new global::System.ComponentModel.ToolboxItemFilterAttribute(ToolboxFilterString, global::System.ComponentModel.ToolboxItemFilterType.Require), 
							new global::System.ComponentModel.ToolboxItemFilterAttribute(HttpApiResponseToolFilterString)
						});
					break;
				case "ApiStudioIO.DataModelToolToolboxItem":
					// Add DataModelTool shape tool.
					result = new DslDesign::ModelingToolboxItem(
						"ApiStudioIO.DataModelToolToolboxItem", // Unique identifier (non-localized) for the toolbox item.
						1, // Position relative to other items in the same toolbox tab.
						resourceManager.GetString("DataModelToolToolboxItem", resourceCulture), // Localized display name for the item.
						(global::System.Drawing.Bitmap)DslDiagrams::ImageHelper.GetImage(resourceManager.GetObject("DataModelToolToolboxBitmap", resourceCulture)), // Image displayed next to the toolbox item.
						"ApiStudioIO.ApiStudio - Data ModelToolboxTab", // Unique identifier (non-localized) for the toolbox item tab.
						resourceManager.GetString("ApiStudio - Data ModelToolboxTab", resourceCulture), // Localized display name for the toolbox tab.
						"F1KeywordDataModelTool", // F1 help keyword for the toolbox item.
						resourceManager.GetString("DataModelToolToolboxTooltip", resourceCulture), // Localized tooltip text for the toolbox item.
						CreateElementToolPrototype(store, global::ApiStudioIO.DataModel.DomainClassId), // ElementGroupPrototype (data object) representing model element on the toolbox.
						new global::System.ComponentModel.ToolboxItemFilterAttribute[] { // Collection of ToolboxItemFilterAttribute objects that determine visibility of the toolbox item.
						new global::System.ComponentModel.ToolboxItemFilterAttribute(ToolboxFilterString, global::System.ComponentModel.ToolboxItemFilterType.Require) 
						});
					break;
				default:
					break;
			} // end switch
			
			return result;
		}
		

		/// <summary>
		/// The store toe be used for all the toolbox item creation
		/// </summary>
		protected DslModeling::Store ToolboxStore
		{
			get
			{ 
				if (toolboxStore==null)
				{
					toolboxStore = new DslModeling::Store(this.ServiceProvider);
					EventHandler StoreCleanUp = (o, e) =>
					{
						//Since Store implements IDisposable, we need to dispose it when we're finished
						if (this.toolboxStore != null)
						{
							this.toolboxStore.Dispose();
						}
						this.toolboxStore = null;
					};
					//There is no DomainUnload event for the default AppDomain, so we listen for both ProcessExit and DomainUnload
					AppDomain.CurrentDomain.ProcessExit += new EventHandler(StoreCleanUp);
					AppDomain.CurrentDomain.DomainUnload += new EventHandler(StoreCleanUp);
					
					//load the domain model
					toolboxStore.LoadDomainModels(typeof(global::ApiStudioIO.ApiStudioIODomainModel));
					
				}
				return toolboxStore;
			}
		}
		
		/// <summary>
		/// Given a toolbox item "unique ID" returns the the toolbox item using cached dictionary
		/// </summary>
		/// <param name="itemId">The unique ToolboxItem to retrieve</param>
		private DslDesign::ModelingToolboxItem GetToolboxItem(string itemId)
		{
			DslDesign::ModelingToolboxItem item = null;

			if (!this.toolboxItemCache.TryGetValue(itemId, out item))
			{
				DslModeling::Store store = this.ToolboxStore;
				
				// Open transaction so we can create model elements corresponding to toolbox items.
				using (DslModeling::Transaction t = store.TransactionManager.BeginTransaction("CreateToolboxItems"))
				{
					// Retrieve the specified ToolboxItem from the DSL
					this.toolboxItemCache[itemId] = item = this.GetToolboxItem(itemId, store);
				}
			}

			return item;
		}
		
		/// <summary>
		/// Given a toolbox item "unique ID" and a data format identifier, returns the content of
		/// the data format. 
		/// </summary>
		/// <param name="itemId">The unique ToolboxItem to retrieve data for</param>
		/// <param name="format">The desired format of the resulting data</param>
		public virtual object GetToolboxItemData(string itemId, DataFormats.Format format)
		{
			DslDesign::ModelingToolboxItem item = null;

			global::System.Resources.ResourceManager resourceManager = global::ApiStudioIO.ApiStudioIODomainModel.SingletonResourceManager;
			global::System.Globalization.CultureInfo resourceCulture = global::System.Globalization.CultureInfo.CurrentUICulture;

			System.Windows.Forms.IDataObject tbxDataObj;

			//get the toolbox item
			item = GetToolboxItem(itemId);

			if (item != null)
			{
				ToolboxItemContainer container = new ToolboxItemContainer(item);
				tbxDataObj = container.ToolboxData;

				if (tbxDataObj.GetDataPresent(format.Name))
				{
					return tbxDataObj.GetData(format.Name);
				}
				else 
				{
					string invalidFormatString = resourceManager.GetString("UnsupportedToolboxFormat", resourceCulture);
					throw new InvalidOperationException(string.Format(resourceCulture, invalidFormatString, format.Name));
				}
			}

			string errorFormatString = resourceManager.GetString("UnresolvedToolboxItem", resourceCulture);
			throw new InvalidOperationException(string.Format(resourceCulture, errorFormatString, itemId));
		}		
	}
}
