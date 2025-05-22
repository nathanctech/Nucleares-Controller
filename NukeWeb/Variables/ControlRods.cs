using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NukeWeb.Variables
{
    public class ControlRods
    {
        /*
         * RODS_STATUS
RODS_MOVEMENT_SPEED
RODS_MOVEMENT_SPEED_DECREASED_HIGH_TEMPERATURE
RODS_DEFORMED
RODS_TEMPERATURE
RODS_MAX_TEMPERATURE
RODS_POS_ORDERED
RODS_POS_ACTUAL
RODS_POS_REACHED
RODS_QUANTITY
RODS_ALIGNED

POST
RODS_ALL_POS_ORDERED
        */
        public static async Task<string> Status()
        {
            return await Request.Get("RODS_STATUS");
        }
        public static async Task<string> MovementSpeed()
        {
            return await Request.Get("RODS_MOVEMENT_SPEED");
        }
        public static async Task<string> MovementSpeedDecreasedHighTemperature()
        {
            return await Request.Get("RODS_MOVEMENT_SPEED_DECREASED_HIGH_TEMPERATURE");
        }
        public static async Task<string> Deformed()
        {
            return await Request.Get("RODS_DEFORMED");
        }
        public static async Task<string> Temperature()
        {
            return await Request.Get("RODS_TEMPERATURE");
        }
        public static async Task<string> MaxTemperature()
        {
            return await Request.Get("RODS_MAX_TEMPERATURE");
        }
        public static async Task<string> PosOrdered()
        {
            return await Request.Get("RODS_POS_ORDERED");
        }
        public static async Task<string> PosActual()
        {
            return await Request.Get("RODS_POS_ACTUAL");
        }
        public static async Task<string> PosReached()
        {
            return await Request.Get("RODS_POS_REACHED");
        }
        public static async Task<string> Quantity()
        {
            return await Request.Get("RODS_QUANTITY");
        }
        public static async Task<string> Aligned()
        {
            return await Request.Get("RODS_ALIGNED");
        }
        public static async Task<string> RodPosition(int bank, int rod)
        {
            if (bank < 0 || bank > 8)
                throw new ArgumentOutOfRangeException(nameof(bank), "Bank must be between 0 and 8.");
            if (rod < 0 || rod > 7)
                throw new ArgumentOutOfRangeException(nameof(rod), "Rod must be between 0 and 7.");
            return await Request.Get($"ROD_BANK_{bank}_{rod}_POS");
        }

        public static async Task<string> SetRodsAllPosOrdered(double value)
        {
            if (value < 0 || value > 100)
                throw new ArgumentOutOfRangeException(nameof(value), "Value must be between 0 and 100.");
            return await Request.Post($"RODS_ALL_POS_ORDERED", value);
        }

        public static async Task<string> SetRodPositionOrdered(int bank, int rod, double position)
        {
            if (bank < 0 || bank > 8)
                throw new ArgumentOutOfRangeException(nameof(bank), "Bank must be between 0 and 8.");
            if (rod < 0 || rod > 7)
                throw new ArgumentOutOfRangeException(nameof(rod), "Rod must be between 0 and 7.");
            return await Request.Post($"ROD_BANK_{bank}_{rod}_POS", position);
        }
    }
}
