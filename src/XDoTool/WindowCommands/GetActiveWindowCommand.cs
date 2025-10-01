using System.Runtime.Serialization;

namespace XDoTool.WindowCommands;

public class GetActiveWindowCommand(string commandName) : CommandWithResult<long>(commandName)
{
    public GetActiveWindowCommand(): this("getactivewindow") { }

    public override long GetCommandOutputValue()
    {
        if (string.IsNullOrEmpty(commandOutput))
        {
            throw new InvalidDataContractException($"Could not parse commandOutput. Is empty.");
        }

        if (long.TryParse(commandOutput, out var windowId))
        {
            return windowId;
        }

        throw new InvalidDataContractException($"Could not parse window ID from output: {commandOutput}");
    }
}