using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LocalFunctionSamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DebugLogic();
            ReleaseLogic();
             
            //C# 9 attributes on local functions
            [Conditional("DEBUG")] 
            static void DebugLogic()
            {
                Console.WriteLine("Debug Mode");
            }

            [Conditional("RELEASE")]
            static void ReleaseLogic()
            {
                Console.WriteLine("Release Mode");
            }
            Console.ReadKey();

        }

        
    }
}
