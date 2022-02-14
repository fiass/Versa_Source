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
        private static List<VRC_StationInternal> chair = new List<VRC_StationInternal>();
        private static List<VRC_StationInternal2> chair2 = new List<VRC_StationInternal2>();
        private static List<VRC_StationInternal3> chair3 = new List<VRC_StationInternal3>();
        private static bool _Can;
        internal static async void TakeOwnership(bool state)
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
                        CustomConsole.Console(true, "TakeOwnership started");
                    }
                    catch (Exception e) { CustomConsole.Console(true, "WorldObject.cs [TakeOwnership] " + e.Message); }
                    break;

                case false:
                    _Can = false;
                    break;
            }
        }
        internal static async void ChairEnabled()
        {
            try
            {
                foreach (var a in chair)
                {
                    a.gameObject.SetActive(true);
                }
                foreach (var a in chair2)
                {
                    a.gameObject.SetActive(true);
                }
                foreach (var a in chair3)
                {
                    a.gameObject.SetActive(true);
                }
                CustomConsole.Console(true, $"Chairs enadbled: {chair.Count + chair2.Count + chair3.Count}");
            }
            catch (Exception e) { CustomConsole.Console(true, "WorldObject.cs [ChairEnabled] " + e.Message); }
        }
        internal static async void ChairDisabled()
        {
            try
            {
                chair.Clear();
                foreach (VRC_StationInternal a in Resources.FindObjectsOfTypeAll<VRC_StationInternal>())
                {
                    chair.Add(a);
                    a.gameObject.SetActive(false);
                }
                chair2.Clear();
                foreach (VRC_StationInternal2 a in Resources.FindObjectsOfTypeAll<VRC_StationInternal2>())
                {
                    chair2.Add(a);
                    a.gameObject.SetActive(false);
                }
                chair3.Clear();
                foreach (VRC_StationInternal3 a in Resources.FindObjectsOfTypeAll<VRC_StationInternal3>())
                {
                    chair3.Add(a);
                    a.gameObject.SetActive(false);
                }
                CustomConsole.Console(true, $"Chairs disabled: {chair.Count + chair2.Count + chair3.Count}");
            }catch (Exception e) { CustomConsole.Console(true, "WorldObject.cs [ChairDisabled] " + e.Message); }
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
