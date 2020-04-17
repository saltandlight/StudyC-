using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class sum_7_3
    {
        static void Main()
        {
            int i = 1;
            int sum = 0;
            for (; i < 1001; i++)
            {
                if (i % 21 == 0)
                {
                    sum += i;
                }
            }

            System.Console.WriteLine(sum);

        }
        
  }
}
