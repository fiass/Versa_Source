using Versa.F_Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Versa.F_Ui
{
    internal class UiPath
    {
        internal static GameObject VRC_Banner = UiApi.UiManager_GameObject().transform.Find("/UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/VRC+_Banners").gameObject;
        internal static GameObject Carousel_Banners = UiApi.UiManager_GameObject().transform.Find("/UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Carousel_Banners").gameObject;
        internal static GameObject Canvas_QuickMenu_Clone = UiApi.UiManager_GameObject().transform.Find("/UserInterface/Canvas_QuickMenu(Clone)/").gameObject;
        internal static GameObject Text_Title = UiApi.UiManager_GameObject().transform.Find("/UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/Header_H1/LeftItemContainer/Text_Title").gameObject;
        internal static GameObject SingleButtonCache = UiApi.UiManager_GameObject().transform.Find("/UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickActions/Button_SelectUser/").gameObject;
        internal static GameObject TextUnderCursor = UiApi.UiManager_GameObject().transform.Find("/UserInterface/UnscaledUI/HudContent/Hud/AlertTextParent/Capsule/Text").gameObject;
        internal static GameObject ActivateTextUnderCursor = UiApi.UiManager_GameObject().transform.Find("/UserInterface/UnscaledUI/HudContent/Hud/AlertTextParent/Capsule").gameObject;
        internal static GameObject PlayerIcon = UiApi.UiManager_GameObject().transform.Find("/UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_SelectedUser_Local/ScrollRect/Viewport/VerticalLayoutGroup/UserProfile_Compact/PanelBG/Cell_QM_User/Image_Mask/Image").gameObject;
        internal static GameObject LeftWing = UiApi.UiManager_GameObject().transform.Find("/UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Container/InnerContainer/").gameObject;
        internal static GameObject RightWing = UiApi.UiManager_GameObject().transform.Find("/UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Wing_Right/Container/InnerContainer/").gameObject;
    }
}
