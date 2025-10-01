namespace XDoTool.WindowCommands;
public class WindowQuitCommand(long windowId) : Command("windowquit", [windowId.ToString()])
{
}
