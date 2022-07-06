// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System;
using System.Runtime.InteropServices;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;

namespace ApiStudioIO.Vs.Services
{
    public class ServiceProviderHelper
    {
        private static DTE2 _dte;

        private static DTE2 SDte => _dte ?? (_dte = ServiceProvider.GlobalProvider.GetService(typeof(DTE)) as DTE2);

        public static ServiceProviderHelper Instance { get; set; }
        private ServiceProviderHelper() {}

        public static DTE2 DevelopmentToolsEnvironment => SDte;

        public static object GetGlobalService(Type type)
        {
            return GetService(GlobalServiceProvider, type.GUID, false);
        }

        public static T GetGlobalService<T>(Type type = null) where T : class
        {
            return GetGlobalService(type ?? typeof(T)) as T;
        }

        private static Microsoft.VisualStudio.OLE.Interop.IServiceProvider _globalServiceProvider;
        private static Microsoft.VisualStudio.OLE.Interop.IServiceProvider GlobalServiceProvider
        {
            get
            {
                if (_globalServiceProvider == null)
                {
                    _globalServiceProvider = (Microsoft.VisualStudio.OLE.Interop.IServiceProvider)Package.GetGlobalService(
                        typeof(Microsoft.VisualStudio.OLE.Interop.IServiceProvider));
                }

                return _globalServiceProvider;
            }
        }

        private static object GetService(Microsoft.VisualStudio.OLE.Interop.IServiceProvider serviceProvider, Guid guidService, bool unique)
        {
#pragma warning disable IDE0018 //Inline variable declaration (IDE0018)
            var guidInterface = VSConstants.IID_IUnknown;
            IntPtr ptr;
            object service = null;

            if (serviceProvider.QueryService(ref guidService, ref guidInterface, out ptr) == 0 &&
                ptr != IntPtr.Zero)
            {
                try
                {
                    if (unique)
                    {
                        service = Marshal.GetUniqueObjectForIUnknown(ptr);
                    }
                    else
                    {
                        service = Marshal.GetObjectForIUnknown(ptr);
                    }
                }
                finally
                {
                    Marshal.Release(ptr);
                }
            }

            return service;
#pragma warning restore IDE0018
        }
    }
}
