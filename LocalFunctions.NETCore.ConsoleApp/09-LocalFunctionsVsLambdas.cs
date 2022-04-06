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
            Func<int, int> squareDelegate;
            Func<int, int> squareDelegate2 = x => x * x; //set using expression body

            //local methods
            int squareLocalF(int x) => x * x;
            Func<int, int> squareReturnDelegate()
            {
                static int square(int x) => x * x;
                return square;
            }

            // 1. lambda delegate
            squareDelegate = x => x * x;
            Console.WriteLine("Square is {0}", squareDelegate(2));

            // 2. local function
            Console.WriteLine("Square is {0}", squareLocalF(2));

            // 3. local function that returns lambda delegate
            Console.WriteLine("Square is {0}", squareReturnDelegate()(2));

            // 4. set lambda delegate to local method delegate
            squareDelegate = squareReturnDelegate();
            Console.WriteLine("Square is {0}", squareDelegate(2));
           
            Console.Read();
        }
    }
}
