using Discord;
using Discord.Commands;
using HtmlAgilityPack;
using System.Linq;
using System.Threading.Tasks;

namespace Warcraft_DiscordBot.Modules
{
    public class WarcraftStats : ModuleBase<SocketCommandContext>
    {
        [Command("stats")]
        public async Task CheckStats(string name)
        {
            var msg = await ReplyAsync("Checking stats may take a couple of seconds..");
            var result = await GetStats(name.ToLower());
            EmbedBuilder builder = new EmbedBuilder();

            builder.WithTitle($"Stats for {name}")
                .WithDescription($"\nTotal wins and losses: " +
                 $"\nWins: {result[2]} Losses: {result[1]}" +
                 $"\nWinrate: {result[0]}")
                .WithFooter($"Fatso special just for you!")
                .WithColor(Color.Purple)
                .WithCurrentTimestamp();

            await ReplyAsync("", false, builder.Build());
        }

        private async Task<string[]> GetStats(string name)
        {
            var url = "http://classic.battle.net/war3/ladder/w3xp-player-profile.aspx?Gateway=Northrend&PlayerName=" + name;
            var web = new HtmlWeb();
            var doc = await web.LoadFromWebAsync(url);
            var htmlRankingRankingRowDataAll = doc.DocumentNode.SelectNodes("//td[@class='ladderTableGray']//td");

            var htmlRankingsReversed = htmlRankingRankingRowDataAll.Reverse();
            var result = htmlRankingsReversed.Select(x => x.InnerText).Take(3).ToArray();

            return result;
        }
    }
}
