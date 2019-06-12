using Discord;
using Discord.Commands;
using System.Threading.Tasks;

namespace Warcraft_DiscordBot.Modules
{
    public class Ping : ModuleBase<SocketCommandContext>
    {
        [Command("ping")]
        public async Task PingCommand()
        {
            await PingAsync();
        }

        private async Task PingAsync()
        {
            var msg = await ReplyAsync("Checking ping..");
            var latency = Context.Client.Latency;
            Color color;
            if (latency <= 100)
            {
                color = Color.Green;
            }
            else
            {
                color = Color.Red;
            }
            var builder = new EmbedBuilder()
            .WithTitle("Ping!")
            .WithDescription($"The latency is {latency}ms.")
            .WithColor(color)
            .WithCurrentTimestamp();

            await ReplyAsync("", embed: builder.Build());
        }
    }
}
