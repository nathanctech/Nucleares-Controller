using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuclearesController
{
    internal class DataSourcePayload(string ev, JArray items)
    {
        public string Event { get; init; } = ev;
        public JArray Items { get; set; } = items;
        public JObject ToJson()
        {
            JObject payload = new()
            {
                ["event"] = Event,
                ["items"] = Items
            };
            return payload;
        }
    }

    internal class DataSourceResultItem
    {
        [JsonProperty("label")]
        public required string Label { get; set; }
        [JsonProperty("value")]
        public required string Value { get; set; }
        [JsonProperty("disabled")]
        public bool Disabled { get; set; } = false;
    }

    public class SendToPluginEventPayload
    {
        [JsonProperty(PropertyName = "event")]
        public required string Event { get; set; }
        [JsonProperty(PropertyName = "isRefresh")]
        public bool IsRefresh { get; set; }
    }
}