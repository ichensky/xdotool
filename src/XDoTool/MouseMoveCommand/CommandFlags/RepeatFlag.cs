namespace XDoTool.MouseMoveCommand.CommandFlags;

internal class RepeatFlag(int repeat) : Command("--repeat", [repeat.ToString()])
{
}
