using LiteDB;
using VRC.Core;

namespace Versa.F_Core
{
    internal class Database
    {
        internal static ILiteDatabase LiteDatabase { get; set; }
        internal static ILiteCollection<ApiAvatar> Avatars { get; set; }
        internal static void Setup()
        {
            LiteDatabase = new LiteDatabase("Versa\\Database.Versa");
            Avatars = LiteDatabase.GetCollection<ApiAvatar>("Avatars");
        }
    }
}