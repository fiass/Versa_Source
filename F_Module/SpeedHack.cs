using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Versa.F_Core;

namespace Versa.F_Module
{
    class SpeedHack
    {
      internal static void State(bool state)
        {
            switch(state)
            {
                case true:
                    PlayerApi.MyVRCPlayer().gameObject.GetComponent<GamelikeInputController>().field_Public_Single_0 = PlayerApi.MyVRCPlayer().gameObject.GetComponent<GamelikeInputController>().field_Public_Single_0 * 4;
                    PlayerApi.MyVRCPlayer().gameObject.GetComponent<GamelikeInputController>().field_Public_Single_1 = PlayerApi.MyVRCPlayer().gameObject.GetComponent<GamelikeInputController>().field_Public_Single_1 * 4;
                    PlayerApi.MyVRCPlayer().gameObject.GetComponent<GamelikeInputController>().field_Public_Single_2 = PlayerApi.MyVRCPlayer().gameObject.GetComponent<GamelikeInputController>().field_Public_Single_2 * 4;
                    break;

                case false:
                    PlayerApi.MyVRCPlayer().gameObject.GetComponent<GamelikeInputController>().field_Public_Single_0 = Convert.ToSingle(Prefs.String.Load("runSpeed"));
                    PlayerApi.MyVRCPlayer().gameObject.GetComponent<GamelikeInputController>().field_Public_Single_1 = Convert.ToSingle(Prefs.String.Load("strafeSpeed"));
                    PlayerApi.MyVRCPlayer().gameObject.GetComponent<GamelikeInputController>().field_Public_Single_2 = Convert.ToSingle(Prefs.String.Load("walkSpeed")); 
                    break;
            }
        }
    }
}
