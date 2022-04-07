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
                var oddNumbers = GetOddNumbersUseLocalFunction(50, 100);
                oddNumbers.ToList().ForEach(i => Console.Write($"{i}, "));
                Console.WriteLine();

                var oddNumbers2 = GetOddNumbersUseLocalFunctionPrintErrors(50, 100);
                oddNumbers2.ToList().ForEach(i => Console.Write($"{i}, "));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }

            Console.ReadKey();
        }

        ///Non local function way of 
        public static IEnumerable<int> GetOddNumbersNotLocal(int start, int end)
        {
            //Validate
            if (start < 0 || start > 99)
                throw new ArgumentOutOfRangeException(nameof(start), "start must be between 0 and 99.");
            if (end > 100)
                throw new ArgumentOutOfRangeException(nameof(end), "end must be less than or equal to 100.");
            if (start >= end)
                throw new ArgumentException("start must be less than end.");

            //Iterate
            for (int i = start; i <= end; i++)
            {
                if (i % 2 == 1)
                    yield return i;
            }
        }

        //Local function throw
        public static IEnumerable<int> GetOddNumbersUseLocalFunction(int start, int end)
        {
            validate();
           
            for (int i = start; i <= end; i++)
            {
                if (i % 2 == 1)
                    yield return i;
            }

            void validate()
            {
                if (start < 0 || start > 99)
                    throw new ArgumentOutOfRangeException(nameof(start), "start must be between 0 and 99.");
                if (end > 100)
                    throw new ArgumentOutOfRangeException(nameof(end), "end must be less than or equal to 100.");
                if (start >= end)
                    throw new ArgumentException("start must be less than end.");
            }
        }

        //local function writer errors
        public static IEnumerable<int> GetOddNumbersUseLocalFunctionPrintErrors(int start, int end)
        {
            List<string> errors = new();
            validate();
            if (errors.Count > 0)
            {
                errors.ForEach(i => Console.WriteLine($"Error: {i}"));
                return new List<int>();
            }

            return Iterate();

            IEnumerable<int> Iterate()
            {
                for (int i = start; i <= end; i++)
                {
                    if (i % 2 == 1)
                        yield return i;
                }
            }

            void validate()
            {
                if (start < 0 || start > 99)
                    errors.Add("start must be between 0 and 99.");
                if (end > 100)
                    errors.Add("end must be less than or equal to 100.");
                if (start >= end)
                    errors.Add("start must be less than end.");               
            }
        }
    }
}
