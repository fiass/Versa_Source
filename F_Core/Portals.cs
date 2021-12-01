using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Versa.F_Output;
using VRC;
using VRC.SDKBase;

namespace Versa.F_Core
{
    class Portals
    {
        internal static void State(bool state)
        {
            if (state)
            {
                can = true;
                MelonLoader.MelonCoroutines.Start(Start());
            }
            if(!state)
            {                                   
                can = false;
            }
        }
        private static bool can;
        private static IEnumerator Start()
        {
            if(can)
            while (can)
            {
                    try
                    {
                        (from portal in GameObject.FindObjectsOfType<MonoBehaviourPublicSiBoSiInSeSiSoInStSiUnique>()
                         where portal.gameObject.activeInHierarchy && !portal.gameObject.GetComponentInParent<VRC_PortalMarker>()
                         select portal).ToList().ForEach(p =>
                         {
                             CustomConsole.Console(true, "Portal Blocked: " + p.field_Private_ApiWorld_0.name + " Id: "+ p.field_Private_ApiWorld_0.id);
                             p.Method_Private_Void_1();
                         });
                    }
                    catch { }
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
