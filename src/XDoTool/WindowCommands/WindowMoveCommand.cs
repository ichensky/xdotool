using XDoTool.CommandFlags;
using XDoTool.WindowCommands;

namespace XDoTool.WindowCommands;
public class WindowMoveCommand : Command
{
    private const string commandName = "windowmove";

    public WindowMoveCommand(long windowId, int x, int y) : base(commandName, [windowId.ToString(), x.ToString(), y.ToString()]) { }

    public WindowMoveCommand(long windowId,Percent<int> x, Percent<int> y) : base(commandName, [windowId.ToString(), x.ToString(), y.ToString()]) { }

    public WindowMoveCommand AddRelativeFlag()
    {
        AddFlag(new Command("--relative"));

        return this;
    }

    public WindowMoveCommand AddSyncFlag()
    {
        AddFlag(new SyncFlag());

        return this;
    }
}

