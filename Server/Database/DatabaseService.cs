using System.Threading.Tasks;
using LiteDB;

namespace Server.Database
{
    public class DatabaseService
    {
        public static ILiteDatabase DB { get; set; }
        public static ILiteCollection<Structs.Server.LicenseData> Licenses { get; set; }
        public static async Task StartService()
        {
            DB = new LiteDatabase("Database.Versa");
            Licenses = DB.GetCollection<Structs.Server.LicenseData>("License");
            await Task.Delay(-1);
        }
    }
}