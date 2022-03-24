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
            
            Console.WriteLine("Difference is {0}", GetSum());
            Console.WriteLine("Difference is {0}", GetDifference());
            Console.ReadKey();
     
            int GetSum() =>  a1 + a2; //expression body
            int GetDifference()=> a2 - a1;
        }
    }
}
