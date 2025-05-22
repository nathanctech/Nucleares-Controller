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
    public class Command
    {
        [JsonProperty("commandName")]
        public required string CommandName { get; init; }
        [JsonProperty("commandKey")]
        public required string CommandKey { get; init; }
        [JsonProperty("commandAction")]
        public required Func<Task<string>> CommandAction { get; init; }
        public string GroupName { get; set; } = "None";
    }

    public static class Commands
    {
        public static List<Command> CommandList =>
        [
            new Command { CommandName = "None", CommandKey = "None", CommandAction = () => Task.FromResult("") },
            new Command { CommandName = "SCRAM", CommandKey = "SCRAM", CommandAction = NukeWeb.Settables.General.SCRAM }
        ];

        public static JArray GeneratePIPayload()
        {
            var payload = new JArray
            {
                ["items"] = new JArray(
                    CommandList.Select(c => new JObject
                    {
                        ["label"] = c.CommandName,
                        ["value"] = c.CommandKey,
                        ["disabled"] = false
                    }))
            };
            return payload;
        }
    }
}
