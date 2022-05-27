using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using VRC.UI.Core.Styles;
using VRC.UI.Elements.Controls;

namespace Versa.F_Ui
{
    internal class QMTab : DPUIElement
    {
        private GameObject Badge { get; set; }
        private GameObject Icon { get; set; }
        internal QMTab(string Name, string Tooltip, Action act, string Base64)
        {
            UIObject = GameObject.Instantiate(QMCache.QMTab, QMCache.QMTab.transform.parent);
            UIObject.name = $"Page_{Name}";
            StyleElement TabStyle = UIObject.GetComponent<StyleElement>();
            TabStyle.field_Public_String_0 = Name.ToLower();
            MenuTab NoFuckingClue = UIObject.GetComponent<QMTab>();
            NoFuckingClue.field_Public_String_0 = $"QuickMenu{Name}";
            SetTooltip(Tooltip);
            Button btn = UIObject.GetComponent<Button>();
            btn.onClick.RemoveAllListeners();
            btn.onClick = new Button.ButtonClickedEvent();
            btn.onClick.AddListener(UnhollowerRuntimeLib.DelegateSupport.ConvertDelegate<UnityAction>(act));
            UIObject.SetActive(true);
            Badge = UIObject.transform.Find("Badge").gameObject;
            Icon = UIObject.transform.Find("Icon").gameObject;
            Icon.GetComponent<RectTransform>().sizeDelta *= new Vector2(2, 2);
            GameObject.Destroy(Icon.GetComponent<StyleElement>());
            if (!string.IsNullOrEmpty(Base64)) SetIcon(Base64);
        }

        internal void SetBadge(string Text, bool Active = true)
        {
            Badge.SetActive(Active);
            Badge.transform.Find("Text_QM_H5").GetComponent<TextMeshProUGUI>().text = Text;
        }

        internal void SetIcon(string Base64)
        {
            byte[] imagedata = Convert.FromBase64String(Base64);
            Texture2D icontexture = new Texture2D(2, 2, TextureFormat.ARGB32, false);
            ImageConversion.LoadImage(icontexture, imagedata);
            Icon.GetComponent<Image>().sprite = new Sprite();
            Material test = new Material(Shader.Find("VRChat/UI/Default"));
            test.mainTexture = icontexture;
            Icon.GetComponent<Image>().material = test;
        }
    }
}
