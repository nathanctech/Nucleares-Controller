using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NukeWeb.Variables
{
    public class Misc
    {
        /*
GAME_VERSION
TIME
TIME_STAMP
WEBSERVER_LIST_VARIABLES
FUN_IS_ENABLED
         * */
        public static async Task<string> GameVersion()
        {
            return await Request.Get("GAME_VERSION");
        }
        public static async Task<string> Time()
        {
            return await Request.Get("TIME");
        }
        public static async Task<string> TimeStamp()
        {
            return await Request.Get("TIME_STAMP");
        }
        public static async Task<string> WebserverListVariables()
        {
            return await Request.Get("WEBSERVER_LIST_VARIABLES");
        }
        public static async Task<string> FunIsEnabled()
        {
            return await Request.Get("FUN_IS_ENABLED");
        }
    }
}
