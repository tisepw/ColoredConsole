// Copyright (c) Vlad_Den <vladden500@gmail.com>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;

namespace ColoredConsole
{
    public class Loader
    {
        public Loader(string text)
        {
            this.text = text;
        }

        private readonly string text;
        private byte prevPosition;
        private byte progress = 0;
        private int left;
        private int top;


        public void Start()
        {
            Writer.Log($"{text} [.........................]", LogStatus.Default, false);

            left = Console.CursorLeft - 26;
            top = Console.CursorTop;
        }

        public void Stop(bool successful = true)
        {
            Console.SetCursorPosition(left + 27, top);
            Console.Write(successful ? "[v]\n" : "[x]\n");
        }


        public void SetProgress(byte progress)
        {
            if (this.progress < progress && progress < 100)
                this.progress = progress;

            if (prevPosition < left + (this.progress / 4))
            {
                Draw();
                prevPosition = (byte)(left + (this.progress / 4));
            }
        }

        private void Draw()
        {
            Console.SetCursorPosition(left + (progress / 4), top);
            Console.Write("#");
        }
    }
}
