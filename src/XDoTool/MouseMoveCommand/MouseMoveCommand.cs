using XDoTool.CommandFlags;

namespace XDoTool.MouseMoveCommand;

/// <summary>
/// Moves the mouse to the specified (x, y) coordinates on the screen.
/// The origin (0, 0) is at the top-left corner of the screen.
/// </summary>
public class MouseMoveCommand : Command
{
    internal MouseMoveCommand(string commandName, int x, int y) 
        : base(commandName, [x.ToString(), y.ToString()])
    {
    }

    public MouseMoveCommand(int x, int y) : this("mousemove", x, y)
    {
    }

    public MouseMoveCommand AddClearModifiersFlag()
    {
        AddFlag(new ClearModifiersFlag());

        return this;
    }

    public MouseMoveCommand AddSyncFlag()
    {
        AddFlag(new SyncFlag());

        return this;
    }
}
