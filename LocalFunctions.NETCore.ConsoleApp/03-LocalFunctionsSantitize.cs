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
                var oddNumbers2 = GetOddNumbers2(50, 110);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }

            Console.ReadKey();
        }

        public static IEnumerable<int> GetOddNumbers(int start, int end)
        {
            Validate();
            return Iterate();

            IEnumerable<int> Iterate()
            {
                for (int i = start; i <= end; i++)
                {
                    if (i % 2 == 1)
                        yield return i;
                }
            }

            void Validate()
            {
                if (start < 0 || start > 99)
                    throw new ArgumentOutOfRangeException(nameof(start), "start must be between 0 and 99.");
                if (end > 100)
                    throw new ArgumentOutOfRangeException(nameof(end), "end must be less than or equal to 100.");
                if (start >= end)
                    throw new ArgumentException("start must be less than end.");
            }
        }

        public static IEnumerable<int> GetOddNumbers2(int start, int end)
        {
            var x = Validate();
            if (x.Count > 0)
            {
                x.ForEach(i => Console.WriteLine($"Error: {i}"));
                return null;
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

            List<string> Validate()
            {
                List<string> errors = new();
                if (start < 0 || start > 99)
                    errors.Add("start must be between 0 and 99.");
                if (end > 100)
                    errors.Add("end must be less than or equal to 100.");
                if (start >= end)
                    errors.Add("start must be less than end.");
                return errors;
            }
        }

        public static IEnumerable<int> GetOddNumbers3(int start, int end)
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
    }
}
