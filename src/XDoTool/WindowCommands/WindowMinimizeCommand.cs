using XDoTool.CommandFlags;

namespace XDoTool.WindowCommands;
public class WindowMinimizeCommand(long windowId) : Command("windowminimize", [windowId.ToString()])
{
    public WindowMinimizeCommand AddSyncFlag()
    {
        AddFlag(new SyncFlag());

        return this;
    }
}