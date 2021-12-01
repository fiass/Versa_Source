using System;
using System.Linq;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Encoders;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using VRC.UI.Core.Styles;
using VRC.UI.Elements;

namespace Versa.F_Ui
{
    internal class DPUIElement
    {
        protected GameObject UIObject { get; set; }
        internal void Destroy()
        {
            try
            {
                GameObject.Destroy(UIObject);
            }
            catch { }
        }

        internal void SetTooltip(string Text)
        {
            if (UIObject.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>() != null)
                UIObject.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = Text;
        }

        internal GameObject GetObject => UIObject;

        internal void SetActive(bool State) => UIObject.SetActive(State);

        internal static void SetIcon(Image img, Texture2D Base64, Color clr)
        {
            if (img.gameObject.GetComponent<StyleElement>() != null)
                GameObject.Destroy(img.gameObject.GetComponent<StyleElement>());
            img.color = clr;
            img.sprite = new Sprite();
            Material test = new Material(Shader.Find("VRChat/UI/Default"));
            test.mainTexture = Base64;
            img.material = test;
        }

        internal static void SetAction(Button btn, Action act)
        {
            btn.onClick.RemoveAllListeners();
            btn.onClick = new Button.ButtonClickedEvent();
            btn.onClick.AddListener(UnhollowerRuntimeLib.DelegateSupport.ConvertDelegate<UnityAction>(act));
        }
        internal static VRC.UI.Elements.MainMenu GetQuickMenuInstance =>
            Resources.FindObjectsOfTypeAll<VRC.UI.Elements.MainMenu>().FirstOrDefault();

        internal static MenuStateController GetMenuStateControllerInstance =>
            GetQuickMenuInstance.gameObject.GetComponent<MenuStateController>();
    }
}
