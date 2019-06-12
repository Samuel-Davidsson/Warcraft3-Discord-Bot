using Discord;
using Discord.Commands;
using System.Threading.Tasks;

namespace Warcraft_DiscordBot.Modules
{
    public class Help : ModuleBase
    {
        [Command("help")]
        public async Task HelpCommand()
        {
            EmbedBuilder builder = new EmbedBuilder();

            builder.WithTitle($"All Commands")
                .WithDescription("")
                .AddField("!ping", "Ping the bot and get a responds with the latency.")
                .AddField("!stats <bnet account>", "Check total stats for bnet account")
                .AddField("!win", "Add win to your current score.")
                .AddField("!loss", "Add loss to your current score.")
                .AddField("!status", "Current score win & loss.")
                .AddField("!bot <@botname>", "Get a response from the bot.")
                .AddField("!weather <cityname>", "Get current weather from the city you typed in.")
                .AddField("!forecast <cityname>", "Get the weather report for the next day.")
                .WithFooter("Ask Fatso.. :)")
                .WithColor(Color.Green);

            await ReplyAsync("", false, builder.Build());
        }
    }
}
