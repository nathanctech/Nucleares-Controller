using BarRaider.SdTools;
using BarRaider.SdTools.Events;
using BarRaider.SdTools.Wrappers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuclearesController
{
    [PluginActionId("com.nucleares.controller.commandkey")]
    public class CommandKeyAction : KeypadBase
    {
        private class PluginSettings
        {
            [JsonProperty(PropertyName = "selectedCommand")]
            public string SelectedCommand { get; set; } = string.Empty;

            [JsonProperty(PropertyName = "commands")]
            public static List<Command> CommandList = Commands.CommandList;
            public static PluginSettings CreateDefaultSettings()
            {
                return new PluginSettings
                {
                    SelectedCommand = "None"
                };
            }
        }

        private PluginSettings settings;

        private Command SelectedCommand => PluginSettings.CommandList.First(c => c.CommandKey == settings.SelectedCommand);
        public CommandKeyAction(ISDConnection connection, InitialPayload payload) : base(connection, payload)
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

        private void Connection_OnSendToPlugin(object? sender, SDEventReceivedEventArgs<SendToPlugin> e)
        {
            var payload = JsonConvert.DeserializeObject<SendToPluginEventPayload>(e.Event.Payload.ToString());
            Logger.Instance.LogMessage(TracingLevel.INFO, $"Received SendToPlugin event: {e.Event} - {e.Event.Payload}");
            if (payload != null && payload.Event == "getCommands")
            {
                var commands = PluginSettings.CommandList.Select(c => new DataSourceResultItem
                {
                    Label = c.CommandName,
                    Value = c.CommandKey,
                    Disabled = false
                }).ToList();
                var dataSourcePayload = new DataSourcePayload("getCommands", Commands.GeneratePIPayload());
                Logger.Instance.LogMessage(TracingLevel.INFO, $"Sending commands to property inspector: {JsonConvert.SerializeObject(dataSourcePayload)}");
                Connection.SendToPropertyInspectorAsync(dataSourcePayload.ToJson());
            }
        }

        public override void Dispose()
        {
            Connection.OnSendToPlugin -= Connection_OnSendToPlugin;
        }

        

        public override void KeyPressed(KeyPayload payload)
        {
            if (SelectedCommand.CommandKey == "None")
            {
                Logger.Instance.LogMessage(TracingLevel.INFO, "No command selected");
                Connection.ShowAlert();
                return;
            }
            var task = SelectedCommand.CommandAction.Invoke();
            task?.ContinueWith(t =>
                {
                    if (t.IsFaulted)
                    {
                        Logger.Instance.LogMessage(TracingLevel.ERROR, $"Error executing command: {t.Exception}");
                        Connection.ShowAlert();
                    }
                    else if (t.IsCompleted)
                    {
                        Logger.Instance.LogMessage(TracingLevel.INFO, $"Command executed successfully");
                        Connection.ShowOk();
                    }
                });
        }

        public override void KeyReleased(KeyPayload payload)
        {
        }

        public override void OnTick()
        {
        }

        public override void ReceivedGlobalSettings(ReceivedGlobalSettingsPayload payload)
        {
        }

        public override void ReceivedSettings(ReceivedSettingsPayload payload)
        {
            Logger.Instance.LogMessage(TracingLevel.INFO, $"Received Settings: {JsonConvert.SerializeObject(payload.Settings)}");
            Tools.AutoPopulateSettings(settings, payload.Settings);
            Connection.SetTitleAsync(SelectedCommand.CommandName);
            SaveSettings();
        }

        private Task SaveSettings()
        {
            return Connection.SetSettingsAsync(JObject.FromObject(settings));
        }
    }
}
