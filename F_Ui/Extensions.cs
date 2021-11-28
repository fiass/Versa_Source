using System;
using System.Collections.Generic;
using UnityEngine;

namespace Versa.F_Ui
{
    public static class Extensions
    {
        public static WingPage CreatePage(this Wing.BaseWing page, string name) => new WingPage(page, name);
        public static WingPage CreateNestedPage(this WingPage page, string name, int index) => new WingPage(page, name, index);
        public static WingButton CreateButton(this WingPage page, string name, int index, Texture2D texture, bool state) => new WingButton(page, name, index, texture, state);
        public static WingButton CreateButton(this WingPage page, string name, int index, Texture2D texture) => new WingButton(page, name, index, texture);
    }
}
