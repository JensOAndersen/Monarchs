using System;
using System.Collections.Generic;
using System.Text;

namespace Monarchs.App.Helpers
{
    public static class Prompt
    {
        public static void Write(string msg)
        {
            Console.WriteLine("> " +msg);
        }

        public static void ErrorExit(string msg)
        {
            Write(msg);
            Console.ReadKey();
            Environment.Exit(0);
        }

        public static void Wait()
        {
            Console.ReadKey(true);
        }
    }
}
