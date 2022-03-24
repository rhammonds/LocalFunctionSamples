using System;
using System.Runtime.CompilerServices;

namespace LocalFunctionSamples
{
    class ModuleInitializer1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.ReadLine();
            C.M2();
            Console.ReadLine();
        }
    }

    class C
    {
        [ModuleInitializer]
        internal static void M1()
        {
            Console.WriteLine("M1 Loaded");
               
        }
        internal static void M2()
        {
            Console.WriteLine("M2 Loaded");

        }
    }
}
