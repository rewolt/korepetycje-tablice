using System;
using System.Collections.Generic;
using System.IO;
using Tablice.Helpers;
using Tablice.Logic;

namespace Tablice
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintHello();

            var parser = new PathParser(args);
            var filesToRead = parser.Files;

            if (filesToRead.Length == 0)
                PrintByeByeAndExit();

            var stringsTable = DataReader.Load_v1(filesToRead);
            var objectsTable = DataReader.Load_v2(filesToRead);

            var manipulator = new ObjectDataManipulator(objectsTable);
            var printer1 = new ConsolePrinter(manipulator);

            printer1.PrintEachSaldo();
            printer1.PrintGlobalSaldo();
            printer1.PrintMostHardworking();

            PrintByeByeAndExit();
        }

        private static void PrintHello()
        {
            var hello = "Hi!\n";
            Console.WriteLine(hello);
        }
        
        private static void PrintByeByeAndExit()
        {
            var byebye = "\nNothing more to do! Press any key to exit...";
            Console.WriteLine(byebye);
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
