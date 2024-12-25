using Discord;
using Discord.Commands;
using Discord.WebSocket;

public partial class LoggingService
{
    public LoggingService(DiscordSocketClient discordSocketClient, CommandService commandService)
    {
        discordSocketClient.Log += LogAsync;
        commandService.Log += LogAsync;
    }

    private Task LogAsync(LogMessage logMessage)
    {
        if (logMessage.Exception is CommandException commandException)
        {
            Console.WriteLine($"[Command/{logMessage.Severity}] {commandException.Command.Aliases.First()}"
            + $" failed to execute in {commandException.Context.Channel}.");
            Console.WriteLine(commandException);
        }
        else
        {
            Console.WriteLine($"[General/{logMessage.Severity}] {logMessage}");
        }

        return Task.CompletedTask;
    }
}