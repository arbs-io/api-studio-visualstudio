// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using ApiStudioIO.Vs.Options.Models;
using Microsoft.VisualStudio.Settings;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Settings;
using Newtonsoft.Json;

namespace ApiStudioIO.Vs.Options
{
    public sealed class ApiStudioUserSettingsStore
    {
        private const string CollectionName = "api-studio";
        private const string PropertyName = "configuration-v1";

        private ApiStudioOptions _data;

        public ApiStudioOptions Data
        {
            get
            {
                if (_data == null)
                    VsOptionStoreLoad();
                return _data;
            }
            set => _data = value;
        }

        #region Singleton

        //This should be readonly but we want to load from visual studio

        static ApiStudioUserSettingsStore()
        {
        }

        private ApiStudioUserSettingsStore()
        {
        }

        public static ApiStudioUserSettingsStore Instance { get; } = new ApiStudioUserSettingsStore();

        #endregion Singleton

        #region Visual Studio Interop

        public void VsOptionStoreLoad()
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            var settingsManager = new ShellSettingsManager(ServiceProvider.GlobalProvider);
            var userSettingsStore = settingsManager.GetWritableSettingsStore(SettingsScope.UserSettings);

            if (!userSettingsStore.PropertyExists(CollectionName, PropertyName))
            {
                ResetDefaults();
                return;
            }

            var stored = userSettingsStore.GetString(CollectionName, PropertyName);
            Data = JsonConvert.DeserializeObject<ApiStudioOptions>(stored);
        }

        public void VsOptionStoreSave()
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            var settingsManager = new ShellSettingsManager(ServiceProvider.GlobalProvider);
            var userSettingsStore = settingsManager.GetWritableSettingsStore(SettingsScope.UserSettings);

            if (!userSettingsStore.CollectionExists(CollectionName))
                userSettingsStore.CreateCollection(CollectionName);

            var store = JsonConvert.SerializeObject(Data, Formatting.Indented);

            userSettingsStore.SetString(CollectionName, PropertyName, store);
        }


        public string ExportVsOption()
        {
            return JsonConvert.SerializeObject(Data, Formatting.Indented);
        }

        public void ImportVsOption(string json)
        {
            Data = JsonConvert.DeserializeObject<ApiStudioOptions>(json);
            VsOptionStoreSave();
        }

        public void ResetDefaults()
        {
            Data = new ApiStudioOptions();
            Data.LoadDefaults();
            VsOptionStoreSave();
        }

        #endregion Visual Studio Interop
    }
}