using UnityEngine;
using UnityEngine.UI;
using Versa.F_Ui.Kai;
using VRC.Core;

namespace Versa.F_Ui
{
    internal class AvatarList
    {
        protected Text HeaderText { get; set; }
        protected GameObject ListObject { get; set; }
        protected UiAvatarList AviListBase { get; set; }
        internal AvatarList(string text, int index = 0)
        {
            ListObject = GameObject.Instantiate(UICache.FavoriteList, UICache.FavoriteList.transform.parent);
            ListObject.name = $"Favorite Versa List ({text})";
            ListObject.transform.SetSiblingIndex(UICache.FavoriteList.transform.GetSiblingIndex() + index);
            AviListBase = ListObject.GetComponent<UiAvatarList>();
            AviListBase.field_Public_Category_0 = UiAvatarList.Category.SpecificList;
            AviListBase.hideWhenEmpty = false;
            AviListBase.clearUnseenListOnCollapse = true;
            HeaderText = ListObject.transform.Find("Button").gameObject.GetComponentInChildren<Text>();
            HeaderText.supportRichText = true;
            SetText(text);
        }

        internal void SetText(string Text) => HeaderText.text = Text;

        internal void Add(ApiAvatar avatar)
        {
            
        }

        internal void Remove(ApiAvatar avatar)
        {
            
        }
    }
}