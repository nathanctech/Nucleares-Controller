using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NukeWeb.Variables
{
    public class Generators
    {
        /*
         * GENERATOR_0_KW
GENERATOR_1_KW
GENERATOR_2_KW
GENERATOR_0_V
GENERATOR_1_V
GENERATOR_2_V
GENERATOR_0_A
GENERATOR_1_A
GENERATOR_2_A
GENERATOR_0_HERTZ
GENERATOR_1_HERTZ
GENERATOR_2_HERTZ
GENERATOR_0_BREAKER
GENERATOR_1_BREAKER
GENERATOR_2_BREAKER
RES_DIVERT_SURPLUS_FROM_MW
RES_EFFECTIVELY_DERIVED_ENERGY_MW
        */
        public static async Task<string> GeneratorKw(int gen)
        {
            if (gen < 0 || gen > 2)
                throw new ArgumentOutOfRangeException(nameof(gen), "Generator index must be between 0 and 2.");
            return await Request.Get($"GENERATOR_{gen}_KW");
        }
        public static async Task<string> GeneratorVoltage(int gen)
        {
            if (gen < 0 || gen > 2)
                throw new ArgumentOutOfRangeException(nameof(gen), "Generator index must be between 0 and 2.");
            return await Request.Get($"GENERATOR_{gen}_V");
        }
        public static async Task<string> GeneratorAmps(int gen)
        {
            if (gen < 0 || gen > 2)
                throw new ArgumentOutOfRangeException(nameof(gen), "Generator index must be between 0 and 2.");
            return await Request.Get($"GENERATOR_{gen}_A");
        }
        public static async Task<string> GeneratorHertz(int gen)
        {
            if (gen < 0 || gen > 2)
                throw new ArgumentOutOfRangeException(nameof(gen), "Generator index must be between 0 and 2.");
            return await Request.Get($"GENERATOR_{gen}_HERTZ");
        }
        public static async Task<string> GeneratorBreaker(int gen)
        {
            if (gen < 0 || gen > 2)
                throw new ArgumentOutOfRangeException(nameof(gen), "Generator index must be between 0 and 2.");
            return await Request.Get($"GENERATOR_{gen}_BREAKER");
        }
        public static async Task<string> ResDivertSurplusFromMw()
        {
            return await Request.Get("RES_DIVERT_SURPLUS_FROM_MW");
        }
        public static async Task<string> ResEffectivelyDerivedEnergyMw()
        {
            return await Request.Get("RES_EFFECTIVELY_DERIVED_ENERGY_MW");
        }
        public static async Task<string> GetPowerDemand()
        {
            return await Request.Get("POWER_DEMAND_MW");
        }
        public static async Task<string> GetMaxPlantOutput()
        {
            return await Request.Get("POWER_MAX_THEORETICAL_FINAL_PLANT_OUTPUT_MW");
        }
        public static async Task<string> GetPowerProduced()
        {
            // get the power produced by the generators
            var gen0 = await GeneratorKw(0);
            var gen1 = await GeneratorKw(1);
            var gen2 = await GeneratorKw(2);
            // parse and sum the values
            var gen0Value = double.Parse(gen0);
            var gen1Value = double.Parse(gen1);
            var gen2Value = double.Parse(gen2);
            var totalPower = gen0Value + gen1Value + gen2Value;
            return totalPower.ToString();
        }
    }
}
