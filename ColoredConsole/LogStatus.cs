using System;

namespace ColoredConsole
{
    public enum LogStatus : byte // Reread about using "byte" struct
    {
        Default = ConsoleColor.Gray,
        Warning = ConsoleColor.Yellow,
        Error = ConsoleColor.Red,
        Success = ConsoleColor.Green,
        Info = ConsoleColor.Cyan,
        Comment = ConsoleColor.DarkGray
    }
}
