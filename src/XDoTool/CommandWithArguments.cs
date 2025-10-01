namespace XDoTool.KeyBoardCommands;

public abstract class CommandWithArguments : Command
{
    public CommandWithArguments(string commandName, params string[] arguments) 
        : base(commandName, arguments)
    {
        if (arguments == null || arguments.Length == 0)
        {
            throw new ArgumentException("At least one key must be specified.", nameof(arguments));
        }
    }
}
