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