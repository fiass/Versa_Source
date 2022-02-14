using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Versa.F_Core
{
    internal class Prefs
    {
        internal static class Int
        {
            internal static async void Save(string key, int value)
            {
                PlayerPrefs.SetInt(key, value);
            }
            internal static int Load(string key)
            {
                if (PlayerPrefs.HasKey(key))
                    return PlayerPrefs.GetInt(key);
                else
                {
                    PlayerPrefs.SetInt(key, 0);
                    return 0;
                }
            }
        }
        internal static class Float
        {
            internal static async void Save(string key, float value)
            {
                PlayerPrefs.SetFloat(key, value);
            }
            internal static float Load(string key)
            {
                if (PlayerPrefs.HasKey(key))
                    return PlayerPrefs.GetFloat(key);
                else
                {
                    PlayerPrefs.SetFloat(key, 0f);
                    return 0f;
                }
            }
        }
        internal static class String
        {
            internal static async void Save(string key, string value)
            {
                PlayerPrefs.SetString(key, value);
            }
            internal static string Load(string key)
            {
                if (PlayerPrefs.HasKey(key))
                    return PlayerPrefs.GetString(key);
                else
                {
                    PlayerPrefs.SetString(key, "");
                    return "";
                }
            }
        }
        internal static class Bool
        {
            internal static async void Save(string key, bool value)
            {
                PlayerPrefs.SetInt(key, Convert.ToInt32(value));
            }
            internal static bool Load(string key)
            {
                if (PlayerPrefs.HasKey(key))
                    return Convert.ToBoolean(PlayerPrefs.GetInt(key));
                else
                {
                    PlayerPrefs.SetInt(key, 1);
                    return true;
                }
            }
        }
    }
}
