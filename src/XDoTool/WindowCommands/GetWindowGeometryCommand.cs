using System.Runtime.Serialization;

namespace XDoTool.WindowCommands;

public record WindowGeometry(int X, int Y, int Width, int Height, int Screen);

public class GetWindowGeometryCommand(long windowId) : CommandWithResult<WindowGeometry>("getwindowgeometry", [windowId.ToString()])
{
    public override WindowGeometry GetCommandOutputValue()
    {
        if (string.IsNullOrEmpty(commandOutput))
        {
            throw new InvalidDataContractException($"Could not parse commandOutput. Is empty.");
        }

        var lines = commandOutput.Split(Environment.NewLine);

        if (lines.Length != 4)
        {
            throw new InvalidDataContractException($"Could not parse commandOutput : {commandOutput}");
        }

        try
        {
            var positionStr = lines[1].Split(':');
            var geometryStr = lines[2].Split(':')[1].Split('x');

            var xyStr = positionStr[1].Split('(')[0].Split(',');
            var x = int.Parse(xyStr[0]);
            var y = int.Parse(xyStr[1]);
            var screenStr = positionStr[2].Split(')');
            var screen = int.Parse(screenStr[0]);

            var width = int.Parse(geometryStr[0]);
            var height = int.Parse(geometryStr[1]);

            return new WindowGeometry(x, y, width, height, screen);

        }
        catch (Exception ex)
        {
            throw new InvalidDataContractException($"Could not parse {commandOutput}. " + ex.Message);
        }
    }
}
