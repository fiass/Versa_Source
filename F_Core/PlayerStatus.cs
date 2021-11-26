using Versa.F_Config;
using Versa.F_Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Versa.F_Core
{
    class PlayerStatus
    {
        internal static bool IsPaidUser()
        {
            return true; //Auth
        }
        internal static string Status()
        {
            if(IsPaidUser())
            {
                return "Versa";
            }
            return "Versa Trial";
        }
    }
}
