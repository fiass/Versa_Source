using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRC;
using VRC.Core;
using VRC.SDKBase;
using UnhollowerBaseLib;
using MelonLoader;
using Versa.F_Output;
using Versa.F_Config;

namespace Versa.F_Core
{
    internal class PlayerApi
    {
        internal static float InputVertical()
        {
            return Input.GetAxis("Vertical");
        }
                            
        internal static float InputHorizontal()
        {
            return Input.GetAxis("Horizontal");
        }

        internal static float InputOculusVertical()
        {
            return Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical");
        }

        internal static float InputOculusHorizontal()
        {
            return Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickHorizontal");
        }
        internal static string ID()
        {
            return playerNet().prop_Player_0.prop_APIUser_0.id;
        }
        internal static Player MyPlayer()
        {
            return VRCPlayer.field_Internal_Static_VRCPlayer_0.prop_Player_0;
        }
        internal static VRCPlayer MyVRCPlayer()
        {
            return VRCPlayer.field_Internal_Static_VRCPlayer_0;
        }
        internal static Il2CppSystem.Collections.Generic.List<Player> AllVRCPlayers()
        {
            return PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0;
        }
        internal static PlayerNet playerNet()
        {
            try
            {
                return VRC.Player.prop_Player_0._playerNet;
            }
            catch
            {
                return null;
            }
        }
    }
}
