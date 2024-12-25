using Discord;
using Discord.Commands;
using Discord.WebSocket;

public class Program
{
    private static DiscordSocketClient _discordSocketClient = new DiscordSocketClient();

    public static async Task Main()
    {
        DiscordSocketConfig discordSocketConfig = new DiscordSocketConfig { MessageCacheSize = 100 };
        _discordSocketClient = new DiscordSocketClient(discordSocketConfig);

        _discordSocketClient.Log += Log;

        String token = File.ReadAllText(Directory.GetCurrentDirectory() + "\\token.txt");
        await _discordSocketClient.LoginAsync(TokenType.Bot, token);
        await _discordSocketClient.StartAsync();

        _discordSocketClient.MessageUpdated += MessageUpdated;
        _discordSocketClient.Ready += () =>
        {
            Console.WriteLine("Bot is connected!");
            return Task.CompletedTask;
        };

        // Block this task until the program is closed.
        await Task.Delay(-1);
    }

    private static Task Log(LogMessage logMessage)
    {
        Console.WriteLine(logMessage.ToString());
        return Task.CompletedTask;
    }

    private static async Task MessageUpdated(Cacheable<IMessage, ulong> before, SocketMessage after, ISocketMessageChannel channel)
    {
        var message = await before.GetOrDownloadAsync();
        Console.WriteLine($"{message} -> {after}");
    }
}