using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnityEngine;
using Versa.F_Output;
using VRC;
using VRC.Core;
using VRC.UI.Elements;
using VRC.UI.Elements.Menus;

namespace Versa.F_Core
{
    class GameApi
    {
        public static GameObject QuickMenu
        {
            get
            {
                return GameObject.Find("/UserInterface/Canvas_QuickMenu(Clone)/");
            }
        }
        internal static VRCAvatarManager get_prop_VRCAvatarManager_0(VRCPlayer player)
        {
            return player.prop_VRCAvatarManager_0;
        }
        internal static ApiWorldInstance currentRoom
        {
            get
            {
                return RoomManager.field_Internal_Static_ApiWorldInstance_0;
            }
        }
        internal static async void SaveToClipboard(string textData)
        {
            try
            {
                await System.Threading.Tasks.Task.Run(() =>
                {
                    System.Windows.Forms.Clipboard.SetData(DataFormats.Text, (System.Object)textData);
                });
            }
            catch(Exception e) { CustomConsole.Console(true, "GameApi.cs [SaveToClipboard] " + e.Message); }
        }
        internal static  GameObject Menu_SelectedUser_Local
        {  
            get
            {
                GameObject temp = null;
                try 
                {
                    temp = GameObject.Find("/UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_SelectedUser_Local/");
                }
                catch(Exception e)
                { CustomConsole.Console(true, "GameApi.cs [Menu_SelectedUser_Local] " + e.Message); }
                F_Output.CustomConsole.Console(true, temp.name + " get successful");
                return temp;
            }
        }
        
        internal static  Player GetPlayerByID(string ID)
        {
            Player temp = null;
            try
            {
                temp = PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.ToArray().Where(x => x.prop_APIUser_0.id == ID).FirstOrDefault();
                F_Output.CustomConsole.Console(true, "[GetPlayerByID]");
            }
            catch (Exception e) { CustomConsole.Console(true, "GameApi.cs [GetPlayerByID] " + e.Message); }
            return temp;
        }
        internal static string SelectedUser_Id()
        {
            string temp = null;
            try
            {
                temp = Menu_SelectedUser_Local.GetComponent<SelectedUserMenuQM>().field_Private_IUser_0.prop_String_0;
                F_Output.CustomConsole.Console(true, "[SelectedUser_Id]");
            }
            catch (Exception e) { CustomConsole.Console(true, "GameApi.cs [SelectedUser_Id] " + e.Message); }
            return temp; 
        }
        internal static Player SelectedPlayer()
        {
            Player temp = null;
            try
            {
                 temp = GetPlayerByID(SelectedUser_Id());
                F_Output.CustomConsole.Console(true, "[SelectedPlayer]");
            }
            catch(Exception e) { CustomConsole.Console(true, "GameApi.cs [SelectedPlayer] "+ e.Message); }
                return temp;
            }
        internal static APIUser SelectedAPIUser()
        {
            APIUser temp = null;
            try
            {
                temp = SelectedPlayer().prop_APIUser_0;
                F_Output.CustomConsole.Console(true, "[SelectedAPIUser]");
            }
            catch (Exception e) { CustomConsole.Console(true, "GameApi.cs [SelectedAPIUser] " + e.Message); }
            return temp;
        }
        public static GameObject GetAvatar(VRCPlayer player)
        {
           VRCAvatarManager Instance = player.prop_VRCAvatarManager_0;
           if (Instance.prop_GameObject_0 != null)
           {
               return Instance.prop_GameObject_0;
           }
           if (Instance.field_Public_GameObject_1 != null)
           {
               return Instance.field_Public_GameObject_1;
           }
            return null;
        }
    }
}
