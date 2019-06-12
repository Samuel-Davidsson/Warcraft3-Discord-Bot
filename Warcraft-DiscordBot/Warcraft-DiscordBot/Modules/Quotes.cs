using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Warcraft_DiscordBot.Modules
{
    public class Quotes : ModuleBase
    {
        [Command("quote")]
        public async Task Quote()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\Quotes.txt");
            string[] files = File.ReadAllLines(path, Encoding.Default);
            EmbedBuilder builder = new EmbedBuilder();
            Random random = new Random();
            int result = random.Next(files.Length);
            builder.WithTitle($"A random Qoute")
                .WithDescription($"Qoute: {files[result]}")
                .WithColor(Color.DarkBlue)
                .WithFooter("Peace and love");

            await ReplyAsync("", false, builder.Build());
        }
    }
}
