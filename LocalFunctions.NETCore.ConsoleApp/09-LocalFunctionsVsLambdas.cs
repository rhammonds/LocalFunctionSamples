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
            //local variables;
            Func<int, int> square1;
            Func<int, int> square3 = x => x * x; //set using expression body

            //local methods
            int square2(int x) => x * x;
            Func<int, int> square4()
            {
                static int square(int x) => x * x;
                return square;
            }

            // 1. lambda delegate
            square1 = x => x * x;
            Console.WriteLine("Square is {0}", square1(2));

            // 2. local method
            Console.WriteLine("Square is {0}", square2(2));

            // 3. local function that return lambda delegate
            Console.WriteLine("Square is {0}", square4()(2));

            // 4. set lambda delegate to local method delegate
            square1 = square4();
            Console.WriteLine("Square is {0}", square1(2));
           
            Console.Read();
        }
    }
}
