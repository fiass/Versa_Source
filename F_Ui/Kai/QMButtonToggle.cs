using System;
using System.Diagnostics;
using Mono.Cecil;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Versa.F_Config;
using VRC.UI.Core.Styles;

namespace Versa.F_Ui
{
    internal class QMButtonToggle : DPUIElement
    {
        protected bool ToggleState { get; private set; }
        protected Image ButtonImage { get; private set; }
        protected TextMeshProUGUI ButtonText { get; private set; }
        protected Action OnAct { get; set; }
        protected Action OffAct { get; set; }
        protected Texture2D OnTexture { get; set; }
        protected Texture2D OffTexture { get; set; }
        internal QMButtonToggle(Transform Parent, string Name, string Text, string Tooltip, Action OnAction, Action OffAction, bool toggleState = false)
        {
            OnAct = OnAction;
            OffAct = OffAction;
            ToggleState = toggleState;
            UIObject = GameObject.Instantiate(QMCache.QMButton, Parent);
            UIObject.name = $"ToggleButton_{Name}";
            GameObject.Destroy(UIObject.GetComponent<MonoBehaviourPublicVoStVoVoVoVoVoVoVoVo3>());
            ButtonText = UIObject.transform.Find("Text_H4").gameObject.GetComponent<TextMeshProUGUI>();
            ButtonImage = UIObject.transform.Find("Icon").GetComponent<Image>();
            Button btn = UIObject.GetComponent<Button>();
            GameObject.Destroy(ButtonImage.gameObject.GetComponent<StyleElement>());
           //SetOnTexture(Data.Textures[2]);
           //SetOffTexture(Data.Textures[3]);
            if (ToggleState == true)
            {
                SetIcon(ButtonImage, OnTexture, new Color(0.1f, 0.8f, 0.1f, 1f));
            }
            else
            {
                SetIcon(ButtonImage, OffTexture, new Color(0.8157f, 0.1f, 0.1f, 1f));
            }
            SetText(Text);
            SetTooltip(Tooltip);
            SetAction(btn, () => SetToggleState());
        }
        internal void SetText(string Text) => ButtonText.text = Text;
        internal void SetOnTexture(Texture2D Tex) => OnTexture = Tex;
        internal void SetOffTexture(Texture2D Tex) => OffTexture = Tex;
        internal void SetToggleState()
        {
            ToggleState = !ToggleState;
            if (ToggleState == true)
            {
                SetIcon(ButtonImage, OnTexture, new Color(0.1f, 0.8f, 0.1f, 1f));
                OnAct();
            }
            else
            {
                SetIcon(ButtonImage, OffTexture, new Color(0.8157f, 0.1f, 0.1f, 1f));
                OffAct();
            }
        }
        internal void SetToggleState(bool State, bool RunFunction = false)
        {
            ToggleState = !ToggleState;
            if (ToggleState == true)
            {
                SetIcon(ButtonImage, OnTexture, new Color(0.1f, 0.8f, 0.1f, 1f));
                if (RunFunction) OnAct();
            }
            else
            {
                SetIcon(ButtonImage, OffTexture, new Color(0.8157f, 0.1f, 0.1f, 1f));
                if (RunFunction) OffAct();
            }
        }
    }
}
