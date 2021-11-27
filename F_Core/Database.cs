using Newtonsoft.Json;
using VRC.Core;

namespace Versa.F_Core
{
    internal class Database
    {
        internal static LiteDB.ILiteDatabase DBCore { get; set; }
        internal static LiteDB.ILiteCollection<DBAvatar> Avatars { get; set; }
        internal static void SetupDatabase()
        {
            DBCore = new LiteDB.LiteDatabase("Versa\\Database.Versa");
            Avatars = DBCore.GetCollection<DBAvatar>("Avatars");
        }
    }

    internal class DBAvatar
    {
        internal static DBAvatar Parse(ApiAvatar avatar)
        {
            return new DBAvatar()
            {
                ReleaseStatus = avatar.releaseStatus,
                AvatarName = avatar.name,
                AvatarID = avatar.id,
                AuthorName = avatar.authorName,
                AuthorID = avatar.authorId,
                AssetURL = avatar.assetUrl,
                ImageURL = avatar.imageUrl
            };
        }
        [JsonIgnore]
        public int id { get; set; }
        public string ReleaseStatus { get; set; }
        public string AvatarName { get; set; }
        public string AvatarID { get; set; }
        public string AuthorName { get; set; }
        public string AuthorID { get; set; }
        public string AssetURL { get; set; }
        public string ImageURL { get; set; }
    }
}