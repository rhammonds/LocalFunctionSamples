using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LocalFunctionSamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var number = 5;
            foreach (var operation in Enum.GetValues(typeof(Operation)))
            {
                Process(number, (Operation)operation);
            }
            Console.ReadKey();
        }

        static void Process(int number, Operation operation)
        {
            Func<int, decimal> operate = null;

            switch (operation)
            {
                case Operation.doubleVal:
                    operate = doubleVal;
                    break;
                case Operation.tripleVal:
                    operate = tripleVal;
                    break;
                case Operation.halveVal:
                    operate = halveVal;
                    break;
                case Operation.specialVal:
                    operate = specialVal;
                    break;
            }

            Console.WriteLine($"{operation.ToString()} calculates to {operate(number)}");

            decimal doubleVal(int i) => (i * 2);
            decimal tripleVal(int i) => i * 3;
            decimal halveVal(int i) => i / 2;
            decimal specialVal(int i) => i / 2 * 7 + 4 * 3 / 5 / 3;
        }

        enum Operation
        {
            doubleVal,
            tripleVal,
            halveVal,
            specialVal
        }

    }
}
