using System.Linq;
using UnityEngine;

namespace Versa.F_Ui.Kai
{
    internal class UICache
    {
        private static GameObject _FavoriteList;
        internal static GameObject FavoriteList
        {
            get
            {
                if (!_FavoriteList)
                    _FavoriteList = Resources.FindObjectsOfTypeAll<UiAvatarList>().First(x => x.gameObject.name.Contains("Favorite")).gameObject;
                return _FavoriteList;
            }
        }
    }
}