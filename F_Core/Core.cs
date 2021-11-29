using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Versa.F_Config;
using Versa.F_Core;
using Versa.F_Module;
using Versa.F_Output;
using Versa.F_Ui;
using MelonLoader;
using TMPro;
using UnityEngine;

namespace Versa.F_Core
{
    internal class Core
    {
        
        
        internal static void OnApplicationStart()
        {
            CustomConsole.Console(true, "[OnApplicationStart]");
            System.Console.ForegroundColor = ConsoleColor.White;
            CustomConsole.Console("Versa ready.",ConsoleColor.Green, CustomConsole.Info);
            CustomConsole.Console($"Versa Server is {Server.Role()}.", ConsoleColor.Green, CustomConsole.Info);
            ResourceHandler.Start();
        }
        internal static void OnUpdate()
        {
            TabControl.HotKeys();
            F_Module.Camera.FoVScroll();
        }
        internal static void OnGui()
        {
            TabControl.Tips();
        }
         internal static TextMeshProUGUI textMeshPro = null;
        internal static void MenuInitialized()
        {
            try
            {
                if (Server.Access())
                {
                    CustomConsole.Console(true, "the menu is being configured");
                    Unnecessary.TurnGameObject(false);
                    textMeshPro = UiPath.Text_Title.GetComponent<TextMeshProUGUI>();
                    textMeshPro.text = "Versa";
                    UiManager.ApplyData();
                }
            }
            catch (Exception e) { CustomConsole.Console(true, "Core.cs [MenuInitialized] " + e.Message); }
        }
       
        internal static void OnPlayerNetWasInitialized()
        {
            CustomConsole.Console(true, "[OnPlayerNetWasInitialized]");
            PatchBase.SetupPatches();
            MelonCoroutines.Start(UiManager.CreateStateListener());
        }
        internal static void OnUiWasInitialized()
        {
            CustomConsole.Console(true, "[OnUiWasInitialized]");
        }
        private static bool notloaded;
        internal async static void PlayerIsReady()
        {
            notloaded = true;
            while (notloaded)
            {
                try
                {
                    if (PlayerApi.MyVRCPlayer().field_Private_Boolean_6)
                    {
                        notloaded = false;
                        PlayerReady();
                    }
                }
                catch { }
               await Task.Delay(500);
            }
        }
        internal static void PlayerReady()
        {
            CustomConsole.Console(true, "[PlayerReady]");
            F_Core.CapsuleColor.Capsule();
            Data.Toggle.Undress = false;
            Prefs.String.Save("runSpeed", PlayerApi.MyVRCPlayer().gameObject.GetComponent<GamelikeInputController>().field_Public_Single_0.ToString());
            Prefs.String.Save("strafeSpeed", PlayerApi.MyVRCPlayer().gameObject.GetComponent<GamelikeInputController>().field_Public_Single_1.ToString());
            Prefs.String.Save("walkSpeed", PlayerApi.MyVRCPlayer().gameObject.GetComponent<GamelikeInputController>().field_Public_Single_2.ToString());

            //То что нужно сбрасываеться при переходе в мир и нужно переобновить
            if (Data.WorldLog)
                LogData.World();

            if (!Data.Toggle.PostProcess)
                PostProcess.State(false);
            
            if (Data.Toggle.MoonGravity)
                Gravity.Moon();
            
            if (Data.Toggle.Ownership)
                WorldObject.TakeOwnership(true);

            if (Data.Toggle.SpeedHack)
                SpeedHack.State(true);

            if (Data.ToggleJump)
                Jump.EnableJump();
            else
                Jump.DisableJump();


        }
        internal static void OnSceneWasInitialized()
        {
            if (Data.Toggle.Optimization)
                Optimization.State(true);
            CustomConsole.Console(true, "[OnSceneWasInitialized]");
            if(!notloaded)
            PlayerIsReady();
        }
        internal static void OnApplicationQuit()
        {
            CustomConsole.Console(true, "[OnApplicationQuit]");
        }
    }
}
