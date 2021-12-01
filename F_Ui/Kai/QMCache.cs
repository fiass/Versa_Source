using System.Linq;
using Mono.Cecil;
using UnityEngine;
using VRC.UI.Elements.Menus;

namespace Versa.F_Ui
{
    internal class QMCache
    {
        private static GameObject QMTabCache;
        internal static GameObject QMTab
        {
            get
            {
                if (!QMTabCache)
                    QMTabCache = GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_DevTools");
                return QMTabCache;
            }
        }

        private static GameObject QMMenuCache;
        internal static GameObject QMMenu
        {
            get
            {
                if (!QMMenuCache)
                    QMMenuCache = Resources.FindObjectsOfTypeAll<DevMenu>()[0].gameObject;
                return QMMenuCache;
            }
        }

        private static GameObject LaunchPadQMMenuCache;
        internal static GameObject LaunchPadQmMenu
        {
            get
            {
                if (!LaunchPadQMMenuCache)
                    LaunchPadQMMenuCache = Resources.FindObjectsOfTypeAll<LaunchPadQMMenu>().FirstOrDefault().gameObject;
                return LaunchPadQMMenuCache;
            }
        }

        private static GameObject SelectedUserMenuCache;
        internal static GameObject SelectedUserMenu
        {
            get
            {
                if (!SelectedUserMenuCache)
                    SelectedUserMenuCache = Resources.FindObjectsOfTypeAll<MonoBehaviour1PublicBoRaGaObGaBuObScGaBuUnique>()[0].gameObject;
                return SelectedUserMenuCache;
            }
        }

        private static GameObject QMHeaderCache;
        internal static GameObject QMHeader
        {
            get
            {
                if (!QMHeaderCache)
                    QMHeaderCache = LaunchPadQmMenu.transform.Find("ScrollRect/Viewport/VerticalLayoutGroup/Header_QuickLinks").gameObject;
                return QMHeaderCache;
            }
        }

        private static GameObject QMButtonCache;
        internal static GameObject QMButton
        {
            get
            {
                if (!QMButtonCache)
                    QMButtonCache = LaunchPadQmMenu.transform.Find("ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickActions/Button_GoHome").gameObject;
                return QMButtonCache;
            }
        }

        private static GameObject WingButtonCache;
        internal static GameObject WingButton
        {
            get
            {
                if (!WingButtonCache)
                    WingButtonCache = GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Container/InnerContainer/WingMenu/ScrollRect/Viewport/VerticalLayoutGroup/Button_Profile");
                return WingButtonCache;
            }
        }

        private static GameObject MicIconCache;
        internal static GameObject MicIcon
        {
            get
            {
                if (!MicIconCache)
                    MicIconCache = GameObject.Find("UserInterface/UnscaledUI/HudContent/Hud/VoiceDotParent");
                return MicIconCache;
            }
        }
    }
}
