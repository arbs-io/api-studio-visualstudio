namespace ApiStudioIO.VsOptions.ConfigurationV1
{
    using ApiStudioIO.VsOptions.ConfigurationV1.Models;
    using Microsoft.VisualStudio.Settings;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Shell.Settings;
    using Newtonsoft.Json;

    public sealed class ApiStudioUserSettingsStore
    {
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


        public void Load()
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            var settingsManager = new ShellSettingsManager(ServiceProvider.GlobalProvider);
            var userSettingsStore = settingsManager.GetWritableSettingsStore(SettingsScope.UserSettings);

            if (!userSettingsStore.PropertyExists(ConfigurationV1Consts.CollectionName, ConfigurationV1Consts.PropertyName))
            {
                ResetDefaults();
                return;
            }

            var stored = userSettingsStore.GetString(ConfigurationV1Consts.CollectionName, ConfigurationV1Consts.PropertyName);
            Data = JsonConvert.DeserializeObject<ApiStudioOptions>(stored);
        }

        public void Save()
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            var settingsManager = new ShellSettingsManager(ServiceProvider.GlobalProvider);
            var userSettingsStore = settingsManager.GetWritableSettingsStore(SettingsScope.UserSettings);

            if (!userSettingsStore.CollectionExists(ConfigurationV1Consts.CollectionName))
                userSettingsStore.CreateCollection(ConfigurationV1Consts.CollectionName);

            var store = JsonConvert.SerializeObject(Data, Formatting.Indented);

            userSettingsStore.SetString(ConfigurationV1Consts.CollectionName, ConfigurationV1Consts.PropertyName, store);
        }

        public void ResetDefaults()
        {
            Data.DefaultResponseCodes.LoadDefaults();
        }
        #endregion Visual Studio Interop

        public ApiStudioOptions Data { get; private set; } = new ApiStudioOptions();
    }
}
