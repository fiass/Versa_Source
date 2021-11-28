using Il2CppSystem.Runtime.Remoting.Messaging;
using UnityEngine;
using UnityEngine.UI;
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
            HeaderText.text = "<color=#00ccff>Versa Favorites</color>";
        }
        
        //TODO:Create button api for lists
        private static void CreateButtons()
        {
        }

        //Fiass do not use add or remove until database is finished
        
        internal static void Add(ApiAvatar avatar)
        {
            if (!Database.Avatars.Exists(x => x.id == avatar.id))
                Database.Avatars.Insert(avatar);
        }

        internal static void Remove(ApiAvatar avatar)
        {
            if (Database.Avatars.Exists(x => x.id == avatar.id))
                Database.Avatars.DeleteMany(x => x.id == avatar.id);
        }
    }
}