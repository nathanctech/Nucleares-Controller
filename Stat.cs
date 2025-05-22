using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NukeWeb;
using NukeWeb.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuclearesController
{

    public class Stat(string varKey, string varName, Func<int, Task<string>> getAction, string groupName = "None")
    {
        [JsonProperty("variableName")]
        public string VariableName { get; private set; } = varName;
        [JsonProperty("variableKey")]
        public string VariableKey { get; private set; } = varKey;

        public Func<int, Task<string>> GetValue() => getAction;
        public string GroupName { get; set; } = groupName;
    }

    public static class Stats
    {
        public static List<Stat> StatsList =>
           [
                new Stat("None", "None", (num) => Task.FromResult("")),
                new Stat("CoreTemp", "Core Temperature", (num) => Core.CoreTemp(), "Core"),
                new Stat("CorePressure", "Core Pressure", (num) => Core.CorePressure(), "Core"),
                new Stat("CoreWear", "Core Wear", (num) => Core.CoreWear(), "Core"),
                new Stat("CoreIodineGen", "Iodine Generation", (num) => Core.CoreIodineGeneration(), "Core"),
                new Stat("CoreIodineCumul", "Cumulative Iodine", (num) => Core.CoreIodineCumulative(), "Core"),
                new Stat("CoreXenonGen", "Xenon Generation", (num) => Core.CoreXenonGeneration(), "Core"),
                new Stat("CoreXenonCumul", "Cumulative Xenon", (num) => Core.CoreXenonCumulative(), "Core"),
                new Stat("CoreIntegrity", "Integrity", (num) => Core.CoreIntegrity(), "Core"),

                new Stat("RodPosition", "Rod Position", (num) => ControlRods.PosActual(), "Control Rods"),
                new Stat("RodPositionSet", "Rod Position Set", (num) => ControlRods.PosOrdered(), "Control Rods"),
                new Stat("RodStatus", "Rod Status", (num) => ControlRods.Status(), "Control Rods"),
                new Stat("RodMovementSpeed", "Rod Movement Speed", (num) => ControlRods.MovementSpeed(), "Control Rods"),

                new Stat("CorePumpSpeed1", "Core Pump Speed A", (num) => Coolant.CoreCirculationPumpSpeed(0), "Coolant"),
                new Stat("CorePumpSpeed2", "Core Pump Speed B", (num) => Coolant.CoreCirculationPumpSpeed(1), "Coolant"),
                new Stat("CorePumpSpeed3", "Core Pump Speed C", (num) => Coolant.CoreCirculationPumpSpeed(2), "Coolant"),
                new Stat("SecPumpSpeed1", "Secondary Pump Speed A", (num) => Coolant.SecCirculationPumpSpeed(0), "Coolant"),
                new Stat("SecPumpSpeed2", "Secondary Pump Speed B", (num) => Coolant.SecCirculationPumpSpeed(1), "Coolant"),
                new Stat("SecPumpSpeed3", "Secondary Pump Speed C", (num) => Coolant.SecCirculationPumpSpeed(2), "Coolant"),
                new Stat("SGCoolantVolume1", "Steam Gen Coolant Volume A", (num) => Coolant.SecVolume(0), "Coolant"),
                new Stat("SGCoolantVolume2", "Steam Gen Coolant Volume B", (num) => Coolant.SecVolume(1), "Coolant"),
                new Stat("SGCoolantVolume3", "Steam Gen Coolant Volume C", (num) => Coolant.SecVolume(2), "Coolant"),

                new Stat("Turbine0RPM", "Turbine 0 RPM", (num) => Turbines.Rpm(0), "Turbines"),
                new Stat("Turbine1RPM", "Turbine 1 RPM", (num) => Turbines.Rpm(1), "Turbines"),
                new Stat("Turbine2RPM", "Turbine 2 RPM", (num) => Turbines.Rpm(2), "Turbines"),
                new Stat("Turbine0Temperature", "Turbine 0 Temperature", (num) => Turbines.Temperature(0), "Turbines"),
                new Stat("Turbine1Temperature", "Turbine 1 Temperature", (num) => Turbines.Temperature(1), "Turbines"),
                new Stat("Turbine2Temperature", "Turbine 2 Temperature", (num) => Turbines.Temperature(2), "Turbines"),
                new Stat("Turbine0Pressure", "Turbine 0 Pressure", (num) => Turbines.Pressure(0), "Turbines"),
                new Stat("Turbine1Pressure", "Turbine 1 Pressure", (num) => Turbines.Pressure(1), "Turbines"),
                new Stat("Turbine2Pressure", "Turbine 2 Pressure", (num) => Turbines.Pressure(2), "Turbines"),
                new Stat("Turbine0BypassActual", "Turbine 0 Bypass Actual", (num) => Turbines.BypassActual(0), "Turbines"),
                new Stat("Turbine1BypassActual", "Turbine 1 Bypass Actual", (num) => Turbines.BypassActual(1), "Turbines"),
                new Stat("Turbine2BypassActual", "Turbine 2 Bypass Actual", (num) => Turbines.BypassActual(2), "Turbines"),
                new Stat("SteamGen0Evaporated", "Steam Gen 0 Evaporated", (num) => Turbines.SteamGenEvaporated(0), "Turbines"),
                new Stat("SteamGen0Inlet", "Steam Gen 0 Inlet", (num) => Turbines.SteamGenInlet(0), "Turbines"),
                new Stat("SteamGen0Outlet", "Steam Gen 0 Outlet", (num) => Turbines.SteamGenOutlet(0), "Turbines"),
                new Stat("SteamGen1Evaporated", "Steam Gen 1 Evaporated", (num) => Turbines.SteamGenEvaporated(1), "Turbines"),
                new Stat("SteamGen1Inlet", "Steam Gen 1 Inlet", (num) => Turbines.SteamGenInlet(1), "Turbines"),
                new Stat("SteamGen1Outlet", "Steam Gen 1 Outlet", (num) => Turbines.SteamGenOutlet(1), "Turbines"),
                new Stat("SteamGen2Evaporated", "Steam Gen 2 Evaporated", (num) => Turbines.SteamGenEvaporated(2), "Turbines"),
                new Stat("SteamGen2Inlet", "Steam Gen 2 Inlet", (num) => Turbines.SteamGenInlet(2), "Turbines"),
                new Stat("SteamGen2Outlet", "Steam Gen 2 Outlet", (num) => Turbines.SteamGenOutlet(2), "Turbines"),

                new Stat("PowerDemand", "Power Demand", (num) => Generators.GetPowerDemand(), "Power"),
                new Stat("PowerProduced", "Power Produced", (num) => Generators.GetPowerProduced(), "Power"),
                new Stat("PowerMaxOutpuut", "Maximum Output", (num) => Generators.GetMaxPlantOutput(), "Power"),
                new Stat("PowerDiverted", "Resistor Bank Use", (num) => Generators.ResEffectivelyDerivedEnergyMw(), "Power"),
           ];
        public static JArray BuildPIPayload()
        {
            JArray statsArray = [];
            List<string> statGroups = [];
            foreach (var stat in StatsList)
            {
                if (stat.GroupName != "None" && !statGroups.Contains(stat.GroupName))
                {
                    statGroups.Add(stat.GroupName);
                }
            }
            foreach(var group in statGroups)
            {
                JObject groupJson = new JObject
                {
                    ["label"] = group
                };
                JArray itemsArray = [];
                foreach (var stat in StatsList)
                {
                    if (stat.GroupName == group)
                    {
                        JObject itemJson = new JObject();
                        itemJson["label"] = stat.VariableName;
                        itemJson["value"] = stat.VariableKey;
                        itemsArray.Add(itemJson);
                    }
                }
                groupJson["children"] = itemsArray;
                statsArray.Add(groupJson);
            }
            // Add a "None" item to the statsArray
            JObject noneJson = new JObject
            {
                ["label"] = "None",
                ["value"] = "None"
            };
            statsArray.Add(noneJson);
            return statsArray;
        }
    }
}
