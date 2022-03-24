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
            Action<string> Log = msg => Console.WriteLine(msg);

            //1. lambda delegate
            Func<int, int> square1;
            square1 = x => x * x;
            Console.WriteLine("Square is {0}", square1(2));

            //2. local method
            Console.WriteLine("Square is {0}", square2(2));

            //3. local function that return lambda delegate
            Console.WriteLine("Square is {0}", square4()(2) );

            //4. set lambda delegate to local method delegate
            square1 = square4();
            Console.WriteLine("Square is {0}", square1(2));
            Console.Read();

            return;


            int square2(int n) => n * n;

            Func<int, int> square4()
            {
                static int square(int x) => x * x;
                return square;
            }
        }
    }
}
