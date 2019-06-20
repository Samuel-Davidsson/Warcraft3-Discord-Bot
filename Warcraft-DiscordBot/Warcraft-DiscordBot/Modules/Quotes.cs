using Discord;
using Discord.Commands;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
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
            IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, true)
            .Build();

            string path = config["AppSettings:Textfilepath"];
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

        [Command("addquote")]
        public async Task AddQoute([Remainder]string quote)
        {
            IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, true)
            .Build();

            string path = config["AppSettings:Textfilepath"];
            File.AppendAllText(path, quote + Environment.NewLine);
            await ReplyAsync("Added your qoute succesfully!");
        }
    }
}
