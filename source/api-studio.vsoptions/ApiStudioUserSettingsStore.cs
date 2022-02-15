namespace ApiStudioIO.VsOptions
{
    using Microsoft.VisualStudio.Settings;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Shell.Settings;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public sealed class ApiStudioUserSettingsStore
    {
        #region Singleton
        //This should be readonly but we want to load from visual studion
        private static ApiStudioUserSettingsStore instance = new ApiStudioUserSettingsStore();
        static ApiStudioUserSettingsStore()
        {
        }
        private ApiStudioUserSettingsStore()
        {
        }
        public static ApiStudioUserSettingsStore Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion Singleton

        #region Visual Studio Interop
        private const string collectionName = "ApiStudio";
        private const string propertyName = "Configuration";

        public void Load()
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            var settingsManager = new ShellSettingsManager(ServiceProvider.GlobalProvider);
            var userSettingsStore = settingsManager.GetWritableSettingsStore(SettingsScope.UserSettings);

            if (!userSettingsStore.PropertyExists(collectionName, propertyName))
            {
                // Set and Cancelled so just reset and forget. Defaults are:
                //  (400) Bad Request, (401) Authentication, (403) Forbidden, (404) Not Found, 
                //  (405) Not Allowed, (415) Unsupported MediaType, (422) Unprocessable, (500) Server Error
                ResponseCodes = new List<int>() { 400, 401, 403, 404, 415, 422, 500 };
                return;
            }

            var stored = userSettingsStore.GetString(collectionName, propertyName);
            instance = JsonConvert.DeserializeObject<ApiStudioUserSettingsStore>(stored);
        }

        public void Save()
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            var settingsManager = new ShellSettingsManager(ServiceProvider.GlobalProvider);
            var userSettingsStore = settingsManager.GetWritableSettingsStore(SettingsScope.UserSettings);

            if (!userSettingsStore.CollectionExists(collectionName))
                userSettingsStore.CreateCollection(collectionName);

            var store = JsonConvert.SerializeObject(this, Formatting.Indented);

            userSettingsStore.SetString(collectionName, propertyName, store);
        }
        #endregion Visual Studio Interop

        [JsonProperty("response_codes")]
        public List<int> ResponseCodes { get; set; } = new List<int>();

    }
}
