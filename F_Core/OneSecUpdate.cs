using ExitGames.Client.Photon;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using Versa.F_Output;
using VRC;

namespace Versa.F_Core
{
    class OneSecUpdate
    {
        internal static GameObject Panel;
         internal static IEnumerator Enable()
        {
            TextMeshProUGUI Fps = GameObject.Find("/UserInterface/PlayerDisplay/" + GenerateUi.Stats.name + "/Fps").GetComponent<TextMeshProUGUI>();
             TextMeshProUGUI Users = GameObject.Find("/UserInterface/PlayerDisplay/" + GenerateUi.Stats.name + "/Users").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI Xyz = GameObject.Find("/UserInterface/PlayerDisplay/" + GenerateUi.Stats.name + "/Panel/XYZ").GetComponent<TextMeshProUGUI>();
            Panel = GameObject.Find("/UserInterface/PlayerDisplay/" + GenerateUi.Stats.name + "/Panel");


            Transform xyz;
            while (true)
            {
                try
                {
                    xyz = PlayerApi.MyPlayer().gameObject.transform;
                    Fps.text = "FPS:" + Math.Round(1.0f / Time.deltaTime, 0);
                    Users.text = "USERS:" + PlayerManager.prop_PlayerManager_0.prop_ArrayOf_Player_0.Length;
                    Xyz.text = $"X:{Math.Round(xyz.position.x,1)}\nY:{Math.Round(xyz.position.y,1)}\nZ:{Math.Round(xyz.position.z,1)}";
                }
                catch(Exception e) { CustomConsole.Console(true, "OneSecUpdate.cs: "+e.Message); }
                yield return new WaitForSeconds(1f);
            }
        }
    }
}
