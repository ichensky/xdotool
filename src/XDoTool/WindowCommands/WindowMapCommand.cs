using XDoTool.CommandFlags;

namespace XDoTool.WindowCommands;
public class WindowMapCommand(long windowId) : Command("windowmap", [windowId.ToString()])
{
    public WindowMapCommand AddSyncFlag()
    {
        AddFlag(new SyncFlag());

        return this;
    }
}
