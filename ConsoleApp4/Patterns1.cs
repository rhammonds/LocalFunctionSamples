using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFunctionSamples
{
    static class Patterns1
    {
        public static void Main()
        {
            var e = "";
            if (e is not null)
            {
                Console.WriteLine("not null");
            }
            if (IsLetter('1'))
            {
                Console.WriteLine("Is Letter");
            }
            var y = 1;

            var z = false;

            z = y > 0 && y < 10;
            z = y is > 0 and < 10;
            z = y is > 0 && y is < 10;


            var d = DateTime.Now;

            bool d1;

            d1 = d is { Year: 2020 };
            d1 = d.Year == 2020;

            //

            var a = new Animal();
            Animal b = new();
        }

        static Animal B => new Animal();

        public static bool IsLetter(this char c) =>
            c is >= 'a' and <= 'z' or >= 'A' and <= 'Z';

        static bool IsConferenceDay(DateTime date) => date is { Year: 2020, Month: 5, Day: 19 or 20 or 21 };

        //static int GetRectangleArea(int length, int breadth) => length * breadth; //shorter length, removes return and extra spaces
        //static int GetRectangleAreb(int length, int breadth) { length * breadth; }
        //static int GetRectangleAreb(int length, int breadth) { return length * breadth; }

    }
    public class Animal
    {

    }
}
