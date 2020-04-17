using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Arithmetic4
    {
        static void Main()
        {
            bool A = (3 > 10) & (10 > 3);
            bool B = (3 > 10) && (10 > 3);
            bool C = (10 > 3) | (3 > 10);
            bool D = (10 > 3) || (3 > 10);
            System.Console.WriteLine("A=" + A + " B=" + B + " C=" + C + " D=" + D);
        }
    }
}
