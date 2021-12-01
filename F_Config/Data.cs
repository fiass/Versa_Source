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
            internal static bool BlockPortals;
            internal static bool AntiCrash = true;
            internal static bool ToggleMove;
        internal static bool ToggleIndex(int value)
            {
                switch(value)
                {
                    case 1: return MoonGravity;
                    case 2: return Optimization;
                    case 3: return Ownership;
                    case 4: return Undress;
                    case 5: return NoClip;
                    case 6: return SpeedHack;
                    case 7: return PostProcess;
                    case 8: return BlockPortals;
                    case 9: return WorldLog;
                    case 10: return ToggleJump;
                    case 11: return PoVPreview;
                    case 12: return ToggleMove;
                    case 13: return ToggleChair;
                    case 14: return AntiCrash;
                    case 15: return false;
                }
                return false; 
            }
        }
        internal static string MenuColor
        {
            get
            {
                return Prefs.String.Load("VersaColor");
            }
            set
            {
                Prefs.String.Save("VersaColor", value);
            }
        }
        internal static bool AntiCrash
        {
            get
            {
                return Prefs.Bool.Load("AntiCrash");
            }
            set
            {
                Prefs.Bool.Save("AntiCrash", value);
            }
        }
        internal static bool ToggleChair
        {
            get
            {
                return Prefs.Bool.Load("ToggleChair");
            }
            set
            {
                Prefs.Bool.Save("ToggleChair", value);
            }
        }
        internal static bool ToggleJump
        {
            get
            {
                return Prefs.Bool.Load("ToggleJump");
            }
            set
            {
                Prefs.Bool.Save("ToggleJump", value);
            }
        }
        internal static bool PoVPreview
        {
            get
            {
                return Prefs.Bool.Load("PoVPreview");
            }
            set
            {
                Prefs.Bool.Save("PoVPreview", value);
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
        
        internal static bool WorldLog
        {
            get
            {
                return Prefs.Bool.Load("WorldLog");
            }
            set
            {
                Prefs.Bool.Save("WorldLog", value);
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
        internal static Texture2D[] Textures = new Texture2D[99];
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
