using Discord.Commands;

namespace Warcraft_DiscordBot
{
    public class Commands : ModuleBase
    {
        //[Command("kick")]
        //public async Task Kick(SocketGuildUser mention)
        //{
        //    if (mention != null)
        //    {
        //        var channel = await mention.GetOrCreateDMChannelAsync();
        //        await channel.SendMessageAsync($"You´ve been kicked as {Context.Guild.Name} for unknown reason.");
        //        await Task.Delay(2000);

        //        await mention.KickAsync();

        //        await ReplyAsync($"Kicked user {mention.Username} for unknown reason!");
        //    }
        //}
    }
}
