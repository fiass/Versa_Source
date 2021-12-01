using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace Server.Discord
{
    public class LicenseCommands
    {
        
    }

    public class ClientCommands : BaseCommandModule
    {
        [Command("Update")]
        [RequireRoles(RoleCheckMode.Any, "Server Host", "Versa", "Server Moderator")]
        public async Task Update(CommandContext ctx)
        {
            ctx.Channel.SendMessageAsync($"Old CheckSum: {Core.ModuleService.LastChecksum}").GetAwaiter().GetResult();
            Core.ModuleService.UpdateFileData();
            await ctx.Channel.SendMessageAsync($"New CheckSum: {Core.ModuleService.LastChecksum}");
        }
    }
}