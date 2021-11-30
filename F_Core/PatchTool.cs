using System;
using System.Reflection;
using HarmonyLib;
using Versa.F_Config;
using Versa.F_Module;
using Versa.F_Output;

namespace Versa.F_Core
{
    internal class PatchBase
    {
        internal static void SetupPatches()
        {
            //This patches first Quickmenu Open
            PatchTool.Patch(typeof(VRC.UI.Elements.QuickMenu).GetMethod("Awake"), 
                PatchTool.GetPatch<PatchBase>("QuickMenuPostfix"));
            //This patches VRCPlayer avatar load
            PatchTool.Patch(typeof(VRCPlayer).GetMethod("Awake"), 
                PatchTool.GetPatch<PatchBase>("VRCPlayerPostfix"));
        }
        
        private static bool VRCPlayerPostfix(VRCPlayer __instance)
        {
            __instance.Method_Public_add_Void_OnAvatarIsReady_0(new Action(() =>
            {
                if (__instance != null)
                {
                    if (__instance._player != null)
                    {
                        if ( __instance._player.prop_ApiAvatar_0 != null)
                        {
                            if(Data.Toggle.AntiCrash)
                            AntiCrash.CheckPlayer(__instance._player);
                        }
                    }
                }
            }));
            return true;
        }

        private static bool QuickMenuPostfix(VRC.UI.Elements.QuickMenu __instance)
        {
            //Code ran on first quickmenu open
            return true;
        }
    }
    
    internal class PatchTool
    {
        internal static HarmonyLib.Harmony HarmonyInstance = new HarmonyLib.Harmony("Versa");
        internal static void Patch(MethodInfo Method, HarmonyMethod PostFixMethod)
        {
            try
            {
                HarmonyInstance.Patch(Method, PostFixMethod);
            }
            catch (Exception e) { CustomConsole.Console(true, "PatchTool.cs [Patch] " + e.Message); }
        }
        internal static HarmonyMethod GetPatch<T>(string name) =>
            new HarmonyMethod(typeof(T).GetMethod(name, AccessTools.all));
        internal static HarmonyMethod GetPatch<T>(string name, BindingFlags flags) =>
            new HarmonyMethod(typeof(T).GetMethod(name, flags));
    }
}