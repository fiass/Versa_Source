using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Versa.F_Output;
using VRC.SDKBase;

namespace Versa.F_Module
{
    class Popup
    {
        private static VRCUiPopupManager instance = GameObject.FindObjectOfType<VRCUiPopupManager>();
        public static void ShowUnityInputPopupWithCancel(string title, string TextInField, string RightButtonText, Il2CppSystem.Action<string, Il2CppSystem.Collections.Generic.List<KeyCode>, Text> action)
        {
            //if (instance != null) instance.Method_Public_Void_String_String_InputType_Boolean_String_Action_3_String_List_1_KeyCode_Text_Action_String_Boolean_Action_1_VRCUiPopup_5(
            if (instance != null) instance.Method_Public_Void_String_String_InputType_Boolean_String_Action_3_String_List_1_KeyCode_Text_Action_String_Boolean_Action_1_VRCUiPopup_Boolean_Int32_0(
                title, TextInField, InputField.InputType.Standard, false, RightButtonText, action, new Action(() => { }));
        }
        internal static void GoToWorld()
        {
            ShowUnityInputPopupWithCancel("WorldID:InstanceID", "", "Go | Create", new Action<string, Il2CppSystem.Collections.Generic.List<KeyCode>, Text>((string s, Il2CppSystem.Collections.Generic.List<KeyCode> k, Text t) =>
            {
                try
                {
                    Networking.GoToRoom(s.Replace(" ", ""));
                }
                catch (Exception e)
                {
                    CustomConsole.Console(true, "Popup.cs [GoToWorld] " + e.Message);
                }
            }));
        }
    }
}
