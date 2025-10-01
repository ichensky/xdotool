using XDoTool.CommandFlags;
using XDoTool.WindowCommands;

namespace XDoTool.WindowCommands;public class WindowSizeCommand : Command
{
    private const string commandName = "selectwindow";

    public WindowSizeCommand(long windowId,int x, int y) : base(commandName, [windowId.ToString(), x.ToString(), y.ToString()]) { }

    public WindowSizeCommand(long windowId, Percent<int> x, Percent<int> y) : base(commandName, [windowId.ToString(), x.ToString(), y.ToString()]) { }

    public WindowSizeCommand AddUseHintsFlag()
    {
        AddFlag(new Command("--usehints"));

        return this;
    }

    public WindowSizeCommand AddSyncFlag()
    {
        AddFlag(new SyncFlag());

        return this;
    }
}