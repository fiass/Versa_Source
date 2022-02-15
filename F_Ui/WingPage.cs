using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Versa.F_Config;
using Versa.F_Core;
using VRC.UI.Core.Styles;

namespace Versa.F_Ui
{
    public class WingPage
    {
        public Wing.BaseWing wing;
        public Transform transform;
        public TMPro.TextMeshProUGUI text;
        public Button closeButton;
        public Image image;
        public Button openButton;
        internal void SetIcon(Image image, Texture2D texture)
        {

            image.sprite = new Sprite();
            image.material = new Material(image.material)
            {
                mainTexture = texture
            };
        }
        public WingPage(Wing.BaseWing wing, string name)
        {
            this.wing = wing;

            transform = Object.Instantiate(wing.ProfilePage, wing.WingPages);
            Transform content = transform.Find("ScrollRect/Viewport/VerticalLayoutGroup");
            transform.gameObject.SetActive(false);
            transform.gameObject.name = "Page_" + name;

            for (int i = 0; i < content.GetChildCount(); i++)
                Object.Destroy(content.GetChild(i).gameObject);
            transform.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = name;


            closeButton = transform.GetComponentInChildren<Button>();
            closeButton.gameObject.name = "Close_" + name;
            closeButton.onClick = new Button.ButtonClickedEvent();
            closeButton.onClick.AddListener(new System.Action(() =>
            {
                transform.gameObject.SetActive(false);
                wing.openedPages.RemoveAt(wing.openedPages.Count - 1);
                if (wing.openedPages.Count > 0)
                {
                    WingPage prev = wing.openedPages[wing.openedPages.Count - 1];
                    prev.transform.gameObject.SetActive(true);
                }
                else wing.WingMenu.gameObject.SetActive(true);
            }));

            Transform open = Object.Instantiate(wing.ProfileButton, wing.WingButtons);
            (text = open.GetComponentInChildren<TMPro.TextMeshProUGUI>()).text = name;
            Object.Destroy(text.gameObject.GetComponent<StyleElement>());
            text.m_colorMode = ColorMode.VerticalGradient;
            text.enableVertexGradient = true;
            text.color = Color.white;
            text.colorGradient = new VertexGradient(Color.cyan, Color.white, Color.cyan, Color.cyan);
            openButton = open.GetComponent<Button>();
            openButton.gameObject.transform.Find("Container/Icon").gameObject.GetComponent<Graphic>().color = Color.white;
            GameObject.Destroy(openButton.gameObject.transform.Find("Container/Icon").gameObject.GetComponent<StyleElement>());
            SetIcon(openButton.gameObject.transform.Find("Container/Icon").gameObject.GetComponent<Image>(), Data.Textures[0]);
            openButton.gameObject.name = "Open_" + name;
            openButton.gameObject.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = "Versa UI";
            openButton.onClick = new Button.ButtonClickedEvent();
            openButton.onClick.AddListener(new System.Action(() => {
                transform.gameObject.SetActive(true);
                wing.openedPages.Add(this);
                if (wing.openedPages.Count > 1)
                {
                    WingPage prev = wing.openedPages[wing.openedPages.Count - 2];
                    prev.transform.gameObject.SetActive(false);
                }
                else wing.WingMenu.gameObject.SetActive(false);
            }));
        }

        public WingPage(WingPage page, string name, int index, Texture2D texture)
        {
            if (Data.Is)
            {
                wing = page.wing;

                transform = Object.Instantiate(wing.ProfilePage, wing.WingPages);
                Transform content = transform.Find("ScrollRect/Viewport/VerticalLayoutGroup");
                transform.gameObject.SetActive(false);
                transform.gameObject.name = "Page_" + name;

                for (int i = 0; i < content.GetChildCount(); i++)
                    Object.Destroy(content.GetChild(i).gameObject);
                transform.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = name;

                closeButton = transform.GetComponentInChildren<Button>();
                closeButton.gameObject.name = "Close_" + name;
                closeButton.onClick = new Button.ButtonClickedEvent();
                closeButton.onClick.AddListener(new System.Action(() =>
                {
                    transform.gameObject.SetActive(false);
                    wing.openedPages.RemoveAt(wing.openedPages.Count - 1);
                    if (wing.openedPages.Count > 0)
                    {
                        WingPage prev = wing.openedPages[wing.openedPages.Count - 1];
                        prev.transform.gameObject.SetActive(true);
                    }
                    else wing.WingMenu.gameObject.SetActive(true);
                }));
            }
            Transform open = Object.Instantiate(wing.ProfileButton, page.transform);
            (text = open.GetComponentInChildren<TMPro.TextMeshProUGUI>()).text = name;
            Object.Destroy(text.gameObject.GetComponent<StyleElement>());
            text.m_colorMode = ColorMode.VerticalGradient;
            text.enableVertexGradient = true;
            text.color = Color.white;
            text.colorGradient = new VertexGradient(Color.cyan, Color.white, Color.cyan, Color.cyan);
            openButton = open.GetComponent<Button>();
            openButton.gameObject.transform.Find("Container/Icon").gameObject.GetComponent<Graphic>().color = Color.white;
            GameObject.Destroy(openButton.gameObject.transform.Find("Container/Icon").gameObject.GetComponent<StyleElement>());
            SetIcon(openButton.gameObject.transform.Find("Container/Icon").gameObject.GetComponent<Image>(), texture);
            openButton.gameObject.name = "Open_" + name;
            openButton.gameObject.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = "Versa UI";
            openButton.GetComponent<RectTransform>().sizeDelta = new Vector2(420, 144);
            openButton.transform.localPosition = new Vector3(0, 320 - (index * 120), transform.transform.localPosition.z);
            openButton.onClick = new Button.ButtonClickedEvent();
            openButton.onClick.AddListener(new System.Action(() =>
            {
                transform.gameObject.SetActive(true);
                wing.openedPages.Add(this);
                if (wing.openedPages.Count > 1)
                {
                    WingPage prev = wing.openedPages[wing.openedPages.Count - 2];
                    prev.transform.gameObject.SetActive(false);
                }
                else wing.WingMenu.gameObject.SetActive(false);
            }));
        }
        public WingPage(WingPage page, string name, string tittle, int index, Texture2D texture)
        {
            wing = page.wing;

            transform = Object.Instantiate(wing.ProfilePage, wing.WingPages);
            Transform content = transform.Find("ScrollRect/Viewport/VerticalLayoutGroup");
            transform.gameObject.SetActive(false);
            transform.gameObject.name = "Page_" + name;

            for (int i = 0; i < content.GetChildCount(); i++)
                Object.Destroy(content.GetChild(i).gameObject);
            transform.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = tittle;

            closeButton = transform.GetComponentInChildren<Button>();
            closeButton.gameObject.name = "Close_" + name;
            closeButton.onClick = new Button.ButtonClickedEvent();
            closeButton.onClick.AddListener(new System.Action(() =>
            {
                transform.gameObject.SetActive(false);
                wing.openedPages.RemoveAt(wing.openedPages.Count - 1);
                if (wing.openedPages.Count > 0)
                {
                    WingPage prev = wing.openedPages[wing.openedPages.Count - 1];
                    prev.transform.gameObject.SetActive(true);
                }
                else wing.WingMenu.gameObject.SetActive(true);
            }));

            Transform open = Object.Instantiate(wing.ProfileButton, page.transform);
            (text = open.GetComponentInChildren<TMPro.TextMeshProUGUI>()).text = name;
            Object.Destroy(text.gameObject.GetComponent<StyleElement>());
            text.m_colorMode = ColorMode.VerticalGradient;
            text.enableVertexGradient = true;
            text.color = Color.white;
            text.colorGradient = new VertexGradient(Color.cyan, Color.white, Color.cyan, Color.cyan);
            openButton = open.GetComponent<Button>();
            openButton.gameObject.transform.Find("Container/Icon").gameObject.GetComponent<Graphic>().color = Color.white;
            GameObject.Destroy(openButton.gameObject.transform.Find("Container/Icon").gameObject.GetComponent<StyleElement>());
            SetIcon(openButton.gameObject.transform.Find("Container/Icon").gameObject.GetComponent<Image>(), texture);
            openButton.gameObject.name = "Open_" + name;
            openButton.gameObject.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = "Versa UI";
            openButton.GetComponent<RectTransform>().sizeDelta = new Vector2(420, 144);
            openButton.transform.localPosition = new Vector3(0, 320 - (index * 120), transform.transform.localPosition.z);
            openButton.onClick = new Button.ButtonClickedEvent();
            openButton.onClick.AddListener(new System.Action(() =>
            {
                transform.gameObject.SetActive(true);
                wing.openedPages.Add(this);
                if (wing.openedPages.Count > 1)
                {
                    WingPage prev = wing.openedPages[wing.openedPages.Count - 2];
                    prev.transform.gameObject.SetActive(false);
                }
                else wing.WingMenu.gameObject.SetActive(false);
            }));
        }
    }
}