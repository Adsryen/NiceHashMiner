﻿using MinerPluginToolkitV1.Configs;
using MinerPluginToolkitV1.Interfaces;
using Newtonsoft.Json;
using NHM.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHMCore.Mining.Plugins
{
    internal static class MinerPluginsUpdaterSettings
    {
        private class SupportedAlgorithmsFilterSettingsFile : IInternalSetting
        {
            [JsonProperty("use_user_settings")]
            public bool UseUserSettings { get; set; } = false;

            [JsonProperty("filtered_algorithms")]
            public TimeSpan CheckPluginsInterval = TimeSpan.FromMinutes(30);
        }

        static SupportedAlgorithmsFilterSettingsFile _settings = new SupportedAlgorithmsFilterSettingsFile();

        static MinerPluginsUpdaterSettings()
        {
            var fileSettings = InternalConfigs.InitInternalSetting(Paths.Root, _settings, "MinerPluginsUpdaterSettings.json");
            if (fileSettings != null) _settings = fileSettings;
        }

        public static TimeSpan CheckPluginsInterval => _settings.CheckPluginsInterval;
    }
}