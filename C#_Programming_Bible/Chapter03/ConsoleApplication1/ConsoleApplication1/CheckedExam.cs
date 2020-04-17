using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class CheckedExam
    {
        static void Main()
        {
            int data1 = 99999;
            short data2 = checked((short)data1);
            Console.WriteLine("data1 = " + data2);
        }
    }
}
