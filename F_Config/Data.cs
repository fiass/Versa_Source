using Versa.F_Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using CharCrypt;

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
            internal static bool Flashlight;
            internal static bool SpamObject;
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
                    case 15: return Flashlight;
                    case 16: return SpamObject;
                }
                return false; 
            }
        }
        internal static string FirstUsageVersa
        {
            get
            {
                return Prefs.String.Load("FirstUsageVersa_0");
            }
            set
            {
                Prefs.String.Save("FirstUsageVersa_0", value);
            }
        }

        internal static string MenuColor
        {
            get
            {
                var temp = Prefs.String.Load("VersaColor");
                if (temp != null)
                    return temp;
                return "red";
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
        internal static string CapsuleColor
        {
            get
            {
                return  Prefs.String.Load("CapsuleColor");
            }
            set
            {
                Prefs.String.Save("CapsuleColor", value);
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
                return Prefs.Bool.Load("Debug");
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
                var temp = Prefs.Float.Load("FoV");
                if (temp != 0f)
                    return temp; 
                return 60f;
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
        internal static string _ServerPath = $"https://raw.githubusercontent.com/{new string(Versa_Crypt.Char_2)}";
        internal static string Multiplication = new string(Versa_Crypt.Char_3);
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
