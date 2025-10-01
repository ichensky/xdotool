using XDoTool.CommandFlags;

namespace XDoTool.KeyBoardCommands;

/// <summary>
/// Simulates pressing down the specified key without releasing it.
/// This is useful for simulating key combinations or holding down a key.
/// </summary>
public sealed class KeyDownCommand(params string[] arguments) : CommandWithArguments("keydown", arguments)
{
    public KeyDownCommand AddClearModifiersFlag()
     {
        AddFlag(new ClearModifiersFlag());

        return this;
    }
}
