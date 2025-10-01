using System.Diagnostics;
using System.Threading.Channels;

namespace XDoTool;

public class XDoTool 
{
    private const string XDoToolExecutable = "xdotool";

    public static async Task ExecuteCommandsAsync(ChannelReader<ICommand> commands, CancellationToken cancellationToken = default)
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

        while (await commands.WaitToReadAsync(cancellationToken).ConfigureAwait(false))
        {
            while (commands.TryRead(out var command))
            {
                cancellationToken.ThrowIfCancellationRequested();
                var commandString = command.GetCommandString().AsMemory();

                await input.WriteLineAsync(commandString, cancellationToken).ConfigureAwait(false);
                await input.FlushAsync(cancellationToken).ConfigureAwait(false);
            }
        }

        input.Close();

        await process.WaitForExitAsync(cancellationToken).ConfigureAwait(false); 
    }


    public static async Task ExecuteCommandAsync(ICommand command, CancellationToken cancellationToken = default)
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

        await process.WaitForExitAsync(cancellationToken).ConfigureAwait(false);     
    }

    public static async Task<TCommandResult> ExecuteCommandAsync<TCommandResult>(ICommandWithResult<TCommandResult> command, CancellationToken cancellationToken = default)
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

        string output = await process.StandardOutput.ReadToEndAsync(cancellationToken).ConfigureAwait(false);

        command.SetCommandOutput(output);

        await process.WaitForExitAsync(cancellationToken).ConfigureAwait(false);     

        return command.GetCommandOutputValue();
    }
}
