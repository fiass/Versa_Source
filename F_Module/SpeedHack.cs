using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Versa.F_Core;
using Versa.F_Output;

namespace Versa.F_Module
{
    class SpeedHack
    {
      internal static void State(bool state)
        {
            switch(state)
            {
                case true:
                    CustomConsole.Console(true, "runSpeed = "+Prefs.String.Load("runSpeed"));
                    CustomConsole.Console(true, "strafeSpeed = " + Prefs.String.Load("strafeSpeed"));
                    CustomConsole.Console(true, "walkSpeed = " + Prefs.String.Load("walkSpeed"));
                    PlayerApi.MyVRCPlayer().gameObject.GetComponent<GamelikeInputController>().field_Public_Single_0 = PlayerApi.MyVRCPlayer().gameObject.GetComponent<GamelikeInputController>().field_Public_Single_0 * 4;
                    PlayerApi.MyVRCPlayer().gameObject.GetComponent<GamelikeInputController>().field_Public_Single_1 = PlayerApi.MyVRCPlayer().gameObject.GetComponent<GamelikeInputController>().field_Public_Single_1 * 4;
                    PlayerApi.MyVRCPlayer().gameObject.GetComponent<GamelikeInputController>().field_Public_Single_2 = PlayerApi.MyVRCPlayer().gameObject.GetComponent<GamelikeInputController>().field_Public_Single_2 * 4;
                    break;

                case false:
                    CustomConsole.Console(true, "runSpeed = " + Prefs.String.Load("runSpeed"));
                    CustomConsole.Console(true, "strafeSpeed = " + Prefs.String.Load("strafeSpeed"));
                    CustomConsole.Console(true, "walkSpeed = " + Prefs.String.Load("walkSpeed"));
                    PlayerApi.MyVRCPlayer().gameObject.GetComponent<GamelikeInputController>().field_Public_Single_0 = Convert.ToSingle(Prefs.String.Load("runSpeed"));
                    PlayerApi.MyVRCPlayer().gameObject.GetComponent<GamelikeInputController>().field_Public_Single_1 = Convert.ToSingle(Prefs.String.Load("strafeSpeed"));
                    PlayerApi.MyVRCPlayer().gameObject.GetComponent<GamelikeInputController>().field_Public_Single_2 = Convert.ToSingle(Prefs.String.Load("walkSpeed")); 
                    break;
            }
        }
    }
}
