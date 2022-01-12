using System;
using System.Threading;

namespace ColoredConsole
{
    public class Spinner
    {
        public Spinner(string _text, int _delay = 100)
        {
            delay = _delay;
            text = _text;
            thread = new Thread(Animate);
        }

        private const string cycle = @"/-\|";
        private readonly Thread thread;
        private readonly int delay;
        private bool isActive = false;
        private readonly string text;
        private int counter = 0;
        private int left;
        private int top;

        public void Start()
        {
            Program.WriteLog(text + " [ ]", Program.LogStatus.Default, true, false);

            left = Console.CursorLeft - 2;
            top = Console.CursorTop;

            isActive = true;
            if (!thread.IsAlive)
                thread.Start();
        }

        public void Stop(bool _successful = true)
        {
            isActive = false;
            thread.Join();                          // reread

            Console.SetCursorPosition(left, top);
            Console.Write(_successful ? "v]\n" : "x]\n");
        }

        private void Animate()
        {
            while (isActive)
            {
                Draw();
                Thread.Sleep(delay);
            }
            try
            {
                thread.Interrupt();
                Thread.Sleep(Timeout.Infinite);
            }
            catch (ThreadInterruptedException)
            {

            }
        }

        private void Draw()
        {
            Console.SetCursorPosition(left, top);
            Console.Write(cycle[counter++ % cycle.Length]);
        }
    }

    public class Loader
    {
        public Loader()
        {
            thread = new Thread(Animate);
        }

        private readonly Thread thread;
        private int counter = 0;
        private int left;
        private int top;

        public void Start()
        {
            if (!thread.IsAlive)
                thread.Start();
        }

        public void Stop()
        {
            thread.Join();                          // reread
        }

        private void Animate()
        {

        }

        private void Draw()
        {

        }
    }

    public class Program
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

        private static void Main(string[] args)
        {
            WriteLog("TODO: fix files on server", LogStatus.Comment);
            WriteLog("Initialize colors . . .", LogStatus.Default);
            WriteLog("We have new update. Downloading . . .", LogStatus.Info);

            for (byte i = 1; i < 6; i++)
            {
                WriteLog($"Download part {i}/5", LogStatus.Default);
                Thread.Sleep(200);
            }

            WriteLog("All files downloaded. Installing . . .", LogStatus.Success);
            WriteLog("Some troubles found.", LogStatus.Warning);
            WriteLog("Whoops! Error occured. Get some help.", LogStatus.Error);

            Spinner spinner = new ("Trying to fix");
            spinner.Start();
            Thread.Sleep(5000);
            spinner.Stop(false);

            WriteLog("Exit . . .", LogStatus.Comment);
            Console.ReadKey();
        }

        public static void WriteLog(string _text, LogStatus _color, bool _timestamp = true, bool _newline = true)
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