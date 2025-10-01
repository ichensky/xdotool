namespace XDoTool;

public interface ICommand
{
    string[] Arguments { get; }

    string CommandName { get; }

    string GetCommandString();
}