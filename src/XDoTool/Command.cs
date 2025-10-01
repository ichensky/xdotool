namespace XDoTool;

public interface ICommandWithResult<TCommandResult> : ICommand, ICommandResult<TCommandResult> { }

public abstract class CommandWithResult<TCommandResult> : Command, ICommandWithResult<TCommandResult> 
{
    protected string? commandOutput;

    internal CommandWithResult(string commandName, params string[] arguments) : base(commandName, arguments) { }

    public void SetCommandOutput(string commandOutput)
    {
        this.commandOutput = commandOutput;
    }

    public abstract TCommandResult GetCommandOutputValue();
}

public class Command : ICommand
{
    protected ICollection<ICommand> flags;

    public string CommandName { get; private set; }

    public string[] Arguments { get; private set; }

    internal Command(string commandName, params string[] arguments)
    {
        this.CommandName = commandName ?? throw new ArgumentNullException(nameof(commandName));
        this.Arguments = arguments ?? [];
        this.flags = [];
    }

    public virtual string GetCommandString()
    {
        return string.Join(' ', GetFlagsString(flags), this.CommandName, string.Join(' ', this.Arguments));
    }

    internal void AddFlag(ICommand flag)
    {
        ArgumentNullException.ThrowIfNull(flag);

        if (flags.Any(commandFlag => commandFlag.CommandName == commandFlag.CommandName))
        {
            throw new ArgumentException($"Flag with name '{flag.CommandName}' already exists in the command.");
        }

        flags.Add(flag);
    }

    private static string GetFlagsString(IEnumerable<ICommand> flags)
    {
        string flagsStr = string.Join(" ", flags.Where(flag =>
        {
            var flagStr = flag.ToString();
            return !string.IsNullOrEmpty(flagStr);
        }));

        return flagsStr;
    }

}
