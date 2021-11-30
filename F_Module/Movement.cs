using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Versa.F_Core;

namespace Versa.F_Module
{
    class Movement
    {
        internal static void MoveEnabled()
        {
            PlayerApi.MyVRCPlayer().gameObject.GetComponent<GamelikeInputController>().field_Public_Single_0 = Convert.ToSingle(Prefs.String.Load("runSpeed"));
            PlayerApi.MyVRCPlayer().gameObject.GetComponent<GamelikeInputController>().field_Public_Single_1 = Convert.ToSingle(Prefs.String.Load("strafeSpeed"));
            PlayerApi.MyVRCPlayer().gameObject.GetComponent<GamelikeInputController>().field_Public_Single_2 = Convert.ToSingle(Prefs.String.Load("walkSpeed"));
        }
        internal static void MoveDisabled()
        {
            PlayerApi.MyVRCPlayer().gameObject.GetComponent<GamelikeInputController>().field_Public_Single_0 = 0;
            PlayerApi.MyVRCPlayer().gameObject.GetComponent<GamelikeInputController>().field_Public_Single_1 = 0;
            PlayerApi.MyVRCPlayer().gameObject.GetComponent<GamelikeInputController>().field_Public_Single_2 = 0;
        }
    }
}
