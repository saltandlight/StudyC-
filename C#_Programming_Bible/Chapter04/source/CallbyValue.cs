using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    class CallbyValue
    {
        static void Main()
        {
            int x, y;
            x = 5;
            y = 10;
            Console.WriteLine("Main1(x, y)값 = ({0}, {1})", x, y);
            Swap(x, y);
            Console.WriteLine("Main2(x, y)값 = ({0}, {1})", x, y);
        }
        public static void Swap(int x, int y)
        {
            int temp = x;
            x = y;
            y = temp;
            Console.WriteLine("Swap(x, y) 값= ({0}, {1})", x, y);
        }
    }
}
