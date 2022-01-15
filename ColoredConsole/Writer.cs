using System;

namespace ColoredConsole
{
    class Writer
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

        public static void WriteLog(string _text, LogStatus _color, bool _newline = true, bool _timestamp = true)
        {
            Write((_timestamp ? $"[{DateTime.Now:T}] " : ""), false);

            Console.ForegroundColor = (ConsoleColor)_color;

            Write(_text, _newline);

            Console.ResetColor();
        }

        public static void Write(string _text, bool _newline = true)
        {
            Console.Write(_text + (_newline ? "\n" : ""));
        }
    }
}
