using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Versa.F_Core;

namespace Versa.F_Output
{
    class Clipboard
    {
        internal static async void WorldFullID()
        {
            GameApi.SaveToClipboard(GameApi.currentRoom.id);
        }

    }
}
