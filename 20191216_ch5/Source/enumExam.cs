using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    class enumExam
    {
        enum RainBow1 { red, orange, yellow, green, blue, indigo, violet };
        //              0     1       2       3     4      5      6
        enum RainBow2 { red = 2, orange, yellow, green, blue, indigo, violet };
        //              2       3       4       5   6       7       8
        enum RainBow3 { red, orange, yellow = 5, green, blue = 9, indigo, violet };
        //              0   1         5         6      9      10      11
        static void Main(string[] args)
        {
            Console.WriteLine("Rainbow1 = {0}-{1}-{2}-{3}-{4}-{5}-{6}",
                (int)RainBow1.red, (int)RainBow1.orange,
                (int)RainBow1.yellow, (int)RainBow1.green,
                (int)RainBow1.blue, (int)RainBow1.indigo,
                (int)RainBow1.violet);
            Console.WriteLine("Rainbow2 = {0}-{1}-{2}-{3}-{4}-{5}-{6}",
                (int)RainBow2.red, (int)RainBow2.orange,
                (int)RainBow2.yellow, (int)RainBow2.green,
                (int)RainBow2.blue, (int)RainBow2.indigo,
                (int)RainBow2.violet);
            Console.WriteLine("Rainbow3 = {0}-{1}-{2}-{3}-{4}-{5}-{6}",
                 (int)RainBow3.red, (int)RainBow3.orange,
                 (int)RainBow3.yellow, (int)RainBow3.green,
                 (int)RainBow3.blue, (int)RainBow3.indigo,
                 (int)RainBow3.violet);
        }
    }
}
