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
            Console.WriteLine(ReverseFuncAnnonymous(numbers));
            Console.WriteLine(ReverseLocal(ReverseLocal(numbers)));
            Console.ReadKey();

        }
        public static string ReverseLocal(string s)
        {
            return reverse(s);

            static string reverse(string s) //note static
            {
                if (s.Length == 1) return s;
                return reverse(s.Substring(1)) + s[0];
            }
        }

        public static string ReverseLocalLambda(string s)
        {
            return reverse(s);

            static string reverse(string x) => (x.Length == 1) ? x : reverse(x.Substring(1)) + x[0];
                         
        }

        public static string ReverseFuncAnnonymous(string s)
        {
            Func<string, string> reverse = null;

            reverse = delegate (string s)
            {
                if (s.Length == 1) return s;
                return reverse(s.Substring(1)) + s[0];
            };

            return reverse(s);
        }

        public static string ReverseFuncLambda(string s)
        {
            Func<string, string> reverse = null;
            reverse = x => (x.Length == 1) ? x : reverse(x.Substring(1)) + x[0];

            return reverse(s);
        }
    }
}
