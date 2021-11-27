using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Versa.F_Config;
using Versa.F_Core;
using Versa.F_Ui.Kai;
using VRC.Core;

namespace Versa.F_Ui
{
    internal class AvatarList
    {
        private static Text HeaderText { get; set; }
        private static GameObject ListObject { get; set; }
        private static UiAvatarList AviListBase { get; set; }
        internal static void Create()
        {
            ListObject = GameObject.Instantiate(UICache.FavoriteList, UICache.FavoriteList.transform.parent);
            ListObject.name = $"Favorite Versa List";
            ListObject.transform.SetSiblingIndex(UICache.FavoriteList.transform.GetSiblingIndex() + -1);
            AviListBase = ListObject.GetComponent<UiAvatarList>();
            AviListBase.field_Public_Category_0 = UiAvatarList.Category.SpecificList;
            AviListBase.hideWhenEmpty = false;
            AviListBase.clearUnseenListOnCollapse = true;
            HeaderText = ListObject.transform.Find("Button").gameObject.GetComponentInChildren<Text>();
            HeaderText.supportRichText = true;
            HeaderText.text = "Versa Favorites";
            SetupButtons();
        }

        //TODO:Write list button api
        private static void SetupButtons()
        {
            
        }

        internal static void Add(ApiAvatar avatar)
        {
            if (Database.Avatars.Exists(x => x.AvatarID == avatar.id) == false)
                Database.Avatars.Insert(DBAvatar.Parse(avatar));
        }
        internal static void Remove(ApiAvatar avatar)
        {
            if (Database.Avatars.Exists(x => x.AvatarID == avatar.id) == true)
                Database.Avatars.DeleteMany(x => x.AvatarID == avatar.id);
        }
    }
}