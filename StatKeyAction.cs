using BarRaider.SdTools;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NukeWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuclearesController
{
    [PluginActionId("com.nucleares.controller.statkey")]
    public class StatKeyAction : KeypadBase
    {
        private class PluginSettings
        {
            public static PluginSettings CreateDefaultSettings()
            {
                PluginSettings instance = new PluginSettings();
                instance.SelectedStatKey = "None";
                return instance;
            }

            [JsonProperty(PropertyName = "statKey")]
            public string SelectedStatKey { get; set; } = "None";

            [JsonProperty(PropertyName = "customStatName")]
            public string CustomStatName { get; set; } = "";

            [JsonProperty(PropertyName = "animated")]
            public bool Animated { get; set; } = false;

            [JsonProperty(PropertyName = "color")]
            public string Color { get; set; } = "#000000";

            [JsonProperty(PropertyName = "threshold")]
            public string Threshold { get; set; } = "0";

            [JsonProperty(PropertyName = "threshold_type")]
            public string ThresholdType { get; set; } = "Above";
        }

        #region Private Members

        private PluginSettings settings;
        private static string KeyTemplate => System.IO.File.ReadAllText("Images/statKey.svg");

        public Stat? SelectedStat => Stats.StatsList.Find(stat => stat.VariableKey == settings.SelectedStatKey) ?? null;
        public string SelectedStatName => SelectedStat != null ? settings.CustomStatName != "" ? settings.CustomStatName : SelectedStat.VariableName : "N/A";
        public string SelectedStatValue => SelectedStat != null ? SelectedStat.GetValue().Invoke(0).Result : "N/A";

        #endregion
        public StatKeyAction(SDConnection connection, InitialPayload payload) : base(connection, payload)
        {
            if (payload.Settings == null || payload.Settings.Count == 0)
            {
                this.settings = PluginSettings.CreateDefaultSettings();
                SaveSettings();
            }
            else
            {
                this.settings = payload.Settings.ToObject<PluginSettings>()!;
            }
            Connection.OnSendToPlugin += Connection_OnSendToPlugin;
        }

        

        private void Connection_OnSendToPlugin(object? sender, BarRaider.SdTools.Wrappers.SDEventReceivedEventArgs<BarRaider.SdTools.Events.SendToPlugin> e)
        {
            Logger.Instance.LogMessage(TracingLevel.INFO, $"Received SendToPlugin event: {e.Event} - {e.Event.Payload}");
            var payload = JsonConvert.DeserializeObject<SendToPluginEventPayload>(e.Event.Payload.ToString());
            if (payload != null && payload.Event == "getStats")
            {
                var dataSourcePayload = new DataSourcePayload("getStats", Stats.BuildPIPayload());
                Connection.SendToPropertyInspectorAsync(dataSourcePayload.ToJson()).Wait();
            }
            else
            {
                Logger.Instance.LogMessage(TracingLevel.INFO, $"Ignored SendToPlugin event: {e.Event} - {e.Event.Payload}");
            }
        }

        public override void Dispose()
        {
            Logger.Instance.LogMessage(TracingLevel.INFO, $"Destructor called");
            Connection.OnSendToPlugin -= Connection_OnSendToPlugin;
        }

        public override void KeyPressed(KeyPayload payload)
        {
            Logger.Instance.LogMessage(TracingLevel.INFO, "Key Pressed");
          //  Connection.SetImageAsync(GetSvg("Core Temp", "360 C")).Wait();
        }

        

        private string GetSvg(string line1 = "", string line2 = "")
        {
            var color = "#000000";
            if (settings.ThresholdType == "Above")
            {
                if (float.TryParse(SelectedStatValue, out float value) && value > float.Parse(settings.Threshold))
                {
                    color = settings.Color;
                }
            }
            else if (settings.ThresholdType == "Below")
            {
                if (float.TryParse(SelectedStatValue, out float value) && value < float.Parse(settings.Threshold))
                {
                    color = settings.Color;
                }
            }
            // replace text
            var template = KeyTemplate.Replace("TITLE", line1.Truncate(10)).Replace("VALUE", line2).Replace("{{color}}", color);
            //   Logger.Instance.LogMessage(TracingLevel.INFO, $"SVG: {template}");
            // URI encode
            template = Uri.EscapeDataString(template);
            // encode as data URI
            template = "data:image/svg+xml," + template;

            return template;
        }

        public override void KeyReleased(KeyPayload payload) { }

        public override void OnTick()
        {
            if (!Request.Reachable())
            {
                Connection.SetImageAsync(GetSvg("Not", "Connected")).Wait();
                return;
            }
            var port = Request.PortOpen();
            if (port != "OK")
            {
                Connection.SetImageAsync(GetSvg("Port", "Not Open")).Wait();
                return;
            }
            //Logger.Instance.LogMessage(TracingLevel.INFO, "Tick");
            Connection.SetImageAsync(GetSvg(SelectedStatName, SelectedStatValue)).Wait();
        }

        public override void ReceivedSettings(ReceivedSettingsPayload payload)
        {
            Logger.Instance.LogMessage(TracingLevel.INFO, $"Received Settings: {JsonConvert.SerializeObject(payload.Settings)}");
            Tools.AutoPopulateSettings(settings, payload.Settings);
            SaveSettings();
        }

        public override void ReceivedGlobalSettings(ReceivedGlobalSettingsPayload payload) { }

        #region Private Methods

        private Task SaveSettings()
        {
            return Connection.SetSettingsAsync(JObject.FromObject(settings));
        }

        #endregion
    }
}