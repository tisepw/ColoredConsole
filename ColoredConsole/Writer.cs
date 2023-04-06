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
    public static class Writer
    {
        private static readonly Queue msgQueue = new();
        private static string logPath = @".\logs\";
        private static bool isProcessing = false;
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

            public Message(string text, LogStatus color = LogStatus.Default, bool newLine = true, bool timestamp = true, bool toFile = false)
            {
                this.text = text;
                this.color = color;
                this.newLine = newLine;
                this.timestamp = timestamp;
                this.toFile = toFile;
            }
        }

        /// <summary>
        /// Create path and file name. Final path: .\logs\directoryName\yy.MM.dd-HH.mm.ss.log.
        /// </summary>
        /// <param name="directoryName">Log folder name.</param>
        public static void CreateLogFile(string directoryName)
        {
            logPath += $@"{directoryName}\";

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
        /// <param name="text">Text to display.</param>
        /// <param name="color">Text color. See colors in <see cref="LogStatus"/>.</param>
        /// <param name="newline">Is a newline needed?</param>
        /// <param name="timestamp">Is a timestamp needed?</param>
        /// <param name="toFile">Do you need to write to a file?</param>
        public static void Log(string text, LogStatus color = LogStatus.Comment, bool newline = true, bool timestamp = true, bool toFile = true)
        {
            Message message = new(text, color, newline, timestamp, toFile);
            msgQueue.Enqueue(message);

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

            Message message = (Message)msgQueue.Dequeue();

            string currentTime = DateTime.Now.ToString("T");

            Console.Write(message.timestamp ? $"[{currentTime}] " : "");

            Console.ForegroundColor = (ConsoleColor)message.color;
            Console.Write(message.text);
            Console.Write(message.newLine ? "\n" : "");

            Console.ResetColor();

            if (logToFile && File.Exists(logPath) && message.toFile) File.AppendAllText(logPath, $"[{currentTime}] {message.text}\n");

            isProcessing = false;

            Write();
        }
    }
}