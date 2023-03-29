// Copyright (c) Vlad_Den <vladden500@gmail.com>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Collections;
using System.IO;

namespace ColoredConsole
{
    /// <summary>
    /// Console with colors for 'professional' style.
    /// </summary>
    class Writer
    {
        private static readonly Queue msgQueue = new();
        private static bool isProcessing = false;
        private static string logPath = @".\logs\";
        private static bool logToFile = false;

        /// <summary>
        /// Message obejct.
        /// </summary>
        private class Message
        {
            public readonly string text;
            public readonly LogStatus color;
            public readonly bool newLine;
            public readonly bool timestamp;
            public readonly bool toFile;

            public Message(string _text, LogStatus _color = LogStatus.Default, bool _newLine = true, bool _timestamp = true, bool _toFile = false)
            {
                text = _text;
                color = _color;
                newLine = _newLine;
                timestamp = _timestamp;
                toFile = _toFile;
            }
        }

        /// <summary>
        /// Create path and file name. Final path: .\logs\directoryName\yy.MM.dd-HH.mm.ss.log.
        /// </summary>
        /// <param name="_directoryName">Log folder name.</param>
        public static void CreateLogFile(string _directoryName)
        {
            logPath += $@"{_directoryName}\";

            if (!Directory.Exists(logPath))
                Directory.CreateDirectory(logPath);

            logPath += $@"{DateTime.Now:yy.MM.dd-HH.mm.ss}.log";

            if (!File.Exists(logPath))
                using (var logFile = File.Create(logPath)) { }

            logToFile = true;
        }

        /// <summary>
        /// Creates a new log in the console.
        /// </summary>
        /// <param name="_text">Text to display.</param>
        /// <param name="_color">Text color. See colors in <see cref="LogStatus"/>.</param>
        /// <param name="_newline">Is a newline needed?</param>
        /// <param name="_timestamp">Is a timestamp needed?</param>
        /// <param name="_toFile">Do you need to write to a file?</param>
        public static void Log(string _text, LogStatus _color = LogStatus.Comment, bool _newline = true, bool _timestamp = true, bool _toFile = true)
        {
            Message _msg = new(_text, _color, _newline, _timestamp, _toFile);
            msgQueue.Enqueue(_msg);

            Write();
        }

        /// <summary>
        /// The main method for writing logs to the console and to a file.
        /// </summary>
        private static void Write()
        {
            if (isProcessing) return;

            isProcessing = true;

            if (msgQueue.Count < 1)
            {
                isProcessing = false;
                return;
            }

            Message _msg = (Message)msgQueue.Dequeue();

            string currentTime = DateTime.Now.ToString("T");

            Console.Write(_msg.timestamp ? $"[{currentTime}] " : "");

            Console.ForegroundColor = (ConsoleColor)_msg.color;
            Console.Write(_msg.text);
            Console.Write(_msg.newLine ? "\n" : "");

            Console.ResetColor();

            if (logToFile && File.Exists(logPath) && _msg.toFile) File.AppendAllText(logPath, $"[{currentTime}] {_msg.text}\n");

            isProcessing = false;

            Write();
        }
    }
}