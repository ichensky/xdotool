using System.Runtime.Serialization;

namespace XDoTool.WindowCommands;

public class GetWindowPidCommand(long windowId) : CommandWithResult<int>("getwindowpid", [windowId.ToString()])
{
    public override int GetCommandOutputValue()
    {
        if (string.IsNullOrEmpty(commandOutput))
        {
            throw new InvalidDataContractException($"Could not parse commandOutput. Is empty.");
        }

        if (int.TryParse(commandOutput, out var windowPid))
        {
            return windowPid;
        }

        throw new InvalidDataContractException($"Could not parse window PID from output: {commandOutput}");
    }
}
