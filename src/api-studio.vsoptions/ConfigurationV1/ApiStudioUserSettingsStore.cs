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

using ApiStudioIO.VsOptions.ConfigurationV1.Models;
using Microsoft.VisualStudio.Settings;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Settings;
using Newtonsoft.Json;

namespace ApiStudioIO.VsOptions.ConfigurationV1
{
    public sealed class ApiStudioUserSettingsStore
    {
        private readonly string COLLECTION_NAME = "api-studio";
        private readonly string PROPERTY_NAME = "configuration-v1";

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

            if (!userSettingsStore.PropertyExists(COLLECTION_NAME, PROPERTY_NAME))
            {
                ResetDefaults();
                return;
            }

            var stored = userSettingsStore.GetString(COLLECTION_NAME, PROPERTY_NAME);
            Data = JsonConvert.DeserializeObject<ApiStudioOptions>(stored);
        }

        public void VsOptionStoreSave()
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            var settingsManager = new ShellSettingsManager(ServiceProvider.GlobalProvider);
            var userSettingsStore = settingsManager.GetWritableSettingsStore(SettingsScope.UserSettings);

            if (!userSettingsStore.CollectionExists(COLLECTION_NAME))
                userSettingsStore.CreateCollection(COLLECTION_NAME);

            var store = JsonConvert.SerializeObject(Data, Formatting.Indented);

            userSettingsStore.SetString(COLLECTION_NAME, PROPERTY_NAME, store);
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