using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    class FactorialExam
    { 
        static void Main()
        {
            Console.WriteLine("5!={0}", Factorial(5));
        }
        public static int Factorial(int num)
        {
            if (num > 1)
                return num * Factorial(num - 1);
            else
                return 1;
        }
    }
}
