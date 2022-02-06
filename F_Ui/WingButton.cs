using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Versa.F_Config;
using Versa.F_Output;
using VRC.UI.Core.Styles;
using Object = UnityEngine.Object;

namespace Versa.F_Ui
{
    public class WingButton
    {
        public Wing.BaseWing wing;
        public Transform transform;
        private TextMeshProUGUI text;
        internal void SetIcon(Image image, Texture2D texture)
        {

            image.sprite = new Sprite();
            image.material = new Material(image.material)
            {
                mainTexture = texture
            };
        }
        internal bool State(WingButton button, bool state, Action On, Action Off)
        {
            switch (state)
            {
                case true:
                    Off();
                    button.SetColor(Color.red);
                    return false;
                case false:
                    On();
                    button.SetColor(Color.green);
                    return true;
            }
            return false;
        }
        internal bool State(WingButton button, bool state)
        {
            switch (state)
            {
                case true:
                    button.SetColor(Color.red);
                    return false;
                case false:
                    button.SetColor(Color.green);
                    return true;
            }
            return false;
        }
        internal IEnumerator StateUpdate(WingButton button, int value)
        {
            CustomConsole.Console(true,$"[Synchronization {button.text.text}]");
             while(true)
            {
                try
                {
                    if (Data.LeftWing | Data.RightWing)
                    {
                        switch (Data.Toggle.ToggleIndex(value))
                        {
                            case false:
                                button.SetColor(Color.red);
                                break;
                            case true:
                                button.SetColor(Color.green);
                                break;
                        }
                    }
                }
                catch { }
                yield return new WaitForSeconds(1.46f);
            }
        }
        internal void SetColor(Color color)
        {
            transform.GetComponentInChildren<TMPro.TextMeshProUGUI>().color = Color.white;
            transform.GetComponentInChildren<TMPro.TextMeshProUGUI>().colorGradient = new VertexGradient(color, Color.gray,color,color);
        }
        internal void SetAction(System.Action onClick)
        {
            Button button = transform.GetComponent<Button>();
            button.onClick = new Button.ButtonClickedEvent();
            button.onClick.AddListener(onClick);
        }
        public WingButton(WingPage page, string name, int index, Texture2D texture, bool state)
        {
            wing = page.wing;

            transform = Object.Instantiate(wing.ProfileButton, page.transform);
            transform.gameObject.name = "Button_"+name;
            transform.gameObject.transform.Find("Container/Icon").gameObject.GetComponent<Graphic>().color = Color.white;
            GameObject.Destroy(transform.gameObject.transform.Find("Container/Icon").gameObject.GetComponent<StyleElement>());
            SetIcon(transform.gameObject.transform.Find("Container/Icon").gameObject.GetComponent<Image>(), texture);
            transform.GetComponent<RectTransform>().sizeDelta = new Vector2(420, 144);
            transform.transform.localPosition = new Vector3(0, 320 - (index * 120), transform.transform.localPosition.z);

            (text = transform.GetComponentInChildren<TMPro.TextMeshProUGUI>()).text = name;
            Object.Destroy(text.gameObject.GetComponent<StyleElement>());
            text.m_colorMode = ColorMode.VerticalGradient;
            text.enableVertexGradient = true;
            if (state)
                SetColor(Color.green);
            else
                SetColor(Color.red);
            transform.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = "Don't know what the function is?\n Versa => Settings => Manual";
        }
        public WingButton(WingPage page, string name, int index, Texture2D texture)
        {
            wing = page.wing;

            transform = Object.Instantiate(wing.ProfileButton, page.transform);
            transform.gameObject.name = "Button_" + name;
            transform.gameObject.transform.Find("Container/Icon").gameObject.GetComponent<Graphic>().color = Color.white;
            GameObject.Destroy(transform.gameObject.transform.Find("Container/Icon").gameObject.GetComponent<StyleElement>());
            SetIcon(transform.gameObject.transform.Find("Container/Icon").gameObject.GetComponent<Image>(), texture);
            transform.GetComponent<RectTransform>().sizeDelta = new Vector2(420, 144);
            transform.transform.localPosition = new Vector3(0, 320 - (index * 120), transform.transform.localPosition.z);

            (text = transform.GetComponentInChildren<TMPro.TextMeshProUGUI>()).text = name;
            Object.Destroy(text.gameObject.GetComponent<StyleElement>());
            text.m_colorMode = ColorMode.VerticalGradient;
            text.enableVertexGradient = true;
            SetColor(Color.cyan);
            transform.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = "Don't know what the function is?\n Versa => Settings => Manual";
        }
    }
}
