using XDoTool.CommandFlags;
using XDoTool.MouseMoveCommand.CommandFlags;

namespace XDoTool.MouseMoveCommand;

public class MouseClickCommand : Command
{
    internal MouseClickCommand(string commandName, MouseButton mouseButton) : base(commandName, [mouseButton.ToString()])
    {
    }
    public MouseClickCommand(MouseButton mouseButton) : this("click", mouseButton)
    {
    }

    public MouseClickCommand AddClearModifiersFlag()
    {
        this.AddFlag(new ClearModifiersFlag());

        return this;
    }

    public MouseClickCommand AddRepeatFlag(int repeat)
    {
        AddFlag(new RepeatFlag(repeat));

        return this;
    }

    public MouseClickCommand AddDelayFlag(int delayInMs)
    {
        AddFlag(new DelayFlag(delayInMs));

        return this;
    }
}


