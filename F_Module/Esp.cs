using MelonLoader;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VRC;
using VRC.SDKBase;
using System.Text;
using System.Threading.Tasks;
using Versa.F_Core;
using Versa.F_Ui;
using Versa.F_Output;
using Versa.F_Config;

namespace Versa.F_Module
{
    class PlayerEsp
    {
        #region CapsuleESP
        private static bool _b;
        internal static void Switch()
        {
            switch (Data.Toggle.CapsuleEsp)
            {
                case true:
                    Capsule(false);
                    Data.Toggle.CapsuleEsp = false;
                    break;
                case false:
                    Capsule(true);
                    Data.Toggle.CapsuleEsp = true;
                    break;
            }
        }
        internal static void Capsule(bool state)
        {
            switch (state)
            {
                case true:
                    _b = state;
                    MelonCoroutines.Start(ActivateCapsule());
                    break;
                case false:
                    _b = state;
                    break;
            }
        }
        private static IEnumerator ActivateCapsule()
        {
            while (_b)
            {
                try
                {
                    Highlights(_b);
                }
                catch (Exception e) { CustomConsole.Console(true, e.Message); }

                yield return new WaitForSeconds(1f);
            }
            Highlights(_b);
        }
        private static void Highlights(bool _a)
        {
            try
            {
                GameObject[] array = GameObject.FindGameObjectsWithTag("Player");
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i].transform.Find("SelectRegion"))
                    {
                        array[i].transform.Find("SelectRegion").GetComponent<Renderer>().sharedMaterial.SetColor("_Color", UiManager.StringToColor(Prefs.String.Load("CapsuleColor")));
                        if (_a)
                        {
                            HighlightsFX.prop_HighlightsFX_0.Method_Public_Void_Renderer_Boolean_0(
                                                         array[i].transform.Find("SelectRegion").GetComponent<Renderer>(), true);
                        }
                        else
                        {
                            HighlightsFX.prop_HighlightsFX_0.Method_Public_Void_Renderer_Boolean_0(
                                                          array[i].transform.Find("SelectRegion").GetComponent<Renderer>(), false);
                        }
                    }
                }
            }
            catch (Exception e) { CustomConsole.Console(true, "PlayerEsp.cs [Highlights] " + e.Message); }
        }
        #endregion
        private static void Lines()
        {
            GameObject[] array = GameObject.FindGameObjectsWithTag("Player");

        }
    }
    class PlayerLineEsp
    {

        private static LineRenderer line1;
        static internal int _u;
        private static Il2CppSystem.Collections.Generic.List<GameObject> Texts = new Il2CppSystem.Collections.Generic.List<GameObject>();
        private static Il2CppSystem.Collections.Generic.List<Player> VRC_PlayerList = new Il2CppSystem.Collections.Generic.List<Player>();
        public static Il2CppSystem.Collections.Generic.List<Player> AllPlayer = new Il2CppSystem.Collections.Generic.List<Player>();

        internal static void Enable()
        {
            Data.Toggle.LineEsp = true;
            MelonCoroutines.Start(LineESP());
        }
        internal static void Disable()
        {
            Clear();
        }
        internal static void Clear()
        {
            foreach (var Player in VRC_PlayerList)
            {
                try
                {
                    Player.prop_VRCPlayer_0.prop_VRCAvatarManager_0.GetComponent<LineRenderer>().enabled = false;
                }
                catch { }
            }
            foreach (var text in Texts)
            {
                try
                {
                    UnityEngine.Object.Destroy(text);
                }
                catch { }
            }
            Texts.Clear();
            VRC_PlayerList.Clear();
        }

        internal static void ForceDisableLine()
        {
            try
            {
                Data.Toggle.LineEsp = false;
                Clear();
            }
            catch { }
        }
        internal static IEnumerator LineESP()
        {
        Refresh:
            Clear();
            if (PlayerApi.MyVRCPlayer() != null)
            {
                AllPlayer = PlayerApi.AllVRCPlayers();
                foreach (Player Remote in AllPlayer)
                {
                    try
                    {
                        line1 = Remote.prop_VRCPlayer_0.prop_VRCAvatarManager_0.gameObject.GetOrAddComponent<LineRenderer>();
                        line1.enabled = true;
                        line1.startWidth = 0.001f;
                        line1.alignment = LineAlignment.View;
                        line1.material = new Material(Shader.Find("GUI/Text Shader"));
                        line1.material.color = new Color(1f, 1f, 1f, 0.5f);
                        if (Remote.prop_APIUser_0.id != PlayerApi.ID())
                        {
                            VRC_PlayerList.Add(Remote);
                        }
                    }
                    catch { }
                    try
                    {
                        #region TextEsp

                        if (Remote.prop_APIUser_0.id != PlayerApi.ID())
                        {
                            if (Remote.prop_VRCPlayerApi_0.displayName != "<uninitialized>")
                            {
                                GameObject text = new GameObject();
                                text.transform.SetParent(Remote.transform);
                                text.name = "LookAtText";
                                text.GetOrAddComponent<MeshRenderer>().enabled = true;
                                TextMesh textMesh = text.GetOrAddComponent<TextMesh>();
                                textMesh.fontSize = 10;
                                textMesh.text = Remote.prop_VRCPlayerApi_0.displayName;
                                textMesh.color = new Color(1f, 1f, 1f, 0.1f);
                                textMesh.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
                                text.transform.localPosition = new Vector3(0, 1, 0);
                                text.transform.localScale = new Vector3(0.03f, 0.03f, 0.03f);
                                Texts.Add(text);
                            }
                            else { goto Refresh; }
                        }

                        #endregion TextEsp
                    }
                    catch (Exception e) { CustomConsole.Console(true, "ESP.cs [TextEsp] " + e.Message); }
                }
                while (Data.Toggle.LineEsp)
                {
                    try
                    {
                        if (AllPlayer.ToArray().Length != _u)
                        {
                            _u = AllPlayer.ToArray().Length;
                            goto Refresh;
                        }
                        foreach (var Player in VRC_PlayerList)
                        {
                            try
                            {
                                Player.prop_VRCPlayer_0.prop_VRCAvatarManager_0.gameObject.GetComponent<LineRenderer>().SetPosition(0, Player.prop_VRCPlayerApi_0.GetBoneTransform(HumanBodyBones.Hips).position);
                                // if (sw2)
                                Player.prop_VRCPlayer_0.prop_VRCAvatarManager_0.gameObject.GetComponent<LineRenderer>().SetPosition(1, UnityEngine.Camera.current.transform.position + UnityEngine.Camera.current.transform.forward * 0.3f);
                                //   else
                                //      Player.prop_VRCPlayer_0.prop_VRCAvatarManager_0.gameObject.GetComponent<LineRenderer>().SetPosition(1, PlayerApi.MyPlayer().prop_VRCPlayerApi_0.GetBonePosition(HumanBodyBones.LeftHand));

                            }
                            catch { }
                        }
                        foreach (var text in Texts)
                        {
                            try
                            {
                                text.GetComponent<TextMesh>().fontSize = Convert.ToInt32(Math.Round(10 * Vector3.Distance(text.transform.position, UnityEngine.Camera.current.transform.position), 0));
                                text.transform.LookAt(UnityEngine.Camera.main.transform);
                                text.transform.Rotate(0, 180, 0);
                            }
                            catch { }
                        }
                    }
                    catch (Exception e) { CustomConsole.Console(true, "ESP.cs [LineEsp] " + e.Message); ForceDisableLine(); }
                    yield return new WaitForSeconds(0.01f);
                }
            }
            else
            {
                ForceDisableLine();
            }
        }
    }
    class TriggerZoneEsp
    {

        public static Il2CppSystem.Collections.Generic.List<Material> materials = new Il2CppSystem.Collections.Generic.List<Material>();
         static VRC_Interactable[] VRC_Triggers;
        internal static void Enable()
        {
            VRC_Triggers = null;
            materials.Clear();
            VRC_Triggers = UnityEngine.Object.FindObjectsOfType<VRC_Interactable>();
            foreach (var VRC_Trigger in VRC_Triggers)
            {
                try
                {
                    materials.Add(VRC_Trigger.gameObject.GetOrAddComponent<MeshRenderer>().material);
                    VRC_Trigger.gameObject.GetOrAddComponent<MeshRenderer>().material = new Material(Shader.Find("GUI/Text Shader")); 
                }
                catch { }
            }
        }
        internal static void Disable()
        {
            for(int i = 0; i != materials.Count; i++)
            {
                try
                {
                    VRC_Triggers[i].gameObject.GetOrAddComponent<MeshRenderer>().material = materials[i];
                }
                catch { }
            }
            materials.Clear();
        }
    }
}
