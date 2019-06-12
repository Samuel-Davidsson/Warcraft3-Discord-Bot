using Discord.Commands;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Warcraft_DiscordBot.Modules
{
    public class DailyWinAndLossRatio : ModuleBase
    {
        private static Dictionary<ulong, int> DictWins = new Dictionary<ulong, int>();
        private static Dictionary<ulong, int> DictLosses = new Dictionary<ulong, int>();

        [Command("win")]
        public async Task WinCommand()
        {
            var user = Context.User;
            int wins = 0;

            if (DictWins.ContainsKey(user.Id))
            {
                wins = DictWins[user.Id] += 1;
            }
            else
            {
                wins += 1;
                DictWins.Add(user.Id, wins);
            }

            int losses = 0;
            if (DictLosses.Count != 0 && DictLosses.ContainsKey(user.Id))
            {
                losses = DictLosses[user.Id];
            }
            await ReplyAsync($"Status för {user.Username} => Wins {wins} Losses {losses}");
        }

        [Command("loss")]
        public async Task LossCommand()
        {
            var user = Context.User;
            int losses = 0;
            if (DictLosses.ContainsKey(user.Id))
            {
                losses = DictLosses[user.Id] += 1;
            }
            else
            {
                losses += 1;
                DictLosses.Add(user.Id, losses);
            }

            int wins = 0;
            if (DictWins.Count != 0 && DictWins.ContainsKey(user.Id))
            {
                wins = DictWins[user.Id];
            }
            await ReplyAsync($"Status för {user.Username} => Wins {wins} Losses {losses}");
        }

        [Command("status")]
        public async Task StatusCommand()
        {
            var user = Context.User;

            if (!DictWins.ContainsKey(user.Id))
            {
                int wins = 0;
                int losses = 0;
                await ReplyAsync($"Status för {user.Username} => Wins {wins} Losses {losses}");
            }
            else
            {
                var wins = DictWins[user.Id];
                var losses = DictLosses[user.Id];
                await ReplyAsync($"Status för {user.Username} => Wins {wins} Losses {losses}");
            }
        }
    }
}
