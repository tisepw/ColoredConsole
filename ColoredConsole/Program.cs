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
            Writer.WriteLog($"{text} [ ]", Writer.LogStatus.Default, false);

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
        }

        private readonly string text;
        private byte prevPosition;
        private byte progress = 0;
        private int left;
        private int top;

        public void Start()
        {
            Writer.WriteLog($"{text} [.........................]", Writer.LogStatus.Default, false);

            left = Console.CursorLeft - 26;
            top = Console.CursorTop;
        }

        public void Stop(bool _successful = true)
        {
            Console.SetCursorPosition(left + 27, top);
            Console.Write(_successful ? "[v]\n" : "[x]\n");
        }

        public void SetProgress(byte _progress)
        {
            if (progress < _progress && _progress < 100)
                progress = _progress;

            if (prevPosition < left + (progress / 4))
            {
                Draw();
                prevPosition = (byte)(left + (progress / 4));
            }
        }

        private void Draw()
        {
            Console.SetCursorPosition(left + (progress / 4), top);
            Console.Write("#");
        }
    }



    public class Program
    {
        private static void Main(string[] args)
        {
            TestColor();
            TestSpinner();
            TestLoader();

            //Thread.Sleep(5000);

            Writer.WriteLog("Exit . . .", Writer.LogStatus.Comment);
            Console.ReadKey();
        }


        public static void TestColor()
        {
            Writer.WriteLog("TODO: fix files on server", Writer.LogStatus.Comment);
            Writer.WriteLog("Initialize colors . . .", Writer.LogStatus.Default);
            Writer.WriteLog("We have new update. Downloading . . .", Writer.LogStatus.Info);

            for (byte i = 1; i < 6; i++)
            {
                Writer.WriteLog($"Download part {i}/5", Writer.LogStatus.Default);
                Thread.Sleep(200);
            }

            Writer.WriteLog("All files downloaded. Installing . . .", Writer.LogStatus.Success);
            Writer.WriteLog("Some troubles found.", Writer.LogStatus.Warning);
            Writer.WriteLog("Whoops! Error occured. Get some help.", Writer.LogStatus.Error);
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
    }
}