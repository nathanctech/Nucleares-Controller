using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NukeWeb.Settables
{
    public static class General
    {
        public static async Task<string> SCRAM()
        {
            return await Request.Post("RODS_ALL_POS_ORDERED", 100);
        }
    }
}
