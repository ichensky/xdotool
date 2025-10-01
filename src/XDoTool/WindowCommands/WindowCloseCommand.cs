namespace XDoTool.WindowCommands;
public class WindowCloseCommand(long windowId) : Command("windowclose", [windowId.ToString()])
{
}