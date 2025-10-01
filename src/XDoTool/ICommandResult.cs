namespace XDoTool;

public interface ICommandResult<TResult>
{
    void SetCommandOutput(string commandOutput);
    
    TResult GetCommandOutputValue();
}
