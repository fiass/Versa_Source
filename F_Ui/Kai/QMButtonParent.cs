using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using VRC.UI.Core;

namespace Versa.F_Ui
{
    internal class QMButtonParent : DPUIElement
    {
        internal QMButtonParent(Transform Parent, string Name, string Header, string color)
        {
            GameObject DPHeader = GameObject.Instantiate(QMCache.QMHeader, QMCache.QMHeader.transform.parent);
            DPHeader.name = $"Header_{Name}";
            TextMeshProUGUI HeadText = DPHeader.transform.Find("LeftItemContainer/Text_Title").gameObject.GetComponent<TextMeshProUGUI>();
            if (Header == String.Empty)
                HeadText.gameObject.SetActive(false);
            HeadText.richText = true;
            HeadText.text = $"<color={color}>{Header}</color>";
            UIObject = GameObject.Instantiate(QMCache.QMHeader.transform.parent.Find("Buttons_QuickLinks").gameObject, Parent);
            UIObject.name = $"Buttons_{Name}";
            for (int i = 0; i < UIObject.transform.childCount; i++)
                GameObject.Destroy(UIObject.transform.GetChild(i).gameObject);
        }

        internal QMButton AddButton(string Name, string Text, string Tooltip, Action act, Texture2D Tex = null)
        {
            return new QMButton(UIObject.transform, Name, Text, Tooltip, act, Tex);
        }

        internal QMButtonToggle AddToggle(string Name, string Text, string Tooltip, Action OnAction, Action OffAction, bool toggleState = false)
        {
            return new QMButtonToggle(UIObject.transform, Name, Text, Tooltip, OnAction, OffAction);
        }
    }
}
