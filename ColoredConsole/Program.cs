// Copyright (c) Vlad_Den <vladden500@gmail.com>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Threading;

namespace ColoredConsole
{
    public class Program
    {
        private static void Main(string[] args)
        {
            TestColor();
            TestSpinner();
            TestLoader();

            Thread.Sleep(1000);

            Writer.Log("Exit . . .");
            Console.ReadKey();
        }


        public static void TestColor()
        {
            Writer.Log("TODO: fix files on server");
            Writer.Log("Initialize colors . . .", LogStatus.Default);
            Writer.Log("We have new update. Downloading . . .", LogStatus.Info);

            for (byte i = 1; i < 6; i++)
            {
                Writer.Log($"Download part {i}/5");
                Thread.Sleep(200);
            }

            Writer.Log("All files downloaded. Installing . . .", LogStatus.Success);
            Writer.Log("Some troubles found.", LogStatus.Warning);
            Writer.Log("Whoops! Error occured. Get some help.", LogStatus.Error);
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