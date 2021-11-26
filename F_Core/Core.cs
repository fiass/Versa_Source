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
            if (Server.Access())
            {
                CustomConsole.Console(true, "the menu is being configured");
                Unnecessary.TurnGameObject(false);
                textMeshPro = UiPath.Text_Title.GetComponent<TextMeshProUGUI>();
                textMeshPro.text = "Versa";
                UiManager.ApplyData();
            }
        }
       
        internal static void OnPlayerNetWasInitialized()
        {
            CustomConsole.Console(true, "[OnPlayerNetWasInitialized]");
            MelonCoroutines.Start(UiManager.CreateStateListener());
        }
        internal static void OnUiWasInitialized()
        {
            CustomConsole.Console(true, "[OnUiWasInitialized]");
        }
        internal static void OnSceneWasInitialized()
        {
            CustomConsole.Console(true, "[OnSceneWasInitialized]");
            F_Core.CapsuleColor.Capsule();
        }
        internal static void OnApplicationQuit()
        {
            CustomConsole.Console(true, "[OnApplicationQuit]");
        }
    }
}
