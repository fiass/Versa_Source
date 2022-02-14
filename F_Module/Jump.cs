using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Versa.F_Core;
using Versa.F_Output;

namespace Versa.F_Module
{
    class Jump
    {
        public static async void EnableJump()
        {
            try
            {

                if (PlayerApi.MyVRCPlayer().prop_VRCPlayerApi_0.GetJumpImpulse() <= 0f)
                {
                    PlayerApi.MyVRCPlayer().prop_VRCPlayerApi_0.SetJumpImpulse(3f);
                }
            }
            catch (Exception e) { CustomConsole.Console(true, "Jump.cs [EnableJump] " + e.Message); }
        }
        public static async void DisableJump()
        {
            try
            {

                if (PlayerApi.MyVRCPlayer().prop_VRCPlayerApi_0.GetJumpImpulse() >= 0f)
                {
                    PlayerApi.MyVRCPlayer().prop_VRCPlayerApi_0.SetJumpImpulse(0f);
                }
            }
            catch (Exception e) { CustomConsole.Console(true, "Jump.cs [DisableJump] " + e.Message); }

        }
    }
}
