using System.Diagnostics;
using System.Threading.Channels;

namespace XDoTool;

public class XDoTool 
{
    private const string XDoToolExecutable = "xdotool";

    public static async Task ExecuteCommands(ChannelReader<ICommand> commands)
    {
        ProcessStartInfo startInfo = new()
        {
            FileName = XDoToolExecutable,
            Arguments = "-",
            RedirectStandardInput = true,
            RedirectStandardOutput = false,
            RedirectStandardError = false,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using Process process = new() { StartInfo = startInfo };

        process.Start();

        using var input = process.StandardInput;
        input.AutoFlush = false;

        while (await commands.WaitToReadAsync())
        {
            while (commands.TryRead(out var command))
            {
                await input.WriteLineAsync(command.GetCommandString());
                await input.FlushAsync();
            }
        }

        input.Close();

        await process.WaitForExitAsync(); 
    }


    public static async Task ExecuteCommand(ICommand command)
    {
        ProcessStartInfo startInfo = new()
        {
            FileName = XDoToolExecutable,
            Arguments = command.GetCommandString(),
            RedirectStandardInput = false,
            RedirectStandardOutput = false,
            RedirectStandardError = false,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using Process process = new() { StartInfo = startInfo };

        process.Start();

        process.WaitForExit();
    }

    public static async Task<TCommandResult> ExecuteCommand<TCommandResult>(ICommandWithResult<TCommandResult> command)
    {
        ProcessStartInfo startInfo = new()
        {
            FileName = XDoToolExecutable,
            Arguments = command.GetCommandString(),
            RedirectStandardInput = false,
            RedirectStandardOutput = true,
            RedirectStandardError = false,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using Process process = new() { StartInfo = startInfo };

        process.Start();

        string output = await process.StandardOutput.ReadToEndAsync();

        command.SetCommandOutput(output);

        process.WaitForExit();

        return command.GetCommandOutputValue();
    }
}
