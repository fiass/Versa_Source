using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Versa.F_Core;

namespace Versa.F_Module
{
    class Teleport
    {
        internal static void TeleportToSelected()
        {
            PlayerApi.MyPlayer().transform.position = GameApi.SelectedPlayer().gameObject.transform.position;
        }
    }
}
