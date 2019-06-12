using Discord.Commands;
using Discord.WebSocket;
using System.Text;
using System.Threading.Tasks;

namespace Warcraft_DiscordBot.Modules
{
    public class BotChatInteractions : ModuleBase
    {
        [Command("bot")]
        public async Task Ready(SocketGuildUser mention)
        {
            var user = mention.Id;

            await ReplyAsync("Ready to rumble!");
        }

        [Command("hello")]
        public async Task HelloCommand()
        {
            var sb = new StringBuilder();

            var user = Context.User;

            sb.AppendLine($"You are -> [{user.Username}]");
            sb.AppendLine("I must now say, I love you but I really want to kill you!");

            await ReplyAsync(sb.ToString());
        }
    }
}
