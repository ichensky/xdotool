namespace XDoTool.WindowCommands;

public record Percent<TValue>(TValue Value)
{
    public override string ToString()
    {
        return base.ToString() + '%';
    }
};
