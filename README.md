# ColoredConsole
[![Build Test](https://github.com/VladDen4/ColoredConsole/actions/workflows/ci.yml/badge.svg?branch=master&event=push)](https://github.com/VladDen4/ColoredConsole/actions/workflows/ci.yml)
[![License](https://img.shields.io/github/license/VladDen4/ColoredConsole)](https://github.com/VladDen4/ColoredConsole/blob/master/LICENSE)
[![Version](https://img.shields.io/github/v/release/VladDen4/ColoredConsole?label=Version)](https://github.com/VladDen4/ColoredConsole/releases/latest)

Just... Console with colors and animations for 'professional' style.

## Preview
![ColoredConsoleReadme_v0 2 6-beta](https://user-images.githubusercontent.com/33760265/228392900-57d95a31-8874-4800-8e00-56c4518c5462.gif)

<details>
<summary>code</summary>

```csharp
private static void Main(string[] args)
{
    TestColor();
    TestSpinner();
    TestLoader();

    Thread.Sleep(1000);

    Writer.WriteLog("Exit . . .", LogStatus.Comment);
    Console.ReadKey();
}


public static void TestColor()
{
    Writer.WriteLog("TODO: fix files on server", LogStatus.Comment);
    Writer.WriteLog("Initialize colors . . .", LogStatus.Default);
    Writer.WriteLog("We have new update. Downloading . . .", LogStatus.Info);

    for (byte i = 1; i < 6; i++)
    {
        Writer.WriteLog($"Download part {i}/5", LogStatus.Default);
        Thread.Sleep(200);
    }

    Writer.WriteLog("All files downloaded. Installing . . .", LogStatus.Success);
    Writer.WriteLog("Some troubles found.", LogStatus.Warning);
    Writer.WriteLog("Whoops! Error occured. Get some help.", LogStatus.Error);
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

### Usage
Download the source code of the [Latest version](https://github.com/VladDen4/ColoredConsole/releases/latest) and integrate it into your project.

### Issues
To report issues, please head over to the [Issues](https://github.com/VladDen4/ColoredConsole/issues) page.

### Contributions
For contributions, please open a [Pull request](https://github.com/VladDen4/ColoredConsole/pull/new).

### License
ColoredConsole's code package is licensed under the MIT licence. Please see the licence file for more information. tl;dr you can do whatever you want as long as you include the original copyright and license notice in any copy of the software/source.
