using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Core.Styles;

namespace Versa.F_Ui
{
    internal class QMButton : DPUIElement
    {
        protected Image ButtonImage { get; private set; }
        protected TextMeshProUGUI ButtonText { get; private set; }
        internal QMButton(Transform Parent, string Name, string Text, string Tooltip, Action act, Texture2D Tex = null)
        {
            UIObject = GameObject.Instantiate(QMCache.QMButton, Parent);
            UIObject.name = $"ToggleButton_{Name}";
            GameObject.Destroy(UIObject.GetComponent<MonoBehaviourPublicVoStVoVoVoVoVoVoVoVo3>());
            ButtonText = UIObject.transform.Find("Text_H4").gameObject.GetComponent<TextMeshProUGUI>();
            ButtonImage = UIObject.transform.Find("Icon").GetComponent<Image>();
            Button btn = UIObject.GetComponent<Button>();
            GameObject.Destroy(ButtonImage.gameObject.GetComponent<StyleElement>());
            SetText(Text);
            SetTooltip(Tooltip);
            SetAction(btn, act);
            if (Tex != null)
                SetIcon(ButtonImage, Tex, new Color(1f, 1f, 1f, 1f));
        }
        internal bool State(bool state, Action On, Action Off)
        {
            switch (state)
            {
                case true:
                    Off();
                    return false;
                case false:
                    On();
                    return true;
            }
            return false;
        }
        internal void SetText(string Text) => ButtonText.text = Text;
    }
}
