using System.Runtime.Serialization;

namespace XDoTool.WindowCommands;

public class GetWindowNameCommand(long windowId) : CommandWithResult<string>("getwindowname", [windowId.ToString()])
{
    public override string GetCommandOutputValue()
    {
        if (commandOutput is null)
        {
            throw new InvalidDataContractException($"Could not parse commandOutput. Is null.");
        }

        return commandOutput;
    }
}
