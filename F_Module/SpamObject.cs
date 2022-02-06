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
    class SpamObject
    {
        internal static List<VRC_Pickup> _t = new List<VRC_Pickup>();
        internal static void Enable()
        {

            Data.Toggle.SpamObject = true;
            MelonLoader.MelonCoroutines.Start(Coroutine());
        }
        internal static void Disable()
        {
            Data.Toggle.SpamObject = false;
            _t.Clear();
        }
        internal static IEnumerator Coroutine()
        {
            Player _player = GameApi.SelectedPlayer();
            try
            {
                _t.Clear();
            }
            catch (Exception e)
            {
                CustomConsole.Console(true, "SpamObject.cs [Clear] " + e.Message);
            }
            try
            {
                foreach (VRC_Pickup pickup in GameObject.FindObjectsOfType<VRC_Pickup>())
                {
                    _t.Add(pickup);
                }
            }
            catch (Exception e)
            {
                CustomConsole.Console(true, "SpamObject.cs [foreach] " + e.Message);
            }
            while (Data.Toggle.SpamObject)
            {
                if (_player != null || PlayerApi.MyVRCPlayer() != null)
                {
                    foreach (var ls in _t)
                    {
                        try
                        {
                            //VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_Player_0.prop_PlayerNet_0.field_Internal_VRCPlayer_0.prop_VRCPlayerApi_0.TakeOwnership(ls.gameObject);
                            Networking.SetOwner(VRCPlayer.field_Internal_Static_VRCPlayer_0.prop_VRCPlayerApi_0, ls.gameObject);
                            ls.gameObject.transform.position = _player.transform.position;
                        }
                        catch (Exception e)
                        {
                            CustomConsole.Console(true, "SpamObject.cs [Coroutine] " + e.Message);
                            Data.Toggle.SpamObject = false;
                        }
                    }
                }
                else
                {
                    Data.Toggle.SpamObject = false;
                }
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}
