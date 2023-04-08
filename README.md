# ColoredConsole

[![Build Test](https://github.com/tisepw/ColoredConsole/actions/workflows/ci.yml/badge.svg?branch=master&event=push)](https://github.com/tisepw/ColoredConsole/actions/workflows/ci.yml)
[![License](https://img.shields.io/github/license/tisepw/ColoredConsole)](https://github.com/tisepw/ColoredConsole/blob/master/LICENSE)
[![Version](https://img.shields.io/github/v/release/tisepw/ColoredConsole?label=Version)](https://github.com/tisepw/ColoredConsole/releases/latest)

Just... Console with colors and animations for 'professional' style.

## Preview

![Readme-v1 0 6](https://user-images.githubusercontent.com/33760265/228528705-0f4af36a-a976-4ec8-8929-16705e39bd6f.gif)

You can find the source code from the preview [here](https://gist.github.com/VladDen4/b6d301e6a2075f2e906ee5d2711ffb4c).

## Usage

### Download

You can [download](https://www.nuget.org/packages/Tise.Util.ColoredConsole) the library as a NuGet package from nuget.org, or download the [latest source code](https://github.com/VladDen4/ColoredConsole/releases/latest) and build the package yourself.

### Methods

---

**Writer.Log** - Output logs to the console.
- `string text` (required) - Text to display.
- `LogStatus color` (default: LogStatus.Comment) - Text color. See colors in [LogStatus](https://github.com/VladDen4/ColoredConsole/blob/09ccdaa5498d710fcadeb913b35c56e3ad5faf9a/ColoredConsole/LogStatus.cs).
- `bool newline` (default: true) - Is a newline needed?
- `bool timestamp` (default: true) - Is a timestamp needed?
- `bool toFile` (default: true; recording will not be done without first calling the `CreateLogFile` method) - Do you need to write to a file?
    
Examples:
```csharp
Writer.Log("Message");                            // [15:41:25] Message  | DarkGray
Writer.Log("Message", LogStatus.Warning);         // [15:41:25] Message  | Yellow
Writer.Log("Message", LogStatus.Default, false);  // [15:41:25] Message  | Gray, without newline (\n)
Writer.Log("Message", timestamp: false);          // Message             | DarkGray
Writer.Log("Message", toFile: false);             // [15:41:25] Message  | DarkGray, without logging to file
```

---

**Writer.CreateLogfile** - Required method to start writing logs to a file. Without it, there will be no writing to the file.
- `string directoryName` (required) - Log folder name. Final path: .\logs\directoryName\yy.MM.dd-HH.mm.ss.log.

Examples:
```csharp
Writer.CreateLogFile();               // Logs path: ".\logs\23.03.29-15:41:25.log"
Writer.CreateLogFile(@"");            // Logs path: ".\logs\23.03.29-15:41:25.log"
Writer.CreateLogFile(@"v1.0.6");      // Logs path: ".\logs\v1.0.6\23.03.29-15:41:25.log"
Writer.CreateLogFile(@"v1.0.7\beta"); // Logs path: ".\logs\v1.0.7\beta\23.03.29-15:41:25.log"
Writer.CreateLogFile(@"..\");         // Logs path: ".\23.03.29-15:41:25.log"
```

---

## Repository

### Issues

To report issues or suggest a new feature, please head over to the [Issues page](https://github.com/VladDen4/ColoredConsole/issues).

### Contributions

For contributions, please open a [Pull request](https://github.com/VladDen4/ColoredConsole/pull/new).

### License

ColoredConsole's code package is licensed under the MIT licence. Please see the licence file for more information. tl;dr you can do whatever you want as long as you include the original copyright and license notice in any copy of the software/source.
