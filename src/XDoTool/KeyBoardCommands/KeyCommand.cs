using XDoTool.CommandFlags;

namespace XDoTool.KeyBoardCommands;

/// <summary>
/// Presses the given key or keys.
/// Multiple keys can be specified by separating them with a plus sign (+).
/// For example, to simulate pressing Ctrl+Alt+T, you would use the command:
/// xdotool key ctrl+alt+t
/// </summary>
public sealed class KeyCommand(params string[] arguments) : CommandWithArguments("key", arguments)
{
    public KeyCommand AddClearModifiersFlag()
    {
        AddFlag(new ClearModifiersFlag());

        return this;
    }
}