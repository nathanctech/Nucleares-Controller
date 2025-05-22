using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NukeWeb.Variables
{
    public class Turbines
    {
        /*
         * STEAM_TURBINE_0_RPM
STEAM_TURBINE_1_RPM
STEAM_TURBINE_2_RPM
STEAM_TURBINE_0_TEMPERATURE
STEAM_TURBINE_1_TEMPERATURE
STEAM_TURBINE_2_TEMPERATURE
STEAM_TURBINE_0_PRESSURE
STEAM_TURBINE_1_PRESSURE
STEAM_TURBINE_2_PRESSURE
STEAM_GEN_0_EVAPORATED
STEAM_GEN_0_INLET
STEAM_GEN_0_OUTLET
STEAM_GEN_1_EVAPORATED
STEAM_GEN_1_INLET
STEAM_GEN_1_OUTLET
STEAM_GEN_2_EVAPORATED
STEAM_GEN_2_INLET
STEAM_GEN_2_OUTLET
        STEAM_TURBINE_0_BYPASS_ACTUAL
        STEAM_TURBINE_1_BYPASS_ACTUAL
        STEAM_TURBINE_2_BYPASS_ACTUAL
        */
        public static async Task<string> Rpm(int turbine)
        {
            if (turbine < 0 || turbine > 2)
                throw new ArgumentOutOfRangeException(nameof(turbine), "Turbine index must be between 0 and 2.");
            return await Request.Get($"STEAM_TURBINE_{turbine}_RPM");
        }
        public static async Task<string> Temperature(int turbine)
        {
            if (turbine < 0 || turbine > 2)
                throw new ArgumentOutOfRangeException(nameof(turbine), "Turbine index must be between 0 and 2.");
            return await Request.Get($"STEAM_TURBINE_{turbine}_TEMPERATURE");
        }
        public static async Task<string> Pressure(int turbine)
        {
            if (turbine < 0 || turbine > 2)
                throw new ArgumentOutOfRangeException(nameof(turbine), "Turbine index must be between 0 and 2.");
            return await Request.Get($"STEAM_TURBINE_{turbine}_PRESSURE");
        }
        public static async Task<string> BypassActual(int turbine)
        {
            if (turbine < 0 || turbine > 2)
                throw new ArgumentOutOfRangeException(nameof(turbine), "Turbine index must be between 0 and 2.");
            return await Request.Get($"STEAM_TURBINE_{turbine}_BYPASS_ACTUAL");
        }
        public static async Task<string> SteamGenEvaporated(int generator)
        {
            if (generator < 0 || generator > 2)
                throw new ArgumentOutOfRangeException(nameof(generator), "Generator index must be between 0 and 2.");
            return await Request.Get($"STEAM_GEN_{generator}_EVAPORATED");
        }
        public static async Task<string> SteamGenInlet(int generator)
        {
            if (generator < 0 || generator > 2)
                throw new ArgumentOutOfRangeException(nameof(generator), "Generator index must be between 0 and 2.");
            return await Request.Get($"STEAM_GEN_{generator}_INLET");
        }
        public static async Task<string> SteamGenOutlet(int generator)
        {
            if (generator < 0 || generator > 2)
                throw new ArgumentOutOfRangeException(nameof(generator), "Generator index must be between 0 and 2.");
            return await Request.Get($"STEAM_GEN_{generator}_OUTLET");
        }
    }
}
