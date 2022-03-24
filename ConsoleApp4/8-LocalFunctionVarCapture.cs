using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFunctionSamples
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine(Process(3));
            Console.ReadKey();
        }
        static int Process (int input)
        {
            int output;
            process();
            return output;

            void process() => output = 100 * input + input;
        }
    }
}
