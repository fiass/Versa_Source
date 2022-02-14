using Versa.F_Config;
using Versa.F_Core;
using MelonLoader;
using System;
using System.Collections;
using UnityEngine;
using static Versa.F_Ui.Wing;

namespace Versa
{
    internal static class BuildInfo
    {
        public const string Name = "Versa";
        public const string Description = "Hi cute";
        public const string Author = "Null";
        public const string Company = "Blackout";
        public const string Version = "2.3.6";
        public const string DownloadLink = "";
    }

    internal class Main : MelonMod
    {
       
        public override async void OnApplicationStart()
        {
            Core.OnApplicationStart();
            Initialize();
        }
        private static bool hasInitialized = false;
        public static async void Initialize()
        {
            if (hasInitialized) return;
            hasInitialized = true;

            MelonCoroutines.Start(FindUI());
        }

        private static  IEnumerator FindUI()
        {
            while ((Misc.UserInterface = GameObject.Find("UserInterface")?.transform) is null)
                yield return null;

            while ((Misc.QuickMenu = Misc.UserInterface.Find("Canvas_QuickMenu(Clone)")) is null)
                yield return null;

            Left.Setup(Misc.QuickMenu.Find("Container/Window/Wing_Left"));
            Right.Setup(Misc.QuickMenu.Find("Container/Window/Wing_Right"));

            Left.WingOpen.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(new Action(() => Init_L()));
            Right.WingOpen.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(new Action(() => Init_R()));
        }
        private static  Action Init_L = new Action(() =>
        {
            Init_L = new Action(() => { });
            GenerateUi.OnWingInit(Left);
        });

        private static Action Init_R = new Action(() =>
        {
            Init_R = new Action(() => { });
            GenerateUi.OnWingInit(Right);
        });

        public override void OnApplicationLateStart()
        {
            
        }

        public override void OnSceneWasLoaded(int buildindex, string sceneName)
        {
            
        }

        public override async void OnSceneWasInitialized(int buildindex, string sceneName)
        {
            Core.OnSceneWasInitialized();

        }

        public override async void OnUpdate()
        {
            Core.OnUpdate();
            if (!Data.PlayerNetIsInitialized & PlayerApi.playerNet() != null)
            {
                Data.PlayerNetIsInitialized = true;
                Core.OnPlayerNetWasInitialized();
            }
            if (!Data.UiIsInitialized & UiApi.UiManager_GameObject() != null)
            {
                Data.UiIsInitialized = true;
                Core.OnUiWasInitialized();
            }
        }

        public override void OnFixedUpdate()
        {
        }

        public override void OnLateUpdate()
        {
        }

        public override async void OnGUI()
        {
            Core.OnGui();
        }

        public override async void OnApplicationQuit()
        {
            Core.OnApplicationQuit();
        }

        public override void OnPreferencesSaved()
        {
        }

        public override void OnPreferencesLoaded()
        {
        }


    }
}