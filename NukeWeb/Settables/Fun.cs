using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NukeWeb.Settables
{
    public class Fun
    {
        /* 
         * 
POST:
FUN_REQUEST_ENABLE
FUN_DECERASE_INTEGRITY
FUN_TRIGGER_AUDIT
FUN_TOGGLE_RANDOM_SWITCH
FUN_AO_SABOTAGE_ONCE
FUN_AO_SABOTAGE_TIME
FUN_BANK_ROBBERY
FUN_PUMP_JAM
FUN_OIL_SPILL
FUN_BREAKER_TRIP
FUN_XENON_SPILL
FUN_IODINE_SPILL
FUN_SHOW_MESSAGE
*/

        public static async Task<string> FunRequestEnable()
        {
            return await Request.Post("FUN_REQUEST_ENABLE");
        }
        public static async Task<string> FunDecreaseIntegrity()
        {
            return await Request.Post("FUN_DECERASE_INTEGRITY");
        }
        public static async Task<string> FunTriggerAudit()
        {
            return await Request.Post("FUN_TRIGGER_AUDIT");
        }
        public static async Task<string> FunToggleRandomSwitch()
        {
            return await Request.Post("FUN_TOGGLE_RANDOM_SWITCH");
        }
        public static async Task<string> FunAOSabotageOnce()
        {
            return await Request.Post("FUN_AO_SABOTAGE_ONCE");
        }
        public static async Task<string> FunAOSabotageTime(int hours)
        {
            return await Request.Post("FUN_AO_SABOTAGE_TIME", hours);
        }
        public static async Task<string> FunBankRobbery()
        {
            return await Request.Post("FUN_BANK_ROBBERY");
        }
        public static async Task<string> FunPumpJam()
        {
            return await Request.Post("FUN_PUMP_JAM");
        }
        public static async Task<string> FunOilSpill()
        {
            return await Request.Post("FUN_OIL_SPILL");
        }
        public static async Task<string> FunBreakerTrip()
        {
            return await Request.Post("FUN_BREAKER_TRIP");
        }
        public static async Task<string> FunXenonSpill()
        {
            return await Request.Post("FUN_XENON_SPILL");
        }
        public static async Task<string> FunIodineSpill()
        {
            return await Request.Post("FUN_IODINE_SPILL");
        }
        public static async Task<string> FunShowMessage(string message)
        {
            return await Request.Post("FUN_SHOW_MESSAGE", message);
        }
    }
}
