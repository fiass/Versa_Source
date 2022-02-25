using System;
using System.Linq;
using Il2CppSystem.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Elements;
using VRC.UI.Elements.Menus;
using Object = UnityEngine.Object;

namespace Versa.F_Ui
{
    internal class QMPage : DPUIElement
    {
        protected string MenuName { get; private set; }
        protected bool IsRoot { get; private set; }
        internal QMButtonParent ButtonParent { get; private set; }
        internal UIPage Page { get; set; }
        protected TextMeshProUGUI HeaderText { get; set; }

        internal QMPage(string Name, string Title, bool Root = true) =>
            Create(Name, Title, Root);

        private void Create(string Name, string Title, bool Root = true)
        {
            MenuName = Name;
            IsRoot = Root;
            UIObject = Object.Instantiate(QMCache.QMMenu, QMCache.QMMenu.transform.parent);
            UIObject.name = $"VersaMenu{MenuName}";
            Object.DestroyImmediate(UIObject.GetComponent<DevMenu>());
            var Header = UIObject.transform.GetChild(0).gameObject;
            Header.name = $"Header_{MenuName}";
            HeaderText = Header.transform.Find("LeftItemContainer/Text_Title").gameObject.GetComponent<TextMeshProUGUI>();
            HeaderText.text = $"<color=red>{Title}</color>";
            GameObject[] SubObjects = new GameObject[]
            {
                UIObject.transform.Find("Scrollrect").gameObject,
                UIObject.transform.Find("Scrollrect/Viewport").gameObject,
                UIObject.transform.Find("Scrollrect/Viewport/VerticalLayoutGroup").gameObject
            };
            var VerticleLayoutGroup = SubObjects[2].transform;
            for (var i = 0; i < VerticleLayoutGroup.childCount; i++) Object.Destroy(VerticleLayoutGroup.GetChild(i).gameObject);
            if (!IsRoot)
            {
                var backButton = Header.GetComponentInChildren<Button>(true);
                backButton.gameObject.SetActive(true);
            }


        }

        internal void Open()
        {
           // GetQuickMenuInstance..Method_Public_Void_String_UIContext_Boolean_0($"VersaMenu{MenuName}");
        }

        internal void Close()
        {
            Page.Method_Public_Virtual_New_Void_0();
        }
    }
}
