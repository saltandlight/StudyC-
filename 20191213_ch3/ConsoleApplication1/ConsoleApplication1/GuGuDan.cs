using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class GuGuDan
    {
        static void Main()
        {
            for(int i = 1; i < 10; i++)
            {
                for(int j = 1; j < 10; j++)
                {
                    System.Console.WriteLine(i + " * " + j + " = " + i * j);
                }
            }
        }
    }
}
