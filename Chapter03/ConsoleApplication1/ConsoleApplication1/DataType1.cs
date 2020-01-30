using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class DataType1
    {
        static void Main()
        {
            byte b = 10;
            short s =  023;
            int i = 0x10;
            long l = 10;

            System.Console.WriteLine("byte  :" + b);
            System.Console.WriteLine("short  :" + s);
            System.Console.WriteLine("int   :" + i);
            System.Console.WriteLine("long  :" + l);
        }
    }
}
