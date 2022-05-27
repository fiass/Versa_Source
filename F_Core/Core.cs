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
using System.IO;

namespace Versa.F_Core
{
    internal class Core
    {
        internal async static void OnApplicationStart()
        {
            F_Plugins.Lovense.Startup();
            CustomConsole.Console(true, "[OnApplicationStart]");
            foreach (var file in Directory.GetFiles($@"{Directory.GetCurrentDirectory()}\Mods"))
                if (file.Contains("Versa"))
                   // File.Delete(file);
            System.Console.ForegroundColor = ConsoleColor.White;
            CustomConsole.Console("Versa ready.",ConsoleColor.Green, CustomConsole.Info);
            CustomConsole.Console($"Versa Server is {Server.Role()}.", ConsoleColor.Green, CustomConsole.Info);
            ResourceHandler.Start();
            if (Data.FirstUsageVersa == null)
            { 
                Data.FirstUsageVersa = "No";
                Data.FoV = 60;
                Data.CapsuleColor = "blue";
                Data.MenuColor = "blue";
                Data.Toggle.BlockPortals = false;
                Data.Toggle.CapsuleEsp = false;
                Data.Toggle.MoonGravity = false;
                Data.Toggle.NoClip = false;
                Data.Toggle.Optimization = false;
                Data.Toggle.Ownership = false;
                Data.Toggle.SpeedHack = false;
                Data.Toggle.Undress = false;
            }
        }
        internal async static void OnUpdate()
        {
            HotKeys.Control();
            F_Module.Camera.FoVScroll();
        }
        internal async static void OnGui()
        {
            TabControl.Tips();
        }
         internal static TextMeshProUGUI textMeshPro = null;
        internal async static void Menu_Initialized()
        {
            try
            {
                Data.Is = Server.Access();
                if (Data.Is)
                {
                    CustomConsole.Console(true, "the menu is being configured");
                    Unnecessary.TurnGameObject(false);
                    textMeshPro = InterfacePath.Text_Title.GetComponent<TextMeshProUGUI>();
                    textMeshPro.text = "Versa " + BuildInfo.Version;
                    UiManager.ApplyData();
                    Data.CurrentClientUser = PlayerApi.ID(); // Получение Current ID после иницилизации крыла
                }
            }
            catch (TypeInitializationException e) { CustomConsole.Console(true, "Core.cs [MenuInitialized] " + e.Message); }
        }
       
        internal async static void OnPlayerNetWasInitialized()
        {
            CustomConsole.Console(true, "[OnPlayerNetWasInitialized]");
            PatchBase.SetupPatches();
            MelonCoroutines.Start(UiManager.CreateVersaStateListener());
        }
        internal async static void OnUiWasInitialized()
        {
            CustomConsole.Console(true, "[OnUiWasInitialized]");
        }
        private static bool notloaded;
        internal async static void PlayerIsReady()
        {
            notloaded = true;
            Data.UserIntoWorld = false;
            while (notloaded)
            {
                try
                {
                    if (PlayerApi.MyVRCPlayer().field_Private_Boolean_6)
                    {
                        Data.UserIntoWorld = true;
                        notloaded = false;
                        PlayerReady();
                    }
                }
                catch { }
               await Task.Delay(500);
            }
        }
        internal async static void PlayerReady()
        {
            CustomConsole.Console(true, "[PlayerReady]");
            F_Core.CapsuleColor.Capsule();

            //То что нужно сбрасываеться при переходе в мир и нужно переобновить
          
            Data.Toggle.Undress = false;
            Data.Toggle.TriggerEsp = false;
            Data.Toggle.LineEsp = false;
            Data.Toggle.ToggleMove = true;
            Data.Toggle.Flashlight = false;
            Data.Toggle.SpamObject = false;
            Data.Toggle.AntiCrash = Data.AntiCrash;
            Data.Toggle.FoVScroll = Data.FoVScroll;
            AntiCrash.PolygonLimits = Data.PolyLimit;

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

            if (!Data.ToggleChair)
                WorldObject.ChairDisabled();
        }
        internal async static void OnSceneWasInitialized()
        {
            if (Data.Toggle.Optimization)
                Optimization.State(true);
            CustomConsole.Console(true, "[OnSceneWasInitialized]");
            if(!notloaded)
            PlayerIsReady();
        }
        internal async static void OnApplicationQuit()
        {
            CustomConsole.Console(true, "[OnApplicationQuit]");
        }
    }
}
