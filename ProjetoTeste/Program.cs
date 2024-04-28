using DSharpPlus;
using DSharpPlus.SlashCommands;
using ProjetoTeste.SlashCommands;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        MainAsync().GetAwaiter().GetResult();
    }

    static async Task MainAsync()
    {
        //Necessario TOKEN DO Discord
        var discord = new DiscordClient(new DiscordConfiguration()
        {
            Token = "SEU_TOKEN_DISCORD",
            TokenType = TokenType.Bot,
            Intents = DiscordIntents.AllUnprivileged | DiscordIntents.MessageContents | DiscordIntents.Guilds
        });

        var slash = discord.UseSlashCommands();


        ulong IdServidor = 0000000000000000000;// Substitua SEU_ID_DE_SERVIDOR pelo ID do seu servidor de teste

        slash.RegisterCommands<FilmeCommands>(IdServidor); 
        slash.RegisterCommands<SerieCommands>(IdServidor); 

        await discord.ConnectAsync();
        await Task.Delay(-1);
    }
}
