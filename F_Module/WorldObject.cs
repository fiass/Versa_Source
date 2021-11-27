using System;
using System.Collections.Generic;
using MelonLoader;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using Versa.F_Output;
using Versa.F_Core;

namespace Versa.F_Module
{
    class WorldObject
    {
        private static List<VRC_Pickup> _lst = new List<VRC_Pickup>();
        private static bool _Can;
        internal static void TakeOwnership(bool state)
        {
            switch (state)
            {
                case true:
                    try
                    {
                        _lst.Clear();
                        foreach (VRC_Pickup pickup in Resources.FindObjectsOfTypeAll<VRC_Pickup>())
                        {
                            _lst.Add(pickup);
                        }
                            _Can = true;
                            MelonCoroutines.Start(Coroutine());
                    }
                    catch { }
                    break;

                case false:
                    _Can = false;
                    break;
            }
        }
        private static IEnumerator Coroutine()
        {
            while (_Can)
            {
                try
                {
                    foreach (var ls in _lst)
                    {
                        try { Networking.SetOwner(PlayerApi.MyVRCPlayer().prop_VRCPlayerApi_0, ls.gameObject); }  catch { }
                    }
                }
                catch (Exception e)
                {
                    _Can = false;
                    _lst.Clear();
                    CustomConsole.Console(true,"WorldObject.cs [Coroutine] "+e.Message);
                }
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
