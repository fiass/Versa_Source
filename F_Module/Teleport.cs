using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Versa.F_Core;
using Versa.F_Output;

namespace Versa.F_Module
{
    class Teleport
    {
        internal static void TeleportToSelected()
        {
            try
            {
                PlayerApi.MyPlayer().transform.position = GameApi.SelectedPlayer().gameObject.transform.position;
            }
            catch(Exception e) { CustomConsole.Console(true, "Teleport.cs [TeleportToSelected] " + e.Message); }
        }
    }
}
