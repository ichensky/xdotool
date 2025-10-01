using XDoTool.CommandFlags;

namespace XDoTool.KeyBoardCommands;

/// <summary>
/// Types the given text as if typed on the keyboard.
/// </summary>
public sealed class TypeTextCommand(params string[] arguments) : CommandWithArguments("type", arguments)
{
    public TypeTextCommand AddClearModifiersFlag()
    {
        AddFlag(new ClearModifiersFlag());

        return this;
    }
}
