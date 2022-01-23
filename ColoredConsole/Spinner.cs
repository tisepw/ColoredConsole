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
            Writer.WriteLog($"{text} [ ]", LogStatus.Default, false);

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
}
