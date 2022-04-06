using System;
using System.Collections.Generic;
using System.IO;
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
            var (result, number) = Process(3);
            result.ForEach(i => Console.WriteLine(i));
            Console.WriteLine(number);
            Console.ReadKey();
        }

        static (List<string>, int) Process(int input)
        {
            string data = "Monday\nTuesday\nWednesday\nThursday\nFriday\n";
            using var reader = new StringReader(data);

            int output; //must be declared before local methods
            List<string> list = new();

            process();
            processStringReader();

            return (list, output);



            void process() => output = 100 * input + input + globalVar;

            void processStringReader()
            {
                while (true)
                {
                    var line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                    list.Add(line);
                }
            }

        }
    }
}
