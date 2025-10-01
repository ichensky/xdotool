namespace XDoTool.WindowCommands;

public class SetWindowCommand(long windowId) : Command("set_window", [windowId.ToString()])
{
    SetWindowCommand AddNameFlag(string newName)
    {
        AddFlag(new Command("--name", [newName]));

        return this;
    }

    SetWindowCommand AddIconNameFlag(string newIconName)
    {
        AddFlag(new Command("--icon-name", [newIconName]));

        return this;
    }

    SetWindowCommand AddRoleFlag(string newRole)
    {
        AddFlag(new Command("--role", [newRole]));

        return this;
    }

    SetWindowCommand AddClassNameFlag(string classname)
    {
        AddFlag(new Command("--class", [classname]));

        return this;
    }

    SetWindowCommand AddUrgencyFlag(WindowUrgency value)
    {
        AddFlag(new Command("--class", [value.ToString()]));

        return this;
    }

}