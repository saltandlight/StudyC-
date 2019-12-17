using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    class enumExam2
    {
        enum Range1:long { Max = 2147486348L, Min=255L};
        enum Range2: byte { Type = 255, Bottom = 0};
        static void Main()
        {
            long x = (long)Range1.Max;
            long y = (byte)Range2.Bottom;
            Console.WriteLine("Max = {0}, Bottom = {1}", x, y);
        }
    }
}
