namespace XDoTool.WindowCommands;
public class WindowStateCommand(long windowId) : Command("windowquit", [windowId.ToString()])
{
    WindowStateCommand AddAddFlag(WindowState windowState)
    {
        AddFlag(new Command("--add", [GetWindowStateValue(windowState)]));

        return this;
    }

    WindowStateCommand AddToogleFlag(WindowState windowState)
    {
        AddFlag(new Command("--toogle", [GetWindowStateValue(windowState)]));

        return this;
    }

    WindowStateCommand AddRemoveFlag(WindowState windowState)
    {
        AddFlag(new Command("--remove", [GetWindowStateValue(windowState)]));

        return this;
    }

    private static string GetWindowStateValue(WindowState windowState)
    {
        return Enum.GetName(typeof(WindowState), windowState) 
        ?? throw new ArgumentNullException(nameof(windowState));
    }
}
