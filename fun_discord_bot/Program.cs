using Discord;
using Discord.WebSocket;

public class Program
{
    private static DiscordSocketClient _client = new DiscordSocketClient();

    public static async Task Main()
    {
        _client = new DiscordSocketClient();

        _client.Log += Log;

        String token = File.ReadAllText(Directory.GetCurrentDirectory() + "\\token.txt");
        Console.WriteLine(token);

        await _client.LoginAsync(TokenType.Bot, token);
        await _client.StartAsync();

        // Block this task until the program is closed.
        await Task.Delay(-1);
    }

    private static Task Log(LogMessage msg)
    {
        Console.WriteLine(msg.ToString());
        return Task.CompletedTask;
    }
}