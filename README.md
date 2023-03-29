# ColoredConsole
[![Build Test](https://github.com/VladDen4/ColoredConsole/actions/workflows/ci.yml/badge.svg?branch=master&event=push)](https://github.com/VladDen4/ColoredConsole/actions/workflows/ci.yml)
[![License](https://img.shields.io/github/license/VladDen4/ColoredConsole)](https://github.com/VladDen4/ColoredConsole/blob/master/LICENSE)
[![Version](https://img.shields.io/github/v/release/VladDen4/ColoredConsole?label=Version)](https://github.com/VladDen4/ColoredConsole/releases/latest)

Just... Console with colors and animations for 'professional' style.

## Preview
![Readme-v1 0 6](https://user-images.githubusercontent.com/33760265/228528705-0f4af36a-a976-4ec8-8929-16705e39bd6f.gif)

<details>
    <summary>code</summary>
    
```csharp
private static void Main(string[] args)
{
    TestColor();
    TestSpinner();
    TestLoader();

    Thread.Sleep(1000);

    Writer.Log("Exit . . .");
    Console.ReadKey();
}

public static void TestColor()
{
    Writer.Log("TODO: fix files on server");
    Writer.Log("Initialize colors . . .", LogStatus.Default);
    Writer.Log("We have new update. Downloading . . .", LogStatus.Info);

    for (byte i = 1; i < 6; i++)
    {
        Writer.Log($"Download part {i}/5");
        Thread.Sleep(200);
    }
    
    Writer.Log("All files downloaded. Installing . . .", LogStatus.Success);
    Writer.Log("Some troubles found.", LogStatus.Warning);
    Writer.Log("Whoops! Error occured. Get some help.", LogStatus.Error);
}
    
public static void TestSpinner()
{
    Spinner spinner = new("Trying to fix");
    spinner.Start();
    Thread.Sleep(5000);
    spinner.Stop(false);
}

public static void TestLoader()
{
    Loader loader = new("Downloading");
    loader.Start();

    for (byte i = 0; i < 51; i++)
    {
        loader.SetProgress(i);
        Thread.Sleep(100);
    }

    loader.Stop(false);
}
```
</details>

<details>
    <summary><h2>Usage<h2></summary>

### Download
Download the source code of the [Latest version](https://github.com/VladDen4/ColoredConsole/releases/latest) and integrate it into your project. You can only use the parts you need from the ones listed (Spinner and loader are optional).

- **LogStatus** - enum class containing colors for logging. You can change it to your own at any time.
- **Writer** - main class for logging. (Requied LogStatus class)
- **Spinner** - designed to show that the program is performing some task. (Requied Writer class)
- **Loader** - designed to demonstrate the percentage of task completion. (Requied Writer class)
    
### Manual
Method Writer.**Log** is the main one for logging. Params:
- `string _text` (required) - Text to display.
- `LogStatus _color` (default: LogStatus.Comment) - Text color. See colors in [LogStatus](https://github.com/VladDen4/ColoredConsole/blob/09ccdaa5498d710fcadeb913b35c56e3ad5faf9a/ColoredConsole/LogStatus.cs).
- `bool _newline` (default: true) - Is a newline needed?
- `bool _timestamp` (default: true) - Is a timestamp needed?
- `bool _toFile` (default: true; recording will not be done without first calling the `CreateLogFile` method) - Do you need to write to a file?
    
Some examples:
```csharp
Writer.Log("Message");                            // [15:41:25] Message  // DarkGray
Writer.Log("Message", LogStatus.Warning);         // [15:41:25] Message  // Yellow
Writer.Log("Message", LogStatus.Default, false);  // [15:41:25] Message  // Gray, without newline (\r\n)
Writer.Log("Message", _timestamp: false);         // Message             // DarkGray
Writer.Log("Message", _toFile: false);            // [15:41:25] Message  // DarkGray, without logging to file
```

<hr>

The Writer.**CreateLogfile** method is responsible for creating a file to which logs will be written. Params:
- `string _directoryName` (required) - Log folder name. Final path: .\logs\directoryName\yy.MM.dd-HH.mm.ss.log.

Example:
```csharp
Writer.CreateLogFile("v1.0.6"); // After starting the project, a file will be created along the path ".\logs\v1.0.6\23.03.29-15:41:25.log"
```
</details>

## Repository

### Issues
To report issues or suggest a new feature, please head over to the [Issues](https://github.com/VladDen4/ColoredConsole/issues) page.

### Contributions
For contributions, please open a [Pull request](https://github.com/VladDen4/ColoredConsole/pull/new).

### License
ColoredConsole's code package is licensed under the MIT licence. Please see the licence file for more information. tl;dr you can do whatever you want as long as you include the original copyright and license notice in any copy of the software/source.
