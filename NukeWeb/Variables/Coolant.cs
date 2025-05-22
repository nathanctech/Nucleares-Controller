using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace NukeWeb.Variables
{
    public class Coolant
    {
        /*
         * COOLANT_CORE_STATE
COOLANT_CORE_PRESSURE
COOLANT_CORE_MAX_PRESSURE
COOLANT_CORE_VESSEL_TEMPERATURE
COOLANT_CORE_QUANTITY_IN_VESSEL
COOLANT_CORE_PRIMARY_LOOP_LEVEL
COOLANT_CORE_FLOW_SPEED
COOLANT_CORE_FLOW_ORDERED_SPEED
COOLANT_CORE_FLOW_REACHED_SPEED
COOLANT_CORE_QUANTITY_CIRCULATION_PUMPS_PRESENT
COOLANT_CORE_QUANTITY_FREIGHT_PUMPS_PRESENT
COOLANT_CORE_CIRCULATION_PUMP_0_STATUS
COOLANT_CORE_CIRCULATION_PUMP_1_STATUS
COOLANT_CORE_CIRCULATION_PUMP_2_STATUS
COOLANT_CORE_CIRCULATION_PUMP_0_DRY_STATUS
COOLANT_CORE_CIRCULATION_PUMP_1_DRY_STATUS
COOLANT_CORE_CIRCULATION_PUMP_2_DRY_STATUS
COOLANT_CORE_CIRCULATION_PUMP_0_OVERLOAD_STATUS
COOLANT_CORE_CIRCULATION_PUMP_1_OVERLOAD_STATUS
COOLANT_CORE_CIRCULATION_PUMP_2_OVERLOAD_STATUS
COOLANT_CORE_CIRCULATION_PUMP_0_ORDERED_SPEED
COOLANT_CORE_CIRCULATION_PUMP_1_ORDERED_SPEED
COOLANT_CORE_CIRCULATION_PUMP_2_ORDERED_SPEED
COOLANT_CORE_CIRCULATION_PUMP_0_SPEED
COOLANT_CORE_CIRCULATION_PUMP_1_SPEED
COOLANT_CORE_CIRCULATION_PUMP_2_SPEED
COOLANT_SEC_CIRCULATION_PUMP_0_STATUS
COOLANT_SEC_CIRCULATION_PUMP_1_STATUS
COOLANT_SEC_CIRCULATION_PUMP_2_STATUS
COOLANT_SEC_CIRCULATION_PUMP_0_DRY_STATUS
COOLANT_SEC_CIRCULATION_PUMP_1_DRY_STATUS
COOLANT_SEC_CIRCULATION_PUMP_2_DRY_STATUS
COOLANT_SEC_CIRCULATION_PUMP_0_OVERLOAD_STATUS
COOLANT_SEC_CIRCULATION_PUMP_1_OVERLOAD_STATUS
COOLANT_SEC_CIRCULATION_PUMP_2_OVERLOAD_STATUS
COOLANT_SEC_CIRCULATION_PUMP_0_ORDERED_SPEED
COOLANT_SEC_CIRCULATION_PUMP_1_ORDERED_SPEED
COOLANT_SEC_CIRCULATION_PUMP_2_ORDERED_SPEED
COOLANT_SEC_CIRCULATION_PUMP_0_SPEED
COOLANT_SEC_CIRCULATION_PUMP_1_SPEED
COOLANT_SEC_CIRCULATION_PUMP_2_SPEED
COOLANT_SEC_0_VOLUME
COOLANT_SEC_1_VOLUME
COOLANT_SEC_2_VOLUME
COOLANT_SEC_0_PRESSURE
COOLANT_SEC_1_PRESSURE
COOLANT_SEC_2_PRESSURE
COOLANT_SEC_0_TEMPERATURE
COOLANT_SEC_1_TEMPERATURE
COOLANT_SEC_2_TEMPERATURE

COOLANT_SEC_CIRCULATION_PUMP_0_ORDERED_SPEED
COOLANT_SEC_CIRCULATION_PUMP_1_ORDERED_SPEED
COOLANT_SEC_CIRCULATION_PUMP_2_ORDERED_SPEED
COOLANT_CORE_CIRCULATION_PUMP_0_ORDERED_SPEED
COOLANT_CORE_CIRCULATION_PUMP_1_ORDERED_SPEED
COOLANT_CORE_CIRCULATION_PUMP_2_ORDERED_SPEED
        */
        public static async Task<string> CoreState()
        {
            return await Request.Get("COOLANT_CORE_STATE");
        }
        public static async Task<string> CorePressure()
        {
            return await Request.Get("COOLANT_CORE_PRESSURE");
        }
        public static async Task<string> CoreMaxPressure()
        {
            return await Request.Get("COOLANT_CORE_MAX_PRESSURE");
        }
        public static async Task<string> CoreVesselTemperature()
        {
            return await Request.Get("COOLANT_CORE_VESSEL_TEMPERATURE");
        }
        public static async Task<string> CoreQuantityInVessel()
        {
            return await Request.Get("COOLANT_CORE_QUANTITY_IN_VESSEL");
        }
        public static async Task<string> CorePrimaryLoopLevel()
        {
            return await Request.Get("COOLANT_CORE_PRIMARY_LOOP_LEVEL");
        }
        public static async Task<string> CoreFlowSpeed()
        {
            return await Request.Get("COOLANT_CORE_FLOW_SPEED");
        }
        public static async Task<string> CoreFlowOrderedSpeed()
        {
            return await Request.Get("COOLANT_CORE_FLOW_ORDERED_SPEED");
        }
        public static async Task<string> CoreFlowReachedSpeed()
        {
            return await Request.Get("COOLANT_CORE_FLOW_REACHED_SPEED");
        }
        public static async Task<string> CoreQuantityCirculationPumpsPresent()
        {
            return await Request.Get("COOLANT_CORE_QUANTITY_CIRCULATION_PUMPS_PRESENT");
        }
        public static async Task<string> CoreQuantityFreightPumpsPresent()
        {
            return await Request.Get("COOLANT_CORE_QUANTITY_FREIGHT_PUMPS_PRESENT");
        }
        public static async Task<string> CoreCirculationPumpStatus(int num)
        {
            if (num < 0 || num > 2)
            {
                throw new ArgumentOutOfRangeException(nameof(num), "Pump number must be between 0 and 2.");
            }
            return await Request.Get($"COOLANT_CORE_CIRCULATION_PUMP_{num}_STATUS");
        }
        public static async Task<string> CoreCirculationPumpDryStatus(int num)
        {
            if (num < 0 || num > 2)
            {
                throw new ArgumentOutOfRangeException(nameof(num), "Pump number must be between 0 and 2.");
            }
            return await Request.Get($"COOLANT_CORE_CIRCULATION_PUMP_{num}_DRY_STATUS");
        }
        public static async Task<string> CoreCirculationPumpOverloadStatus(int num)
        {
            if (num < 0 || num > 2)
            {
                throw new ArgumentOutOfRangeException(nameof(num), "Pump number must be between 0 and 2.");
            }
            return await Request.Get($"COOLANT_CORE_CIRCULATION_PUMP_{num}_OVERLOAD_STATUS");
        }
        public static async Task<string> CoreCirculationPumpOrderedSpeed(int num)
        {
            if (num < 0 || num > 2)
            {
                throw new ArgumentOutOfRangeException(nameof(num), "Pump number must be between 0 and 2.");
            }
            return await Request.Get($"COOLANT_CORE_CIRCULATION_PUMP_{num}_ORDERED_SPEED");
        }
        public static async Task<string> CoreCirculationPumpSpeed(int num)
        {
            if (num < 0 || num > 2)
            {
                throw new ArgumentOutOfRangeException(nameof(num), "Pump number must be between 0 and 2.");
            }
            return await Request.Get($"COOLANT_CORE_CIRCULATION_PUMP_{num}_SPEED");
        }
        public static async Task<string> SecCirculationPumpStatus(int num)
        {
            if (num < 0 || num > 2)
            {
                throw new ArgumentOutOfRangeException(nameof(num), "Pump number must be between 0 and 2.");
            }
            return await Request.Get($"COOLANT_SEC_CIRCULATION_PUMP_{num}_STATUS");
        }
        public static async Task<string> SecCirculationPumpDryStatus(int num)
        {
            if (num < 0 || num > 2)
            {
                throw new ArgumentOutOfRangeException(nameof(num), "Pump number must be between 0 and 2.");
            }
            return await Request.Get($"COOLANT_SEC_CIRCULATION_PUMP_{num}_DRY_STATUS");
        }
        public static async Task<string> SecCirculationPumpOverloadStatus(int num)
        {
            if (num < 0 || num > 2)
            {
                throw new ArgumentOutOfRangeException(nameof(num), "Pump number must be between 0 and 2.");
            }
            return await Request.Get($"COOLANT_SEC_CIRCULATION_PUMP_{num}_OVERLOAD_STATUS");
        }
        public static async Task<string> SecCirculationPumpOrderedSpeed(int num)
        {
            if (num < 0 || num > 2)
            {
                throw new ArgumentOutOfRangeException(nameof(num), "Pump number must be between 0 and 2.");
            }
            return await Request.Get($"COOLANT_SEC_CIRCULATION_PUMP_{num}_ORDERED_SPEED");
        }
        public static async Task<string> SecCirculationPumpSpeed(int num)
        {
            if (num < 0 || num > 2)
            {
                throw new ArgumentOutOfRangeException(nameof(num), "Pump number must be between 0 and 2.");
            }
            return await Request.Get($"COOLANT_SEC_CIRCULATION_PUMP_{num}_SPEED");
        }
        public static async Task<string> SecVolume(int num)
        {
            if (num < 0 || num > 2)
            {
                throw new ArgumentOutOfRangeException(nameof(num), "Volume number must be between 0 and 2.");
            }
            return await Request.Get($"COOLANT_SEC_{num}_VOLUME");
        }
        public static async Task<string> SecPressure(int num)
        {
            if (num < 0 || num > 2)
            {
                throw new ArgumentOutOfRangeException(nameof(num), "Pressure number must be between 0 and 2.");
            }
            return await Request.Get($"COOLANT_SEC_{num}_PRESSURE");
        }
        public static async Task<string> SecTemperature(int num)
        {
            if (num < 0 || num > 2)
            {
                throw new ArgumentOutOfRangeException(nameof(num), "Temperature number must be between 0 and 2.");
            }
            return await Request.Get($"COOLANT_SEC_{num}_TEMPERATURE");
        }

        public static async Task<string> SetSecCirculationPumpOrderedSpeed(int num, int speed)
        {
            if (num < 0 || num > 2)
            {
                throw new ArgumentOutOfRangeException(nameof(num), "Pump number must be between 0 and 2.");
            }
            if (speed < 0 || speed > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(speed), "Speed must be between 0 and 100.");
            }
            return await Request.Post($"COOLANT_SEC_CIRCULATION_PUMP_{num}_ORDERED_SPEED", speed);
        }

        public static async Task<string> SetCoreCirculationPumpOrderedSpeed(int num, int speed)
        {
            if (num < 0 || num > 2)
            {
                throw new ArgumentOutOfRangeException(nameof(num), "Pump number must be between 0 and 2.");
            }
            if (speed < 0 || speed > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(speed), "Speed must be between 0 and 100.");
            }
            return await Request.Post($"COOLANT_CORE_CIRCULATION_PUMP_{num}_ORDERED_SPEED", speed);
        }
    }
}
