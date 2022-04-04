using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFunctionSamples
{
    class Program
    {
        static int globalVar = 3;
        public static void Main()
        {
            Console.WriteLine(Process(3));
            Console.ReadKey();
        }
        static int Process (int input)
        {
            int output; //must be declared before local methods
            process();
            return output;

            void process() => output = 100 * input + input + globalVar;
        }
    }
}
