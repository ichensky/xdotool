# xdotool
C# wrapper over `xdotool` - command-line X11 automation tool

### 1. Install nuget package: 

https://www.nuget.org/packages/XDoTool

---

### 2. install `xdootool`

```sh
$ apt install xdotool 
```

### links 
`xdotool` repository: 
https://github.com/jordansissel/xdotool

`xdotool` documentation:

https://man.archlinux.org/man/xdotool.1.en

https://manpages.debian.org/testing/xdotool/xdotool.1.en.html

### Example of usage

```csharp
using System.Threading.Channels;
using XDoTool;
using XDoTool.WindowCommands;

// Execute single command
// 1. Start xdootol process
// 2. Execute command 1
// 3. Get result
// 4. End xdotool process
var windowId = await XDoTool.XDoTool.ExecuteCommandAsync(new GetActiveWindowCommand());

// Execute single command
// 1. Start xdootol process
// 2. Execute command 1
// 3. End xdotool process
ICommand windowMoveCommand = new WindowMoveCommand(windowId, new Percent<int>(5), new Percent<int>(5));

await XDoTool.XDoTool.ExecuteCommandAsync(windowMoveCommand);

// Execute several command
// 1. Start xdootol process
// 2. Execute commands 1,2,...
// 3. End xdotool process
var channel = Channel.CreateBounded<ICommand>(100);

// Push commands to `xdotool`
Task.Run(async () =>
{
    ICommand windowMoveCommand = new WindowMoveCommand(windowId, new Percent<int>(5), new Percent<int>(5));

    await channel.Writer.WriteAsync(windowMoveCommand);
    await channel.Writer.WriteAsync(windowMoveCommand);

    await Task.Delay(100);
    await channel.Writer.WriteAsync(windowMoveCommand);
    await channel.Writer.WriteAsync(windowMoveCommand);

    channel.Writer.Complete();
});

// Start `xdotool` process and wait for commands 1,2,... 
await XDoTool.XDoTool.ExecuteCommandsAsync(channel.Reader);
```