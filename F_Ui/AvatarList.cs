using System;
using System.IO;
using Il2CppSystem.Collections.Generic;
using Il2CppSystem.Runtime.Remoting.Messaging;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;
using Versa.F_Core;
using Versa.F_Output;
using Versa.F_Ui.Kai;
using VRC.Core;

namespace Versa.F_Ui
{
    internal class AvatarList
    {
        private  static Il2CppSystem.Collections.Generic.List<JsonAvatar> Avatars { get; set; }
        private static Text HeaderText { get; set; }
        private static GameObject ListObject { get; set; }
        private static UiAvatarList AviListBase { get; set; }
        internal static void Create()
        {
            Load();
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

        //Fiass put this on avatar menu open
        internal static void Render()
        {
            AviListBase.Method_Protected_Void_List_1_T_Int32_Boolean_VRCUiContentButton_0(Avatars, 0, true, null);
        }
        
        //TODO:Create button api for lists
        private static void CreateButtons()
        {
        }

        //Fiass do not use add or remove until database is finished
        
        internal static void Add(ApiAvatar avatar)
        {
            Avatars.Add(JsonAvatar.ParseAvatar(avatar));
            Save();
        }

        internal static void Remove(ApiAvatar avatar)
        {
            Avatars.Add(JsonAvatar.ParseAvatar(avatar));
            Save();
        }

        internal static void Save()
        {
            try
            {
                File.WriteAllText("Versa\\Favorites.Versa", JsonConvert.SerializeObject(Avatars));
            }
            catch (Exception e)
            {
                CustomConsole.Console(false, "Failed to save favorites");
            }
        }

        internal static void Load()
        {
            try
            {
                if(File.Exists("Versa\\Favorites.Versa")) Avatars = JsonAvatar.ParseList(File.ReadAllText("Versa\\Favorites.Versa"));
                else
                {
                    Avatars = new Il2CppSystem.Collections.Generic.List<JsonAvatar>();
                    Avatars.Add(new JsonAvatar()
                    {
                        //Put default robot here
                    });
                    File.WriteAllText("Versa\\Favorites.Versa", JsonConvert.SerializeObject(Avatars));
                }
            }
            catch (Exception e)
            {
                CustomConsole.Console(true, "Failed to parse favorites");
            }
        }
    }
    
    internal class JsonAvatar
    {
        public string id { get; set; }
        public string name { get; set; }
        public string releaseStatus { get; set; }
        public string assetURL { get; set; }
        public string ImageURL { get; set; }

        internal static Il2CppSystem.Collections.Generic.List<JsonAvatar> ParseList(string Data)
        {
            return JsonConvert.DeserializeObject<Il2CppSystem.Collections.Generic.List<JsonAvatar>>(Data);
        }

        internal static JsonAvatar ParseAvatar(ApiAvatar avatar)
        {
            return new JsonAvatar()
            {
                id = avatar.id,
                name = avatar.name,
                releaseStatus = avatar.releaseStatus,
                assetURL = avatar.assetUrl,
                ImageURL = avatar.imageUrl
            };
        }
    }
}