﻿// Copyright (c) Vlad_Den <vladden500@gmail.com>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;

namespace ColoredConsole
{
    class Writer
    {
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
