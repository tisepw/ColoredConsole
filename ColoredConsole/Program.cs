using System;
using System.Threading;

namespace ColoredConsole
{
    public class Spinner
    {
        public Spinner(string _text)
        {
            text = _text;
            thread = new Thread(Animate);
        }

        private const string cycle = @"/-\|";
        private readonly Thread thread;
        private readonly string text;
        private const int delay = 100;
        private bool isActive = false;
        private int counter = 0;
        private int left;
        private int top;

        public void Start()
        {
            Program.WriteLog($"{text} [ ]", Program.LogStatus.Default, false);

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

            thread.Interrupt();
        }

        private void Draw()
        {
            Console.SetCursorPosition(left, top);
            Console.Write(cycle[counter++ % cycle.Length]);
        }
    }

    public class Loader
    {
        public Loader(string _text)
        {
            text = _text;
            thread = new Thread(Animate);
        }

        private readonly Thread thread;
        private readonly string text;
        private bool isActive = false;
        private byte progress = 0;
        private int left;
        private int top;

        public void Start()
        {
            Program.WriteLog($"{text} [.........................]", Program.LogStatus.Default, false);

            left = Console.CursorLeft - 26;
            top = Console.CursorTop;

            if (!thread.IsAlive)
                thread.Start();
        }

        private void Stop(bool _successful = true)
        {
            isActive = false;
            thread.Join();                          // reread

            Console.SetCursorPosition(left, top);
            Console.Write(_successful ? "] [v]\n" : "] [x]\n");
        }


        private void Animate()
        {
            while (isActive)
            {
                Draw();
            }

            thread.Interrupt();
        }

        private void Draw()
        {
            Console.SetCursorPosition(left + progress, top);
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
            //TestColor();
            TestSpinner();
            //TestLoader();
            

            WriteLog("Exit . . .", LogStatus.Comment);
            Console.ReadKey();
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


        public static void TestColor()
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
            WriteLog("Downloading [############.............]", LogStatus.Default);
            WriteLog("Downloading [.........................]", LogStatus.Default);

            /*
            
            Loader loader = new("Downloading");
            loader.Start();
            loader.setProgress();
            loader.Stop(false);

             */
        }
    }
}