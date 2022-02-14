using Versa.F_Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;
using Versa.F_Output;
using VRC.UI.Elements.Menus;
using VRC;
using BestHTTP;
using VRC.Core;
using VRC.UI;

namespace Versa.F_Module
{
    class ForceClone
    {
       
        public static async void UnlockCloneAvatar()
        {
            try
            {
                if (GameApi.Menu_SelectedUser_Local != null)
                {
                    TextMeshProUGUI Text_H4 = GameApi.Menu_SelectedUser_Local.transform.Find("ScrollRect/Viewport/VerticalLayoutGroup/Buttons_AvatarActions/Button_CloneAvatar/Text_H4").GetComponent<TMPro.TextMeshProUGUI>();
                    Text_H4.text = "Unlocking";
                    await Task.Delay(1000);
                    if (GameApi.SelectedPlayer() != null)
                    {
                        if (GameApi.SelectedPlayer().prop_VRCPlayer_0.prop_VRCAvatarManager_0.prop_ApiAvatar_0.releaseStatus == "public")
                        {
                            Text_H4.text = "Versa Clone";
                            GameApi.SelectedAPIUser().allowAvatarCopying = true;
                        }
                        else
                        {
                            Text_H4.text = "Private";
                            GameApi.SelectedAPIUser().allowAvatarCopying = false;
                        }
                    }
                    else { CustomConsole.Console(true, "ForceClone.cs:   SelectedPlayer not founded"); }
                }
            }
            catch (Exception e) { CustomConsole.Console(true, "ForceClone.cs: " + e.Message); }
        }
    }
}

