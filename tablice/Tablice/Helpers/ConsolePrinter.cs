using System;
using System.Collections.Generic;
using System.Text;
using Tablice.Logic;

namespace Tablice.Helpers
{
    class ConsolePrinter
    {
        private readonly IDataManipulator _dataManipulator;


        public ConsolePrinter(IDataManipulator dataManipulator)
        {
            _dataManipulator = dataManipulator;
        }


        public void PrintEachSaldo()
        {
            Console.WriteLine("Doctors saldo:");
            for (int i = 0; _dataManipulator.GetDoctorsVolume() > i; i++)
                Console.WriteLine($"{_dataManipulator.GetName(i)} | Saldo: {_dataManipulator.GetSaldo(i)}");
            Console.WriteLine();
        }


        public void PrintGlobalSaldo()
        {
            Console.WriteLine("Global saldo:");
            Console.WriteLine(_dataManipulator.GetGlobalSaldo());
            Console.WriteLine();
        }


        public void PrintMostHardworking()
        {
            Console.WriteLine("Most hardworking doctor:");
            Console.WriteLine(_dataManipulator.GetMostHardworkingDoctor());
            Console.WriteLine();
        }
    }
}
