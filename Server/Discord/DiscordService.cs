using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using Server.Core;

namespace Server.Discord
{
    public class DiscordService
    {
        private const string Token = "OTE1MzI5MDU0MTI5OTQyNTY4.YaaAnA.fLKGQvUjds148w4RdreO5BMyQII";
        internal static DiscordGuild VersaServer { get; set; }
        internal static DiscordRole PaidRole { get; set; }
        internal static DiscordClient Client { get; set; }
        internal static List<ulong> PaidMembers { get; set; }
        public static async Task StartService()
        {
            Client = new DiscordClient(new DiscordConfiguration()
            {
                Token = Token,
            });
            var Commands = Client.UseCommandsNext(new CommandsNextConfiguration()
            {
                StringPrefixes = new string[]{"V!"},
                EnableDefaultHelp = false,
            });
            Commands.RegisterCommands(Assembly.GetExecutingAssembly());
            Client.Ready += ClientOnReady;
            Client.GuildMemberUpdated += ClientOnGuildMemberUpdated;
            await Client.ConnectAsync(new DiscordActivity()
            {
                ActivityType = ActivityType.Watching, Name = "over Versa users"
            }, UserStatus.DoNotDisturb);
            await Task.Delay(-1);
        }

        private static async Task ClientOnGuildMemberUpdated(DiscordClient sender, GuildMemberUpdateEventArgs e)
        {
            if (e.RolesAfter.Contains(PaidRole))
            {
                if (!PaidMembers.Contains(e.Member.Id))
                {
                    Logger.Log("Discord (Role)", $"{e.Member.Username}#{e.Member.Discriminator} received Paid Role");
                    PaidMembers.Add(e.Member.Id);
                }
            }
        }

        private static async Task ClientOnReady(DiscordClient sender, ReadyEventArgs e)
        {
            VersaServer = await sender.GetGuildAsync(907095114164346910);
            PaidRole = VersaServer.GetRole(915026734619967489);
            DiscordMember[] Members = VersaServer.GetAllMembersAsync().Result.ToArray();
            Members = Members.Where(x => x.Roles.Contains(PaidRole)).ToArray();
            for (int i = 0; i < Members.Length; i++)
            {
                PaidMembers.Add(Members[i].Id);
            }
        }
    }
}