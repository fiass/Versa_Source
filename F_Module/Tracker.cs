using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Versa.F_Config;
using Versa.F_Core;
using Versa.F_Output;
using VRC;
using VRC.SDKBase;

namespace Versa.F_Module
{
    class Tracker
    {
        public static string GetOwnerName(VRC_Pickup pickup)
        {
            return $"{Networking.GetOwner(pickup.gameObject).displayName} = {pickup.gameObject.name}";
        }
        public static VRCPlayer GetOwnerVRCPlayer(VRC_Pickup pickup) => Networking.GetOwner(pickup.gameObject).gameObject.GetComponent<VRCPlayer>();
        internal static IEnumerator WhoOwner()
        {
            while (Data.UserIntoWorld)
            {

                yield return new WaitForSeconds(5f);
            }
        }
    }
}