// Copyright (c) Vlad_Den <vladden500@gmail.com>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;

namespace ColoredConsole
{
    /// <summary>
    /// Default colors for console.
    /// </summary>
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
