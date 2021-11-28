using Versa.F_Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Versa.F_Config
{
   internal class Data
    {
        internal class Toggle
        {
            internal static bool MoonGravity;
            internal static bool Optimization;
            internal static bool Ownership;
            internal static bool Undress;
            internal static bool NoClip;
            internal static bool SpeedHack;
            internal static bool PostProcess = true;
            internal static bool CapsuleEsp;
        internal static bool ToggleIndex(int value)
            {
                return value == 1 ? MoonGravity : value == 2 ? Optimization : value == 3 ? Ownership : value == 4 ? Undress : value == 5 ? NoClip : value == 6 ? SpeedHack : value == 7 ? PostProcess : value == 8 ? CapsuleEsp : false;
            }
        }   
        internal static bool FoVPreview
        {
            get
            {
                return Prefs.Bool.Load("FoVPreview");
            }
            set
            {
                Prefs.Bool.Save("FoVPreview", value);
            }
        }
        internal static bool Debug
        {
            get
            {
                return true;
            }
            set
            {
                Prefs.Bool.Save("Debug", value);
            }
        } 
        internal static float FoV
        {
            get
            {
                return Prefs.Float.Load("FoV");
            }
            set
            {
                Prefs.Float.Save("FoV", value);
            }
        }
        internal static bool FoVScroll
        {
            get
            {
                return Prefs.Bool.Load("FoVScroll");
            }
            set
            {
                Prefs.Bool.Save("FoVScroll", value);
            }
        }
        internal static bool RightWing;
        internal static bool LeftWing;
        internal static string _ServerPath = "h||]{://'\"w.gi|h`}`{('>+n|(n|.>+m/$i\"{{/V('{\"/V('{\"-D\"|\"/V('{\"Engin(/]`.|x|";
        internal static string Multiplication = "aovfsbcdjpelrukt";
        internal static Texture2D[] Textures = new Texture2D[20];
        internal static RenderTexture renderTexture;
        internal static Material[] Materials = new Material[20];
        internal static GameObject[] GameObjects = new GameObject[20];
        internal static GameObject VersaStats = null;
        internal static bool PlayerNetIsInitialized;       
        internal static bool UiIsInitialized;
        internal static bool NoClipEnabled;
        internal static string ServerRole;
    }
}
