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
            internal static void Save(string key, int value)
            {
                PlayerPrefs.SetInt(key, value);
            }
            internal static int Load(string key)
            {
                if (PlayerPrefs.HasKey(key))
                    return PlayerPrefs.GetInt(key);
                else
                    return 0;
            }
        }
        internal static class Float
        {
            internal static void Save(string key, float value)
            {
                PlayerPrefs.SetFloat(key, value);
            }
            internal static float Load(string key)
            {
                if (PlayerPrefs.HasKey(key))
                    return PlayerPrefs.GetFloat(key);
                else
                    return 0f;
            }
        }
        internal static class String
        {
            internal static void Save(string key, string value)
            {
                PlayerPrefs.SetString(key, value);
            }
            internal static string Load(string key)
            {
                if (PlayerPrefs.HasKey(key))
                    return PlayerPrefs.GetString(key);
                else
                    return null;
            }
        }
        internal static class Bool
        {
            internal static void Save(string key, bool value)
            {
                PlayerPrefs.SetInt(key, Convert.ToInt32(value));
            }
            internal static bool Load(string key)
            {
                if (PlayerPrefs.HasKey(key))
                    return Convert.ToBoolean(PlayerPrefs.GetInt(key));
                else
                    return true;
            }
        }
    }
}
