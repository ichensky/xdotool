using XDoTool.CommandFlags;

namespace XDoTool.WindowCommands;

public class SearchCommand(string searchTerm) : CommandWithResult<IEnumerable<long>>("search", [searchTerm])
{
    public SearchCommand AddNameFlag()
    {
        AddFlag(new Command("--name", []));

        return this;
    }

    public SearchCommand AddClassFlag()
    {
        AddFlag(new Command("--class", []));

        return this;
    }

    public SearchCommand AddClassNameFlag()
    {
        AddFlag(new Command("--classname", []));

        return this;
    }

    public SearchCommand AddRoleFlag()
    {
        AddFlag(new Command("--role", []));

        return this;
    }

    public SearchCommand AddMaxDepthFlag(int maxDepth)
    {
        AddFlag(new Command("--maxdepth", [maxDepth.ToString()]));

        return this;
    }

    public SearchCommand AddOnlyVisibleFlag()
    {
        AddFlag(new Command("--onlyvisible", []));

        return this;
    }

    public SearchCommand AddPidFlag(int pid)
    {
        AddFlag(new Command("--pid", [pid.ToString()]));

        return this;
    }

    public SearchCommand AddScreenFlag(int screen)
    {
        AddFlag(new Command("--screen", [screen.ToString()]));

        return this;
    }

    public SearchCommand AddDesktopFlag(int desktop)
    {
        AddFlag(new Command("--desktop", [desktop.ToString()]));

        return this;
    }

    public SearchCommand AddLimitFlag(int limit)
    {
        AddFlag(new Command("--limit", [limit.ToString()]));

        return this;
    }

    public SearchCommand AddAllFlag()
    {
        AddFlag(new Command("--all", []));

        return this;
    }

    public SearchCommand AddAnyFlag()
    {
        AddFlag(new Command("--any", []));

        return this;
    }

    public SearchCommand AddSyncFlag()
    {
        AddFlag(new SyncFlag());

        return this;
    }

    public override IEnumerable<long> GetCommandOutputValue()
    {
        if (string.IsNullOrEmpty(this.commandOutput))
        {
            return [];
        }

        return commandOutput.Split(Environment.NewLine).Select(line => long.Parse(line));
    }
}
