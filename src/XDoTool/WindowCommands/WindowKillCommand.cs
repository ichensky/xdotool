namespace XDoTool.WindowCommands;
public class WindowKillCommand(long windowId) : Command("windowkill", [windowId.ToString()])
{
}
