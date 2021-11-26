using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Versa.F_Core;
using VRC;

namespace Versa.F_Module
{
    class SitOnHead
    {
        internal static IEnumerator Basic()
        {
            Player _player = GameApi.SelectedPlayer();
            PlayerApi.MyVRCPlayer().gameObject.GetComponent<CharacterController>().enabled = false;
            while (true)
            {
                try { if (_player.gameObject != null) { } } catch { break; }

                if (PlayerApi.MyVRCPlayer() != null)
                {
                    if (PlayerApi.InputHorizontal() == 0f && PlayerApi.InputVertical() == 0f)
                    {
                        try
                        {
                            PlayerApi.MyVRCPlayer().gameObject.transform.position = _player.prop_VRCPlayerApi_0.GetBonePosition(HumanBodyBones.Head) + new Vector3(0, 0.3f, 0);
                        }
                        catch
                        {
                            try
                            {
                                PlayerApi.MyVRCPlayer().gameObject.transform.position = _player.transform.position;
                            }
                            catch { break; }
                        }
                    }
                    else { break; }
                }
                else { break; }
                yield return new WaitForSeconds(0.001f);
            }
            PlayerApi.MyVRCPlayer().gameObject.GetComponent<CharacterController>().enabled = true;
        }
    }
}
