using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NukeWeb.Variables
{
    public class Condenser
    {
        /*
         * CONDENSER_CIRCULATION_PUMP_OVERLOAD_STATUS
CONDENSER_CIRCULATION_PUMP_ORDERED_SPEED
CONDENSER_CIRCULATION_PUMP_SPEED
CONDENSER_TEMPERATURE
CONDENSER_VOLUME
FREIGHT_PUMP_CONDENSER_ACTIVE

CONDENSER_CIRCULATION_PUMP_ORDERED_SPEED
FREIGHT_PUMP_CONDENSER_ACTIVE
        */
        public static async Task<string> CirculationPumpOverloadStatus()
        {
            return await Request.Get("CONDENSER_CIRCULATION_PUMP_OVERLOAD_STATUS");
        }
        public static async Task<string> CirculationPumpOrderedSpeed()
        {
            return await Request.Get("CONDENSER_CIRCULATION_PUMP_ORDERED_SPEED");
        }
        public static async Task<string> CirculationPumpSpeed()
        {
            return await Request.Get("CONDENSER_CIRCULATION_PUMP_SPEED");
        }
        public static async Task<string> Temperature()
        {
            return await Request.Get("CONDENSER_TEMPERATURE");
        }
        public static async Task<string> Volume()
        {
            return await Request.Get("CONDENSER_VOLUME");
        }
        public static async Task<string> FreightPumpCondenserActive()
        {
            return await Request.Get("FREIGHT_PUMP_CONDENSER_ACTIVE");
        }

        public static async Task<string> SetCirculationPumpOrderedSpeed(int speed)
        {
            if (speed < 0 || speed > 100)
                throw new ArgumentOutOfRangeException(nameof(speed), "Speed must be between 0 and 100.");
            return await Request.Post("CONDENSER_CIRCULATION_PUMP_ORDERED_SPEED", speed);
        }

        public static async Task<string> SetFreightPumpCondenserActive(bool active)
        {
            return await Request.Post("FREIGHT_PUMP_CONDENSER_ACTIVE", active ? 1 : 0);
        }
    }
}
