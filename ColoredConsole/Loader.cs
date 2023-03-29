// Copyright (c) Vlad_Den <vladden500@gmail.com>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;

namespace ColoredConsole
{
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
            Writer.Log($"{text} [.........................]", LogStatus.Default, false);

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
}
