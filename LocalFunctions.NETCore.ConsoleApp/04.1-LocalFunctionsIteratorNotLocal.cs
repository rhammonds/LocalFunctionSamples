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
            try
            {
                var oddNumbers = GetOddNumbers(50, 110);
                Console.WriteLine("Retrieved enumerator...");//Enumerator will be retrieved even though error

                foreach (var i in oddNumbers)  //Error thrown in this loop
                {
                    Console.Write($"{i} ");
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            Console.ReadKey();
        }

        public static IEnumerable<int> GetOddNumbers(int start, int end)
        {
            if (start < 0 || start > 99)
                throw new ArgumentOutOfRangeException(nameof(start), "start must be between 0 and 99.");
            if (end > 100)
                throw new ArgumentOutOfRangeException(nameof(end), "end must be less than or equal to 100.");
            if (start >= end)
                throw new ArgumentException("start must be less than end.");

            for (int i = start; i <= end; i++)
            {
                if (i % 2 == 1)
                    yield return i;
            }
        }

    }
}
