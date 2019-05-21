using System;
using System.Collections.Generic;
using System.Text;

namespace Monarchs.App.Helpers
{
    public static class Prompt
    {/*
        I tried making a fancy prompt class that handled all user input/output

        however i ran into some problems with console.readline, it didnt return the expected result.

        Still, the class adds a nice look and makes some functionality easier for me.
    */
        public static void Write(string msg)
        {
            Console.WriteLine("> " + msg);
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
