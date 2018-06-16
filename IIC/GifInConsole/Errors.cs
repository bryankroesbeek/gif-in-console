using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GifInConsole
{
    class Errors
    {
        public static void DisplayReaction(int numberOfErrors)
        {
            if (numberOfErrors < 2) Console.WriteLine("NICE TRY YOU DICK");
            else if (numberOfErrors < 9) Console.WriteLine("...");
            else if (numberOfErrors < 10) Console.WriteLine("You sure love to try and break this program, don't you?");
            else if (numberOfErrors < 19) Console.WriteLine("Ugh...");
            else if (numberOfErrors < 20) Console.WriteLine("WHY CAN'T YOU BE NORMAL");
            else if (numberOfErrors < 21)
            {
                Console.WriteLine("Here, take 15 seconds to decide if you want to do this again\n");
                for (int i = 0; i < 15; i++)
                {
                    Thread.Sleep(1000);
                    Console.Write(".");
                }
            }
            else if (numberOfErrors < 22)
            {
                Console.WriteLine("FUCK YOU, YOU ARE NOT USING THIS PROGRAM ANYMORE");
                Thread.Sleep(500);
                Console.WriteLine("fucking dick, i did not create this program for it to be abused by you...");
                Thread.Sleep(2500);
                Environment.Exit(0);
            }
        }
    }
}
