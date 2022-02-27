using Versa.F_Module;
using Versa.F_Ui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Versa.F_Ui.Wing;
using MelonLoader;
using UnityEngine.UI;
using Versa.F_Config;
using UnityEngine;
using Versa.F_Output;
using VRC.UI.Core.Styles;
using static Versa.F_Core.PatchBase;

namespace Versa.F_Core
{
    internal class GenerateUi
    {
        internal static GameObject Stats;
        internal static Image[] ColorMenu = new Image[11];
        private static void SetIcon(Image image, Texture2D texture)
        {

            image.sprite = new Sprite();
            image.material = new Material(image.material)
            {
                mainTexture = texture
            };
        }
        public static void IniUi()
        {
            var i = 1;
            i = (i++) * i;
            F_Output.CustomConsole.Console(true, "[IniUi started]");
            ActivateScrollInQM();
            Network.DownloadIconPack();
            try
            {
                SetIcon((ColorMenu[0] = UiPath.BackgroundLayer02.GetComponent<Image>()), Data.Textures[96]);
                SetIcon((ColorMenu[1] = UiPath.BackgroundLeft.GetComponent<Image>()), Data.Textures[96]);
                SetIcon((ColorMenu[2] = UiPath.BackgroundRight.GetComponent<Image>()), Data.Textures[96]);
                SetIcon((ColorMenu[3] = UiPath.Page0.GetComponent<Image>()), Data.Textures[96]);
                SetIcon((ColorMenu[4] = UiPath.Page1.GetComponent<Image>()), Data.Textures[96]);
                SetIcon((ColorMenu[5] = UiPath.Page2.GetComponent<Image>()), Data.Textures[96]);
                SetIcon((ColorMenu[6] = UiPath.Page3.GetComponent<Image>()), Data.Textures[96]);
                SetIcon((ColorMenu[7] = UiPath.Page4.GetComponent<Image>()), Data.Textures[96]);
                SetIcon((ColorMenu[8] = UiPath.Page5.GetComponent<Image>()), Data.Textures[96]);
                SetIcon((ColorMenu[9] = UiPath.Page6.GetComponent<Image>()), Data.Textures[96]);
                SetIcon((ColorMenu[10] = UiPath.Background.GetComponent<Image>()), Data.Textures[96]);

                foreach (var color in ColorMenu)
                {
                     UnityEngine.Object.Destroy(color.gameObject.GetComponent<StyleElement>()); 
                     color.color = new Color(0f, 0.5f, 1f, 0.5f);
                }
            }
            catch (Exception e) { CustomConsole.Console(true, "GenerateUi.cs [IniUi] " + e.Message); }
            // QMButtonParent Versa_QM = new QMButtonParent(QMCache.QMHeader.transform.parent, "Versa", "Versa Quick", "#004166");
            // QMPage Versa_Page_1 = new QMPage("VersaPage", "VersaPage");
            // QMButton NoClip = Versa_QM.AddButton("NoClip", "NoClip", "", Data.Textures[5]); NoClip.SetAction(() => Data.Toggle.NoClip = NoClip.State(Data.Toggle.NoClip, () => F_Module.NoClip.State(true), () => F_Module.NoClip.State(false)));
            // QMButton Speed = Versa_QM.AddButton("Speed", "Speed", "", Data.Textures[6]); Speed.SetAction(() => Data.Toggle.SpeedHack = Speed.State(Data.Toggle.SpeedHack, () => F_Module.SpeedHack.State(true), () => F_Module.SpeedHack.State(false)));
            // QMButton Optimization = Versa_QM.AddButton("Optimization", "Optimization", "", Data.Textures[3]); Optimization.SetAction(() => Data.Toggle.Optimization = Optimization.State(Data.Toggle.Optimization, () => F_Module.Optimization.State(true), () => F_Module.Optimization.State(false)));
            Stats = GameObject.Instantiate(Data.VersaStats, GameObject.Find("/UserInterface/PlayerDisplay/").transform);
            MelonCoroutines.Start(OneSecUpdate.Enable());
            F_Output.CustomConsole.Console(true, "[IniUi finished]");
        }
        public static Action<BaseWing> OnWingInit = new Action<BaseWing>(wing =>
        {
            if (Data.Is)
            {
                F_Output.CustomConsole.Console(true, "[OnWingInit started]");
                WingPage Versa = wing.CreatePage("Versa");
                WingPage Tools = Versa.CreateNestedPage("Tools", 0, Data.Textures[1]);
                WingPage Camera = Versa.CreateNestedPage("Camera", 3, Data.Textures[1]);
                WingPage Esp = Versa.CreateNestedPage("Esp", 4, Data.Textures[1]);
                WingPage World = Versa.CreateNestedPage("World", 2, Data.Textures[1]);
                WingPage Self = Versa.CreateNestedPage("Self", 1, Data.Textures[1]);
                WingPage Settings = Versa.CreateNestedPage("Settings", 6, Data.Textures[28]);
                WingPage Selected = Versa.CreateNestedPage("Selected", 5, Data.Textures[1]);
                WingPage Highlights = Settings.CreateNestedPage("HighlightsFX", 0, Data.Textures[1]);
                WingPage VersaUI = Settings.CreateNestedPage("VersaUI", 2, Data.Textures[1]);
                WingPage Capsule = Settings.CreateNestedPage("CapsuleFX", 1, Data.Textures[1]);

                #region NextPage
                WingPage NextSettings = Settings.CreateNestedPage("Next Page", "Settings 2", 6, Data.Textures[1]);
                WingPage NextWorld = World.CreateNestedPage("Next Page", "World 2", 6, Data.Textures[1]);
                #endregion

                WingButton Gravity = World.CreateButton("MoonGravity", 0, Data.Textures[2], Data.Toggle.MoonGravity);
                Gravity.SetAction(() => Data.Toggle.MoonGravity = Gravity.State(Gravity, Data.Toggle.MoonGravity, F_Module.Gravity.Moon, F_Module.Gravity.Standard));
                MelonLoader.MelonCoroutines.Start(Gravity.StateUpdate(Gravity, 1));

                WingButton BlockPortals = World.CreateButton("BlockPortals", 3, Data.Textures[18], Data.Toggle.BlockPortals);
                BlockPortals.SetAction(() => Data.Toggle.BlockPortals = BlockPortals.State(BlockPortals, Data.Toggle.BlockPortals, () => Portals.State(true), () => Portals.State(false)));
                MelonLoader.MelonCoroutines.Start(BlockPortals.StateUpdate(BlockPortals, 8));

                WingButton OptimizationWorld = World.CreateButton("Optimization", 1, Data.Textures[3], Data.Toggle.Optimization);
                OptimizationWorld.SetAction(() => Data.Toggle.Optimization = OptimizationWorld.State(OptimizationWorld, Data.Toggle.Optimization, () => Optimization.State(true), () => Optimization.State(false)));
                MelonLoader.MelonCoroutines.Start(OptimizationWorld.StateUpdate(OptimizationWorld, 2));

                WingButton WorldLogs = Settings.CreateButton("WorldLogs", 3, Data.Textures[19], Data.WorldLog);
                WorldLogs.SetAction(() => Data.WorldLog = WorldLogs.State(WorldLogs, Data.WorldLog));
                MelonLoader.MelonCoroutines.Start(WorldLogs.StateUpdate(WorldLogs, 9));

                WingButton AntiCrash = Settings.CreateButton("AntiCrash", 4, Data.Textures[23], Data.AntiCrash);
                AntiCrash.SetAction(() => Data.AntiCrash = AntiCrash.State(AntiCrash, Data.AntiCrash, () => F_Module.AntiCrash.State(true), () => F_Module.AntiCrash.State(false)));
                MelonLoader.MelonCoroutines.Start(AntiCrash.StateUpdate(AntiCrash, 14));

                WingButton Documentation = Settings.CreateButton("Manual", 5, Data.Textures[50]);
                Documentation.SetAction(() => Network.OpenDoc());

                WingButton WorldID = World.CreateButton("ID:Instance", 5, Data.Textures[16]);
                WorldID.SetAction(() => Clipboard.WorldFullID());
                WingButton DownloadVRCW = World.CreateButton("DL VRCW", 4, Data.Textures[7]);
                DownloadVRCW.SetAction(() => VRCA.DownloadWorld());

                WingButton GetOwnership = World.CreateButton("Ownership", 2, Data.Textures[4], Data.Toggle.Ownership);
                GetOwnership.SetAction(() => Data.Toggle.Ownership = GetOwnership.State(GetOwnership, Data.Toggle.Ownership, () => WorldObject.TakeOwnership(true), () => WorldObject.TakeOwnership(false)));
                MelonLoader.MelonCoroutines.Start(GetOwnership.StateUpdate(GetOwnership, 3));

                WingButton TeleportToSelected = Selected.CreateButton("TeleportTo", 0, Data.Textures[12]);
                TeleportToSelected.SetAction(() => Teleport.TeleportToSelected());

                WingButton SitOnHead = Selected.CreateButton("SitOnHead", 1, Data.Textures[10]);
                SitOnHead.SetAction(() => MelonCoroutines.Start(F_Module.SitOnHead.Basic()));

                WingButton DownloadVRCA_Selected = Selected.CreateButton("DL VRCA", 2, Data.Textures[7]);
                DownloadVRCA_Selected.SetAction(() => { VRCA.DownloadSelect(); });

                WingButton Undress = Selected.CreateButton("Undress", 3, Data.Textures[11], Data.Toggle.Undress);
                Undress.SetAction(() => Data.Toggle.Undress = Undress.State(Undress, Data.Toggle.Undress, () => Lewd.MakeLewd(true), () => Lewd.MakeLewd(false)));
                MelonLoader.MelonCoroutines.Start(Undress.StateUpdate(Undress, 4));

                WingButton ToggleJump = Self.CreateButton("ToggleJump", 0, Data.Textures[20], Data.ToggleJump);
                ToggleJump.SetAction(() => Data.ToggleJump = ToggleJump.State(ToggleJump, Data.ToggleJump, () => Jump.EnableJump(), () => Jump.DisableJump()));
                MelonLoader.MelonCoroutines.Start(ToggleJump.StateUpdate(ToggleJump, 10));

                WingButton ToggleMove = Self.CreateButton("ToggleMove", 1, Data.Textures[21], Data.Toggle.ToggleMove);
                ToggleMove.SetAction(() => Data.Toggle.ToggleMove = ToggleMove.State(ToggleMove, Data.Toggle.ToggleMove, () => Movement.MoveEnabled(), () => Movement.MoveDisabled()));
                MelonLoader.MelonCoroutines.Start(ToggleMove.StateUpdate(ToggleMove, 12));

                WingButton ToggleChair = Self.CreateButton("ToggleChair", 2, Data.Textures[22], Data.ToggleChair);
                ToggleChair.SetAction(() => Data.ToggleChair = ToggleChair.State(ToggleChair, Data.ToggleChair, () => WorldObject.ChairEnabled(), () => WorldObject.ChairDisabled()));
                MelonLoader.MelonCoroutines.Start(ToggleChair.StateUpdate(ToggleChair, 13));

                WingButton DownloadVRCA_Me = Self.CreateButton("DL VRCA", 3, Data.Textures[7]);
                DownloadVRCA_Me.SetAction(() => VRCA.DownloadMe());

                WingButton GoTo = Self.CreateButton("JoinByID", 4, Data.Textures[15]);
                GoTo.SetAction(() => Popup.GoToWorld());

                WingButton Flashlight = Camera.CreateButton("Flashlight", 3, Data.Textures[24], Data.Toggle.Flashlight);
                Flashlight.SetAction(() => Data.Toggle.Flashlight = Flashlight.State(Flashlight, Data.Toggle.Flashlight, () => F_Module.Flashlight.Enable(), () => F_Module.Flashlight.Disable()));
                MelonLoader.MelonCoroutines.Start(Flashlight.StateUpdate(Flashlight, 15));

                WingButton FoVScroll = Camera.CreateButton("FoV Scroll", 4, Data.Textures[29], Data.Toggle.FoVScroll);
                FoVScroll.SetAction(() => Data.Toggle.FoVScroll = FoVScroll.State(FoVScroll, Data.Toggle.FoVScroll, () => F_Module.Camera.Enable(), () => F_Module.Camera.Disable()));
                MelonLoader.MelonCoroutines.Start(FoVScroll.StateUpdate(FoVScroll, 20));

                WingButton Spam = Selected.CreateButton("Spam", 4, Data.Textures[27], Data.Toggle.SpamObject);
                Spam.SetAction(() => Data.Toggle.SpamObject = Spam.State(Spam, Data.Toggle.SpamObject, () => F_Module.SpamObject.Enable(), () => F_Module.SpamObject.Disable()));
                MelonLoader.MelonCoroutines.Start(Spam.StateUpdate(Spam, 16));

                #region Color
                WingButton Red_ = Capsule.CreateButton("Red", 0, Data.Textures[14]); Red_.SetAction(() => UiManager.SetCapsuleColor("Red"));
                WingButton Green_ = Capsule.CreateButton("Green", 1, Data.Textures[14]); Green_.SetAction(() => UiManager.SetCapsuleColor("Green"));
                WingButton Blue_ = Capsule.CreateButton("Blue", 2, Data.Textures[14]); Blue_.SetAction(() => UiManager.SetCapsuleColor("Blue"));
                WingButton Magenta_ = Capsule.CreateButton("Magenta", 3, Data.Textures[14]); Magenta_.SetAction(() => UiManager.SetCapsuleColor("Magenta"));
                WingButton Cyan_ = Capsule.CreateButton("Cyan", 4, Data.Textures[14]); Cyan_.SetAction(() => UiManager.SetCapsuleColor("Cyan"));
                WingButton White_ = Capsule.CreateButton("White", 5, Data.Textures[14]); White_.SetAction(() => UiManager.SetCapsuleColor("White"));

                WingButton Red = Highlights.CreateButton("Red", 0, Data.Textures[14]); Red.SetAction(() => UiManager.SelectColor("Red"));
                WingButton Green = Highlights.CreateButton("Green", 1, Data.Textures[14]); Green.SetAction(() => UiManager.SelectColor("Green"));
                WingButton Blue = Highlights.CreateButton("Blue", 2, Data.Textures[14]); Blue.SetAction(() => UiManager.SelectColor("Blue"));
                WingButton Magenta = Highlights.CreateButton("Magenta", 3, Data.Textures[14]); Magenta.SetAction(() => UiManager.SelectColor("Magenta"));
                WingButton Cyan = Highlights.CreateButton("Cyan", 4, Data.Textures[14]); Cyan.SetAction(() => UiManager.SelectColor("Cyan"));
                WingButton White = Highlights.CreateButton("White", 5, Data.Textures[14]); White.SetAction(() => UiManager.SelectColor("White"));
                WingButton None = Highlights.CreateButton("None", 6, Data.Textures[14]); None.SetAction(() => UiManager.SelectColor("Black"));

                WingButton _Red = VersaUI.CreateButton("Red", 0, Data.Textures[14]); _Red.SetAction(() => UiManager.MenuColor("Red"));
                WingButton _Green = VersaUI.CreateButton("Green", 1, Data.Textures[14]); _Green.SetAction(() => UiManager.MenuColor("Green"));
                WingButton _Blue = VersaUI.CreateButton("Blue", 2, Data.Textures[14]); _Blue.SetAction(() => UiManager.MenuColor("Blue"));
                WingButton _Magenta = VersaUI.CreateButton("Magenta", 3, Data.Textures[14]); _Magenta.SetAction(() => UiManager.MenuColor("Magenta"));
                WingButton _Cyan = VersaUI.CreateButton("Cyan", 4, Data.Textures[14]); _Cyan.SetAction(() => UiManager.MenuColor("Cyan"));
                WingButton _White = VersaUI.CreateButton("White", 5, Data.Textures[14]); _White.SetAction(() => UiManager.MenuColor("White"));
                WingButton _None = VersaUI.CreateButton("None", 6, Data.Textures[14]); _None.SetAction(() => UiManager.MenuColor("Black"));
                #endregion

                WingButton NoClip = Tools.CreateButton("NoClip", 0, Data.Textures[5], Data.Toggle.NoClip);
                NoClip.SetAction(() => Data.Toggle.NoClip = NoClip.State(NoClip, Data.Toggle.NoClip, () => F_Module.NoClip.State(true), () => F_Module.NoClip.State(false)));
                MelonLoader.MelonCoroutines.Start(NoClip.StateUpdate(NoClip, 5));

                WingButton SpeedHack = Tools.CreateButton("SpeedHack", 1, Data.Textures[6], Data.Toggle.SpeedHack);
                SpeedHack.SetAction(() => Data.Toggle.SpeedHack = SpeedHack.State(SpeedHack, Data.Toggle.SpeedHack, () => F_Module.SpeedHack.State(true), () => F_Module.SpeedHack.State(false)));
                MelonLoader.MelonCoroutines.Start(SpeedHack.StateUpdate(SpeedHack, 6));

                WingButton Preview = Tools.CreateButton("PoVPreview", 2, Data.Textures[17], Data.PoVPreview);
                Preview.SetAction(() => Data.PoVPreview = Preview.State(Preview, Data.PoVPreview, () => CameraPreview.State(true), () => CameraPreview.State(false)));
                MelonLoader.MelonCoroutines.Start(Preview.StateUpdate(Preview, 11));

             // WingButton Polygons = Tools.CreateButton("Polygons", 3, Data.Textures[6], Data.Toggle.Polygons);
             // Polygons.SetAction(() => Data.Toggle.Polygons = Polygons.State(Polygons, Data.Toggle.Polygons, () => F_Module.PolygonShow.Enable(), () => F_Module.PolygonShow.Disable()));
             // MelonLoader.MelonCoroutines.Start(Polygons.StateUpdate(Polygons, 21));

                WingButton FOVPlus = Camera.CreateButton("FoV+", 1, Data.Textures[8]);
                FOVPlus.SetAction(() => F_Module.Camera.FoVPlus());

                WingButton FOVMinus = Camera.CreateButton("FoV-", 0, Data.Textures[8]);
                FOVMinus.SetAction(() => F_Module.Camera.FoVMinus());

                WingButton PostProcess = Camera.CreateButton("PostProcess", 2, Data.Textures[13], Data.Toggle.PostProcess);
                PostProcess.SetAction(() => Data.Toggle.PostProcess = PostProcess.State(PostProcess, Data.Toggle.PostProcess, () => F_Module.PostProcess.State(true), () => F_Module.PostProcess.State(false)));
                MelonLoader.MelonCoroutines.Start(PostProcess.StateUpdate(PostProcess, 7));

                WingButton CapsuleEsp = Esp.CreateButton("CapsuleEsp", 0, Data.Textures[9], Data.Toggle.CapsuleEsp);
                CapsuleEsp.SetAction(() => Data.Toggle.CapsuleEsp = CapsuleEsp.State(CapsuleEsp, Data.Toggle.CapsuleEsp, () => F_Module.PlayerEsp.Capsule(true), () => F_Module.PlayerEsp.Capsule(false)));
                MelonLoader.MelonCoroutines.Start(CapsuleEsp.StateUpdate(CapsuleEsp, 18));

                WingButton LineEsp = Esp.CreateButton("LineEsp", 1, Data.Textures[25], Data.Toggle.LineEsp);
                LineEsp.SetAction(() => Data.Toggle.LineEsp = LineEsp.State(LineEsp, Data.Toggle.LineEsp, () => F_Module.PlayerLineEsp.Enable(), () => F_Module.PlayerLineEsp.Disable()));
                MelonLoader.MelonCoroutines.Start(LineEsp.StateUpdate(LineEsp, 17));

                WingButton TriggerEsp = Esp.CreateButton("TriggerEsp", 2, Data.Textures[26], Data.Toggle.TriggerEsp);
                TriggerEsp.SetAction(() => Data.Toggle.TriggerEsp = TriggerEsp.State(TriggerEsp, Data.Toggle.TriggerEsp, () => F_Module.TriggerZoneEsp.Enable(), () => F_Module.TriggerZoneEsp.Disable()));
                MelonLoader.MelonCoroutines.Start(TriggerEsp.StateUpdate(TriggerEsp, 19));

                F_Output.CustomConsole.Console(true, "[OnWingInit finished]");
            }
        });
        private static void ActivateScrollInQM()
        {
            F_Output.CustomConsole.Console(true, "[ActivateScrollInQM started]");
            var scrollRect = QMCache.LaunchPadQmMenu.transform.Find("ScrollRect").gameObject.GetComponent<ScrollRect>();
            var scrollbar = scrollRect.transform.Find("Scrollbar");
            scrollbar.gameObject.SetActive(true);
            scrollRect.enabled = true;
            scrollRect.verticalScrollbar = scrollbar.GetComponent<Scrollbar>();
            scrollRect.verticalScrollbarVisibility = ScrollRect.ScrollbarVisibility.Permanent;
            scrollRect.viewport.GetComponent<RectMask2D>().enabled = true;
            F_Output.CustomConsole.Console(true, "[ActivateScrollInQM finished]");
        }
    }
}
