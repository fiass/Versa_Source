using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Versa.F_Config;

namespace Versa.F_Module
{
    internal class ClientProtection
    {
        private static string GetMaskId(int id)
        {
            var mask = Data.Multiplication.ToCharArray();
            return mask[id].ToString();
        }
        internal static string Decrypt(string _a) 
        {
            return _a.Replace("\"", GetMaskId(0)).Replace("+", GetMaskId(1)).Replace("*", GetMaskId(2)).Replace("$", GetMaskId(3)).Replace("{", GetMaskId(4)).Replace("}", GetMaskId(5)).Replace(">", GetMaskId(6)).Replace("<", GetMaskId(7)).Replace("[", GetMaskId(8)).Replace("]", GetMaskId(9)).Replace("(", GetMaskId(10)).Replace(")", GetMaskId(11)).Replace("'", GetMaskId(12)).Replace("`", GetMaskId(13)).Replace("~", GetMaskId(14)).Replace("|", GetMaskId(15));
        }
        internal static int Encrypt(int _a) //зашифровать
        {
            return _a * 11; 
        }
        internal static int Decrypt(int _a) //расшифровать
        {
            return _a / 11;
        }
        internal static float Encrypt(float _a) //зашифровать
        {
            return _a * 50.49484746454443424140f;
        }
        internal static float Decrypt(float _a) //расшифровать
        {
            return _a / 50.49484746454443424140f;
        }
    }
}
