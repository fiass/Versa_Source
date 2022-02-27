using Versa.F_Core;
using Versa.F_Output;
using Versa.F_Config;
using Versa.F_Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnhollowerRuntimeLib;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Elements;
using System.Collections;
using MelonLoader;
using TMPro;
using UnityEngine.Events;
using System.Net;

namespace Versa.F_Ui
{
    internal class VersaStateListener : MonoBehaviour
    {
        public VersaStateListener(IntPtr ptr) : base(ptr) { }
        public VersaStateListener() : base(ClassInjector.DerivedConstructorPointer<VersaStateListener>()) => ClassInjector.DerivedConstructorBody(this);
        public Action OnEnabledMethod;
        public Action OnDisableMethod;
        private void OnEnable() => OnEnabledMethod?.Invoke();

        private void OnDisable() => OnDisableMethod?.Invoke();
    }
    internal class UiManager
    {
        static bool animation = false;
        internal static void MenuColor(string color)
        {
            Data.MenuColor = color;
            Color temp = StringToColor(Data.MenuColor);
            foreach (var menu in GenerateUi.ColorMenu)
            {
                menu.color = new Color(temp.r, temp.g, temp.b, 0.5f);
            }
        }
        internal static IEnumerator CreateVersaStateListener()
        {
            bool _a = true;
            while (_a)
            {
                CustomConsole.Console(true, "Wait first open menu");
                try
                {
                    var _b = GameObject.Find("/UserInterface/Canvas_QuickMenu(Clone)");
                    if (_b != null)
                    {
                        CustomConsole.Console(true, "Menu was open");

                        try
                        {
                            Initialize_ui();
                        }
                        catch (TypeInitializationException e) { CustomConsole.Console(true, "UiManager.cs [Initialize] " + e.Message); }

                        try
                        {
                            Core.Menu_Initialized();
                        }
                        catch (TypeInitializationException e) { CustomConsole.Console(true, "UiManager.cs [MenuInitialized] " + e.Message); }

                        _a = false;
                    }
                }
                catch (Exception e)
                { CustomConsole.Console(true, "UiManager.cs [CreateVersaStateListener] " + e.Message); }
                yield return new WaitForSeconds(0.5f);
            }
        }
        private static void Initialize_ui()
        {
            VersaStateListener LaunchPad = null;
            VersaStateListener LeftWing = null;
            VersaStateListener RightWing = null;
            VersaStateListener SelectedUser = null;

            try { ClassInjector.RegisterTypeInIl2Cpp<VersaStateListener>(); } catch (Exception e) { CustomConsole.Console(true, "RegisterTypeInIl2Cpp [VersaStateListener] " + e.Message); }
            try { LaunchPad = UiPath.Canvas_QuickMenu_Clone.AddComponent<VersaStateListener>(); } catch (Exception e) { CustomConsole.Console(true, "VersaStateListener [Canvas_QuickMenu_Clone] " + e.Message); }
            try { LeftWing = UiPath.LeftWing.AddComponent<VersaStateListener>(); } catch (Exception e) { CustomConsole.Console(true, "VersaStateListener [LeftWing] " + e.Message); }
            try { RightWing = UiPath.RightWing.AddComponent<VersaStateListener>(); } catch (Exception e) { CustomConsole.Console(true, "VersaStateListener [RightWing] " + e.Message); }
            try { SelectedUser = GameApi.Menu_SelectedUser_Local.AddComponent<VersaStateListener>(); } catch (Exception e) { CustomConsole.Console(true, "VersaStateListener [Menu_SelectedUser_Local] " + e.Message); }

            LeftWing.OnEnabledMethod = () => Data.LeftWing = true;
            LeftWing.OnDisableMethod = () => Data.LeftWing = false;
            RightWing.OnEnabledMethod = () => Data.RightWing = true;
            RightWing.OnDisableMethod = () => Data.RightWing = false;

            SelectedUser.OnEnabledMethod = () =>
            {
                ForceClone.UnlockCloneAvatar();
                try { CameraPreview.CreateRender(); } catch { }
                CustomConsole.Console(true, "SelectedUser Open");
            };
            SelectedUser.OnDisableMethod = () =>
            {
                try { CameraPreview.DestroyRender(); } catch { }
                CustomConsole.Console(true, "SelectedUser Close");
            };
            LaunchPad.OnEnabledMethod = () =>
            {
                try
                {
                    MelonCoroutines.Start(LogoAnimation());
                    OneSecUpdate.Panel.GetComponent<Animator>().SetBool("IsShow", true);
                    CustomConsole.Console(true, "LaunchPad Open");
                }
                catch (Exception e) { CustomConsole.Console(true, "LaunchPad [OnEnabledMethod] " + e.Message); }
            };

            LaunchPad.OnDisableMethod = () =>
            {
                try
                {
                    animation = false;
                    OneSecUpdate.Panel.GetComponent<Animator>().SetBool("IsShow", false);
                    CustomConsole.Console(true, "LaunchPad Close");
                }
                catch (Exception e) { CustomConsole.Console(true, "LaunchPad [OnEnabledMethod] " + e.Message); }
            };

        }
        internal static void ApplyData()
        {
            F_Module.Camera.FoVLoad();
            SelectColor(Prefs.String.Load("Highlights"));
            HighlightsFXSetup.Setup();
            if (Data.Is)
                GenerateUi.IniUi();
            //AvatarList.Create();
            QuickStatus.Icons();
            MenuColor(Data.MenuColor);
            F_Core.Network.DownloadIconPack();
            Prefs.String.Save("runSpeed", PlayerApi.MyVRCPlayer().gameObject.GetComponent<GamelikeInputController>().field_Public_Single_0.ToString());
            Prefs.String.Save("strafeSpeed", PlayerApi.MyVRCPlayer().gameObject.GetComponent<GamelikeInputController>().field_Public_Single_1.ToString());
            Prefs.String.Save("walkSpeed", PlayerApi.MyVRCPlayer().gameObject.GetComponent<GamelikeInputController>().field_Public_Single_2.ToString());
        }
        internal static Color StringToColor(string color)
        {
            switch (color.ToLower())
            {
                case "red":
                    return Color.red;
                case "green":
                    return Color.green;
                case "blue":
                    return Color.blue;
                case "white":
                    return Color.white;
                case "black":
                    return Color.black;
                case "magenta":
                    return Color.magenta;
                case "cyan":
                    return Color.cyan;
                case "gray":
                    return Color.gray;
            }
            return Color.blue;
        }
        internal static void SetCapsuleColor(string _a)
        {
            Prefs.String.Save("CapsuleColor", _a);
            F_Core.CapsuleColor.Capsule();
        }
        public static void SelectColor(string _a)
        {
            try
            {
                if (Resources.FindObjectsOfTypeAll<HighlightsFXStandalone>().Count != 0)
                {
                    Resources.FindObjectsOfTypeAll<HighlightsFXStandalone>().FirstOrDefault<HighlightsFXStandalone>().highlightColor = StringToColor(_a);
                    Prefs.String.Save("Highlights", _a);
                }
            }
            catch (Exception e)
            { CustomConsole.Console(true, "UiManager.cs [SelectColor] " + e.Message); }
        }
        internal static IEnumerator LogoAnimation()
        {
            bool a = true;
            float i = 0.1f;
            animation = true;
            while (animation)
            {
                switch (a)
                {
                    case true:
                        if (i > 0.5f)
                            a = false;
                        else
                            i = i + 0.01f;
                        break;

                    case false:
                        if (i < 0.1f)
                            a = true;
                        else
                            i = i - 0.01f;

                        break;
                }
                Core.textMeshPro.color = new Color(0, 0.25f, 0.40f, i); //TMP Of element what need pulse
                yield return new WaitForSeconds(0.1f);
            }
        }

    }
}