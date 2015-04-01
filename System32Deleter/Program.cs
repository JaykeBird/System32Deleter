using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System32Deleter
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("System32 Deleter Version 4.1");
            Console.WriteLine("Written by The PC Cleaner Guys");
            Console.WriteLine();

            Console.WriteLine("System32 Deleter will help you with common computer problems, such as");
            Console.WriteLine("your computer being slow, computer viruses, and bad Internet connections.");
            Console.WriteLine("By deleting some unnecessary files from your hard drive, System32 Deleter");
            Console.WriteLine("will get your computer working just like new again!");
            Console.WriteLine();

            Console.Write("Begin deleting System32? (Y/n): ");
            ConsoleKeyInfo cki = Console.ReadKey();
            if (cki.KeyChar == 'y' || cki.KeyChar == 'Y')
            {
                Console.WriteLine();
                Console.Write("Are you sure? (Y/n): ");
                ConsoleKeyInfo ckc = Console.ReadKey();
                if (ckc.KeyChar == 'y' || ckc.KeyChar == 'Y')
                {
                    Console.WriteLine();
                    Console.WriteLine();

                    Console.WriteLine("Now deleting:");
                    Console.WriteLine();

                    // begin deleting System32
                    // TODO: Make this multithreaded
                    Cleaner cl = new Cleaner();
                    cl.Start();

                    // Alright, now that that's done
                    Console.WriteLine();
                    Console.WriteLine("Alright, your System32 is deleted!");
                    Console.WriteLine("Please enjoy your improved computing experience!");
                    Console.WriteLine("And, lastly,");
                    Console.WriteLine();
                    Console.WriteLine("\u0048\u0061\u0070\u0070\u0079\u0020\u0041\u0070\u0072\u0069\u006C\u0020\u0046\u006F\u006F\u006C\u0073\u0021");

                    Console.WriteLine();
                    Console.Write("Press any key to continue: ");
                    Console.ReadKey();
                    Console.WriteLine();
                }
            }
        }
    }
}
