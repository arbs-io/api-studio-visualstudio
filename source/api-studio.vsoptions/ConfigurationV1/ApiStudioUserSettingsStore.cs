namespace ApiStudioIO.VsOptions.ConfigurationV1
{
    using ApiStudioIO.VsOptions.ConfigurationV1.Models;
    using Microsoft.VisualStudio.Settings;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Shell.Settings;
    using Newtonsoft.Json;

    public sealed class ApiStudioUserSettingsStore
    {
        private readonly string COLLECTION_NAME = "api-studio";
        private readonly string PROPERTY_NAME = "configuration-v1";

        #region Singleton
        //This should be readonly but we want to load from visual studion
        private static readonly ApiStudioUserSettingsStore instance = new ApiStudioUserSettingsStore();

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

        public ApiStudioOptions Data { get; set; }
    }
}
