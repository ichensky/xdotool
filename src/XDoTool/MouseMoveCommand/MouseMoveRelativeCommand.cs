namespace XDoTool.MouseMoveCommand;

/// <summary>
/// Moves the mouse relative to its current position by the specified (x, y) offsets.
/// For example, to move the mouse 10 pixels to the right and 5 pixels down, you would use the command:
/// xdotool mousemove_relative 10 5
/// </summary>
public class MouseMoveRelativeCommand(int x, int y)  : MouseMoveCommand("mousemove_relative", x, y)
{
}
