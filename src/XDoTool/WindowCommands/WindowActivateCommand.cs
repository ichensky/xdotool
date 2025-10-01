using XDoTool.CommandFlags;

namespace XDoTool.WindowCommands;
public class WindowActivateCommand(long windowId) : Command("windowactivate", [windowId.ToString()])
{
    public WindowActivateCommand AddSyncFlag()
    {
        AddFlag(new SyncFlag());

        return this;
    }
}
