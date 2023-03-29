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

### Usage
Download the source code of the [Latest version](https://github.com/VladDen4/ColoredConsole/releases/latest) and integrate it into your project.

### Issues
To report issues, please head over to the [Issues](https://github.com/VladDen4/ColoredConsole/issues) page.

### Contributions
For contributions, please open a [Pull request](https://github.com/VladDen4/ColoredConsole/pull/new).

### License
ColoredConsole's code package is licensed under the MIT licence. Please see the licence file for more information. tl;dr you can do whatever you want as long as you include the original copyright and license notice in any copy of the software/source.
