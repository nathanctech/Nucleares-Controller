using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NukeWeb.Variables
{
    public class Core
    {
        /* CORE_TEMP
CORE_TEMP_OPERATIVE
CORE_TEMP_MAX
CORE_TEMP_MIN
CORE_TEMP_RESIDUAL
CORE_PRESSURE
CORE_PRESSURE_MAX
CORE_PRESSURE_OPERATIVE
CORE_INTEGRITY
CORE_WEAR
CORE_STATE
CORE_STATE_CRITICALITY
CORE_CRITICAL_MASS_REACHED
CORE_CRITICAL_MASS_REACHED_COUNTER
CORE_IMMINENT_FUSION
CORE_READY_FOR_START
CORE_STEAM_PRESENT
CORE_HIGH_STEAM_PRESENT 
CORE_FACTOR
CORE_OPERATION_MODE
CORE_IODINE_GENERATION
CORE_IODINE_CUMULATIVE
CORE_XENON_GENERATION
CORE_XENON_CUMULATIVE
*/
        public static async Task<string> CoreTemp()
        {
            return await Request.Get("CORE_TEMP");
        }
        // generate all the other variables
        public static async Task<string> CoreTempOperative()
        {
            return await Request.Get("CORE_TEMP_OPERATIVE");
        }
        public static async Task<string> CoreTempMax()
        {
            return await Request.Get("CORE_TEMP_MAX");
        }
        public static async Task<string> CoreTempMin()
        {
            return await Request.Get("CORE_TEMP_MIN");
        }
        public static async Task<string> CoreTempResidual()
        {
            return await Request.Get("CORE_TEMP_RESIDUAL");
        }
        public static async Task<string> CorePressure()
        {
            return await Request.Get("CORE_PRESSURE");
        }
        public static async Task<string> CorePressureMax()
        {
            return await Request.Get("CORE_PRESSURE_MAX");
        }
        public static async Task<string> CorePressureOperative()
        {
            return await Request.Get("CORE_PRESSURE_OPERATIVE");
        }
        public static async Task<string> CoreIntegrity()
        {
            return await Request.Get("CORE_INTEGRITY");
        }
        public static async Task<string> CoreWear()
        {
            return await Request.Get("CORE_WEAR");
        }
        public static async Task<string> CoreState()
        {
            return await Request.Get("CORE_STATE");
        }
        public static async Task<string> CoreStateCriticality()
        {
            return await Request.Get("CORE_STATE_CRITICALITY");
        }
        public static async Task<string> CoreCriticalMassReached()
        {
            return await Request.Get("CORE_CRITICAL_MASS_REACHED");
        }
        public static async Task<string> CoreCriticalMassReachedCounter()
        {
            return await Request.Get("CORE_CRITICAL_MASS_REACHED_COUNTER");
        }
        public static async Task<string> CoreImminentFusion()
        {
            return await Request.Get("CORE_IMMINENT_FUSION");
        }
        public static async Task<string> CoreReadyForStart()
        {
            return await Request.Get("CORE_READY_FOR_START");
        }
        public static async Task<string> CoreSteamPresent()
        {
            return await Request.Get("CORE_STEAM_PRESENT");
        }
        public static async Task<string> CoreHighSteamPresent()
        {
            return await Request.Get("CORE_HIGH_STEAM_PRESENT");
        }
        public static async Task<string> CoreFactor()
        {
            return await Request.Get("CORE_FACTOR");
        }
        public static async Task<string> CoreOperationMode()
        {
            return await Request.Get("CORE_OPERATION_MODE");
        }
        public static async Task<string> CoreIodineGeneration()
        {
            return await Request.Get("CORE_IODINE_GENERATION");
        }
        public static async Task<string> CoreIodineCumulative()
        {
            return await Request.Get("CORE_IODINE_CUMULATIVE");
        }
        public static async Task<string> CoreXenonGeneration()
        {
            return await Request.Get("CORE_XENON_GENERATION");
        }
        public static async Task<string> CoreXenonCumulative()
        {
            return await Request.Get("CORE_XENON_CUMULATIVE");
        }

        public static async Task<Dictionary<string, string>> GetAllCore()
        {
            var coreVariables = new List<string>
            {
                "CORE_TEMP",
                "CORE_TEMP_OPERATIVE",
                "CORE_TEMP_MAX",
                "CORE_TEMP_MIN",
                "CORE_TEMP_RESIDUAL",
                "CORE_PRESSURE",
                "CORE_PRESSURE_MAX",
                "CORE_PRESSURE_OPERATIVE",
                "CORE_INTEGRITY",
                "CORE_WEAR",
                "CORE_STATE",
                "CORE_STATE_CRITICALITY",
                "CORE_CRITICAL_MASS_REACHED",
                "CORE_CRITICAL_MASS_REACHED_COUNTER",
                "CORE_IMMINENT_FUSION",
                "CORE_READY_FOR_START",
                "CORE_STEAM_PRESENT",
                "CORE_HIGH_STEAM_PRESENT",
                "CORE_FACTOR",
                "CORE_OPERATION_MODE",
                "CORE_IODINE_GENERATION",
                "CORE_IODINE_CUMULATIVE",
                "CORE_XENON_GENERATION",
                "CORE_XENON_CUMULATIVE"
            };
            var result = new Dictionary<string, string>();
            foreach (var variable in coreVariables)
            {
                result[variable] = await Request.Get(variable);
            }
            return result;
        }

        public static List<string> GetKnownCoreVariables()
        {
            return
            [
                "CORE_TEMP",
                "CORE_TEMP_OPERATIVE",
                "CORE_TEMP_MAX",
                "CORE_TEMP_MIN",
                "CORE_TEMP_RESIDUAL",
                "CORE_PRESSURE",
                "CORE_PRESSURE_MAX",
                "CORE_PRESSURE_OPERATIVE",
                "CORE_INTEGRITY",
                "CORE_WEAR",
                "CORE_STATE",
                "CORE_STATE_CRITICALITY",
                "CORE_CRITICAL_MASS_REACHED",
                "CORE_CRITICAL_MASS_REACHED_COUNTER",
                "CORE_IMMINENT_FUSION",
                "CORE_READY_FOR_START",
                "CORE_STEAM_PRESENT",
                "CORE_HIGH_STEAM_PRESENT",
                "CORE_FACTOR",
                "CORE_OPERATION_MODE",
                "CORE_IODINE_GENERATION",
                "CORE_IODINE_CUMULATIVE",
                "CORE_XENON_GENERATION",
                "CORE_XENON_CUMULATIVE"
            ];
        }
    }
}
