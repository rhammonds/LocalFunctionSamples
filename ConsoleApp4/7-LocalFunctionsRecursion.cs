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
            var numbers = "123456789";
            Console.WriteLine(Reverse(numbers));
            Console.WriteLine(Reverse(Reverse(numbers)));
            Console.ReadKey();

            static string Reverse(string s)
            {
                if (s.Length == 1) return s;
                return Reverse(s.Substring(1)) + s[0];  
            }
        }

    }
}
