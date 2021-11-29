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

namespace Versa.F_Core
{
    internal class GenerateUi
    {
        internal static GameObject Stats;
        public static void IniUi()
        {
            F_Output.CustomConsole.Console(true, "[IniUi started]");
            ActivateScrollInQM();
            Network.DownloadIconPack();
            // QMButtonParent Versa_QM = new QMButtonParent(QMCache.QMHeader.transform.parent, "Versa", "Versa Quick", "#004166");
            // QMPage Versa_Page_1 = new QMPage("VersaPage", "VersaPage");
            // QMButton NoClip = Versa_QM.AddButton("NoClip", "NoClip", "", Data.Textures[5]); NoClip.SetAction(() => Data.Toggle.NoClip = NoClip.State(Data.Toggle.NoClip, () => F_Module.NoClip.State(true), () => F_Module.NoClip.State(false)));
            // QMButton Speed = Versa_QM.AddButton("Speed", "Speed", "", Data.Textures[6]); Speed.SetAction(() => Data.Toggle.SpeedHack = Speed.State(Data.Toggle.SpeedHack, () => F_Module.SpeedHack.State(true), () => F_Module.SpeedHack.State(false)));
            // QMButton Optimization = Versa_QM.AddButton("Optimization", "Optimization", "", Data.Textures[3]); Optimization.SetAction(() => Data.Toggle.Optimization = Optimization.State(Data.Toggle.Optimization, () => F_Module.Optimization.State(true), () => F_Module.Optimization.State(false)));
            F_Output.CustomConsole.Console(true, "[IniUi finished]");
            Stats = GameObject.Instantiate(Data.VersaStats, GameObject.Find("/UserInterface/PlayerDisplay/").transform);
            MelonCoroutines.Start(OneSecUpdate.Enable());
        }
        public static Action<BaseWing> OnWingInit = new Action<BaseWing>(wing =>
        {
            if (Server.Access())
            {
                F_Output.CustomConsole.Console(true, "[OnWingInit started]");
                WingPage Versa = wing.CreatePage("Versa");
                WingPage Tools = Versa.CreateNestedPage("Tools", 0);
                WingPage Camera = Versa.CreateNestedPage("Camera", 3);
                WingPage Esp = Versa.CreateNestedPage("Esp", 4);
                WingPage World = Versa.CreateNestedPage("World", 2);
                WingPage Self = Versa.CreateNestedPage("Self", 1);
                WingPage Settings = Versa.CreateNestedPage("Settings", 5);
                //  WingPage DevStuff = Versa.CreateNestedPage("DevStuff", 7);
                WingPage Selected = Versa.CreateNestedPage("Selected", 6);
                WingPage Highlights = Settings.CreateNestedPage("HighlightsFX", 0);
                WingPage Capsule = Settings.CreateNestedPage("CapsuleFX", 1);

                WingButton Gravity = World.CreateButton("MoonGravity", 0, Data.Textures[2], Data.Toggle.MoonGravity); 
                Gravity.SetAction(() => Data.Toggle.MoonGravity = Gravity.State(Gravity, Data.Toggle.MoonGravity, F_Module.Gravity.Moon, F_Module.Gravity.Standard));
                MelonLoader.MelonCoroutines.Start(Gravity.StateUpdate(Gravity, 1));

                WingButton BlockPortals = World.CreateButton("BlockPortals", 3, Data.Textures[18], Data.Toggle.BlockPortals);
                BlockPortals.SetAction(() => Data.Toggle.BlockPortals = BlockPortals.State(BlockPortals, Data.Toggle.BlockPortals, ()=>Portals.State(true), () => Portals.State(false)));
                MelonLoader.MelonCoroutines.Start(BlockPortals.StateUpdate(BlockPortals, 8));

                WingButton OptimizationWorld = World.CreateButton("Optimization", 1, Data.Textures[3], Data.Toggle.Optimization);
                OptimizationWorld.SetAction(() => Data.Toggle.Optimization = OptimizationWorld.State(OptimizationWorld, Data.Toggle.Optimization, () => Optimization.State(true), () => Optimization.State(false)));
                MelonLoader.MelonCoroutines.Start(OptimizationWorld.StateUpdate(OptimizationWorld, 2));

                WingButton WorldLogs = Settings.CreateButton("WorldLogs", 2, Data.Textures[19], Data.WorldLog);
                WorldLogs.SetAction(() => Data.WorldLog = WorldLogs.State(WorldLogs, Data.WorldLog));
                MelonLoader.MelonCoroutines.Start(WorldLogs.StateUpdate(WorldLogs, 9));

                WingButton WorldID = World.CreateButton("ID:Instance", 5, Data.Textures[16]); 
                WorldID.SetAction(() => Clipboard.WorldFullID());

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

                WingButton DownloadVRCA_Me = Self.CreateButton("DL VRCA", 1, Data.Textures[7]);
                DownloadVRCA_Me.SetAction(() => VRCA.DownloadMe());
               
                WingButton GoTo = Self.CreateButton("JoinByID", 2, Data.Textures[15]); 
                GoTo.SetAction(() => Popup.GoToWorld());

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
                #endregion

                WingButton NoClip = Tools.CreateButton("NoClip", 0, Data.Textures[5], Data.Toggle.NoClip); 
                NoClip.SetAction(() => Data.Toggle.NoClip = NoClip.State(NoClip, Data.Toggle.NoClip, () => F_Module.NoClip.State(true), () => F_Module.NoClip.State(false)));
                MelonLoader.MelonCoroutines.Start(NoClip.StateUpdate(NoClip, 5));

                WingButton SpeedHack = Tools.CreateButton("SpeedHack", 1, Data.Textures[6], Data.Toggle.SpeedHack);  
                SpeedHack.SetAction(() => Data.Toggle.SpeedHack = SpeedHack.State(SpeedHack, Data.Toggle.SpeedHack, () => F_Module.SpeedHack.State(true), () => F_Module.SpeedHack.State(false)));
                MelonLoader.MelonCoroutines.Start(SpeedHack.StateUpdate(SpeedHack, 6));

                WingButton Preview = Tools.CreateButton("FoVPreview", 2, Data.Textures[17], Data.FoVPreview); 
                Preview.SetAction(() => Data.FoVPreview = Preview.State(Preview, Data.FoVPreview, () => CameraPreview.State(true), () => CameraPreview.State(false)));
                MelonLoader.MelonCoroutines.Start(Preview.StateUpdate(Preview, 11));

                WingButton FOVPlus = Camera.CreateButton("FoV+", 1, Data.Textures[8]); 
                FOVPlus.SetAction(() => F_Module.Camera.FoVPlus());
                
                WingButton FOVMinus = Camera.CreateButton("FoV-", 0, Data.Textures[8]); 
                FOVMinus.SetAction(() => F_Module.Camera.FoVMinus());               
               
                WingButton PostProcess = Camera.CreateButton("PostProcess", 2, Data.Textures[13], Data.Toggle.PostProcess);
                PostProcess.SetAction(() => Data.Toggle.PostProcess = PostProcess.State(PostProcess, Data.Toggle.PostProcess, () => F_Module.PostProcess.State(true), () => F_Module.PostProcess.State(false)));
                MelonLoader.MelonCoroutines.Start(PostProcess.StateUpdate(PostProcess, 7));

                WingButton CapsuleEsp = Esp.CreateButton("CapsuleEsp", 0, Data.Textures[9], Data.Toggle.CapsuleEsp);
                CapsuleEsp.SetAction(() => Data.Toggle.CapsuleEsp = CapsuleEsp.State(CapsuleEsp, Data.Toggle.CapsuleEsp, () => F_Module.PlayerEsp.Capsule(true), () => F_Module.PlayerEsp.Capsule(false)));
                MelonLoader.MelonCoroutines.Start(CapsuleEsp.StateUpdate(CapsuleEsp, 8));

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
