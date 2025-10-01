namespace XDoTool.MouseMoveCommand.CommandFlags;

internal class DelayFlag(int delayInMs) : Command("--delay", [delayInMs.ToString()])
{
}
