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
        internal static GameObject Canvas_QuickMenu_Clone = UiApi.UiManager_GameObject().transform.Find("/UserInterface/Canvas_QuickMenu(Clone)").gameObject;
        internal static GameObject Text_Title = UiApi.UiManager_GameObject().transform.Find("/UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/Header_H1/LeftItemContainer/Text_Title").gameObject;
        internal static GameObject SingleButtonCache = UiApi.UiManager_GameObject().transform.Find("/UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickActions/Button_SelectUser").gameObject;
        internal static GameObject TextUnderCursor = UiApi.UiManager_GameObject().transform.Find("/UserInterface/UnscaledUI/HudContent/Hud/AlertTextParent/Capsule/Text").gameObject;
        internal static GameObject ActivateTextUnderCursor = UiApi.UiManager_GameObject().transform.Find("/UserInterface/UnscaledUI/HudContent/Hud/AlertTextParent/Capsule").gameObject;
        internal static GameObject PlayerIcon = UiApi.UiManager_GameObject().transform.Find("/UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_SelectedUser_Local/ScrollRect/Viewport/VerticalLayoutGroup/UserProfile_Compact/PanelBG/Cell_QM_User/Image_Mask/Image").gameObject;
        internal static GameObject Image_Mask = UiApi.UiManager_GameObject().transform.Find("/UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_SelectedUser_Local/ScrollRect/Viewport/VerticalLayoutGroup/UserProfile_Compact/PanelBG/Cell_QM_User/Image_Mask").gameObject;
        internal static GameObject LeftWing = UiApi.UiManager_GameObject().transform.Find("/UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Container/InnerContainer").gameObject;
        internal static GameObject RightWing = UiApi.UiManager_GameObject().transform.Find("/UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Wing_Right/Container/InnerContainer").gameObject;
        internal static GameObject Social = UiApi.UiManager_GameObject().transform.Find("/UserInterface/MenuContent/Screens/Social/").gameObject;
        #region backgrounds
        internal static GameObject BackgroundLayer01 = UiApi.UiManager_GameObject().transform.Find("/UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/BackgroundLayer01").gameObject;
        internal static GameObject BackgroundLayer02 = UiApi.UiManager_GameObject().transform.Find("/UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/BackgroundLayer02").gameObject;
        internal static GameObject BackgroundRight = UiApi.UiManager_GameObject().transform.Find("/UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Wing_Right/Container/InnerContainer/Background").gameObject;
        internal static GameObject BackgroundLeft = UiApi.UiManager_GameObject().transform.Find("/UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Container/InnerContainer/Background").gameObject;
        internal static GameObject Background= UiApi.UiManager_GameObject().transform.Find("/UserInterface/MenuContent/Backdrop/Backdrop/Background").gameObject;
        internal static GameObject Page0 = UiApi.UiManager_GameObject().transform.Find("/UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Dashboard/Background").gameObject;
        internal static GameObject Page1 = UiApi.UiManager_GameObject().transform.Find("/UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Notifications/Background").gameObject;
        internal static GameObject Page2 = UiApi.UiManager_GameObject().transform.Find("/UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Here/Background").gameObject;
        internal static GameObject Page3 = UiApi.UiManager_GameObject().transform.Find("/UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Camera/Background").gameObject;
        internal static GameObject Page4 = UiApi.UiManager_GameObject().transform.Find("/UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_AudioSettings/Background").gameObject;
        internal static GameObject Page5 = UiApi.UiManager_GameObject().transform.Find("/UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Settings/Background").gameObject;
        internal static GameObject Page6 = UiApi.UiManager_GameObject().transform.Find("/UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_DevTools/Background").gameObject;
        #endregion
    }
}
