using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace LocalFunctionSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            NumberProcessor processor = new(); //new operator
            processor.PrintCalculations(3,4);
            Console.ReadLine();
        }
    }

    class NumberProcessor
    {
        public void PrintCalculations(int a1, int a2)
        {
            Console.WriteLine($"Sum of {a1} and {a2} is { GetSum()}");
            Console.WriteLine($"Difference of {a1} and {a2} is {GetDifference()}");
            Console.ReadKey();
     
            int GetSum() =>  a1 + a2;
            int GetDifference()
            {
                return a2 - a1;
            }
        }
    }
}
