using System.Runtime.Serialization;

namespace XDoTool.MouseMoveCommand.GetMouseLocation;

/// <summary>
/// Gets the current mouse location, including the x and y coordinates and the window ID under the mouse pointer.
/// </summary>
/// <returns>
///     The command returns a string in the format:
///     x:<x-coordinate> y:<y-coordinate> screen:<screen-number> window:<window-id>
///     <example>
///     For example: x:100 y:200 screen:0 window:41943042
///     </example>
/// </returns>
public class GetMouseLocationCommand() : CommandWithResult<MouseLocation>("getmouselocation")
{
    public override MouseLocation GetCommandOutputValue()
    {
        if (string.IsNullOrEmpty(commandOutput))
        {
            throw new InvalidDataContractException($"Could not parse commandOutput. Is empty.");
        }

        var values = commandOutput.Split(' ');

        if (values.Length != 4)
        {
            throw new InvalidDataContractException($"Could not parse: {commandOutput}");
        }

        if (!int.TryParse(values[0], out var x))
        {
            throw new InvalidDataContractException($"Could not parse x from output: {commandOutput}");
        }
        
        if (!int.TryParse(values[1], out var y))
        {
            throw new InvalidDataContractException($"Could not parse y from output: {commandOutput}");
        }

        if (!int.TryParse(values[2], out var screen))
        {
            throw new InvalidDataContractException($"Could not parse screen from output: {commandOutput}");
        }

        if (!long.TryParse(values[3], out var windowId))
        {
            throw new InvalidDataContractException($"Could not parse windowId from output: {commandOutput}");
        }

        return new MouseLocation(x,y,screen, windowId);
    }

}

