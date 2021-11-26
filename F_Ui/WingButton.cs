using System;
using UnityEngine;
using UnityEngine.UI;
using Versa.F_Config;
using VRC.UI.Core.Styles;
using Object = UnityEngine.Object;

namespace Versa.F_Ui
{
    public class WingButton
    {
        public Wing.BaseWing wing;
        public TMPro.TextMeshProUGUI text;
        public Transform transform;
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
        internal void SetColor(Color color)
        {
            transform.GetComponentInChildren<TMPro.TextMeshProUGUI>().color = color;
        }
        public WingButton(Wing.BaseWing wing, string name, Transform parent, int pos, System.Action onClick, Texture2D texture)
        {
            this.wing = wing;
            //.Find("ScrollRect/Viewport/VerticalLayoutGroup")
            transform = Object.Instantiate(wing.ProfileButton, parent);
            transform.gameObject.name = "Button_" + name;
            transform.gameObject.transform.Find("Container/Icon").gameObject.GetComponent<Graphic>().color = Color.white;
            GameObject.Destroy(transform.gameObject.transform.Find("Container/Icon").gameObject.GetComponent<StyleElement>());
            SetIcon(transform.gameObject.transform.Find("Container/Icon").gameObject.GetComponent<Image>(), texture);
          
            transform.GetComponent<RectTransform>().sizeDelta = new Vector2(420, 144);
            transform.transform.localPosition = new Vector3(0, pos, transform.transform.localPosition.z);
           
            (text = transform.GetComponentInChildren<TMPro.TextMeshProUGUI>()).text = name;

            Button button = transform.GetComponent<Button>();
            button.onClick = new Button.ButtonClickedEvent();
            button.onClick.AddListener(onClick);
        }
        internal void SetAction(System.Action onClick)
        {
            Button button = transform.GetComponent<Button>();
            button.onClick = new Button.ButtonClickedEvent();
            button.onClick.AddListener(onClick);
        }
        public WingButton(WingPage page, string name, int index, Texture2D texture)
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
        }
    }
}
