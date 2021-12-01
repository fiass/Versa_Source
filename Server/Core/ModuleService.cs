using System;
using System.IO;
using System.Security.Cryptography;

namespace Server.Core
{
    public class ModuleService
    {
        public static byte[] CachedFileData { get; set; } = null;
        public static string LastChecksum { get; set; } = "NULL";

        public static void UpdateFileData()
        {
            string NewChecksum = SHA256CheckSum("Versa.dll");
            if (LastChecksum != NewChecksum)
            {
                CachedFileData = File.ReadAllBytes("Versa.dll");
                LastChecksum = NewChecksum;
            }
        }
        
        public static string SHA256CheckSum(string filePath)
        {
            using (SHA256 SHA256 = SHA256Managed.Create())
            {
                FileStream fileStream = File.OpenRead(filePath);
                string CheckSum = Convert.ToBase64String(SHA256.ComputeHash(fileStream));
                fileStream.Dispose();
                SHA256.Dispose();
                return CheckSum;
            }
        }
    }
}