using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class ByteExamcs
    {
        static void Main()
        {
            byte value = 254;
            //byte형은 255까지 가능했음
            System.Console.WriteLine("value 값은-> {0}", value);
            value++;
            System.Console.WriteLine("value+1 값은-> {0}", value);
            value++;
            System.Console.WriteLine("value+2 값은-> {0}", value);
            value++;
            System.Console.WriteLine("value+3 값은-> {0}", value);
        }
    }
}
