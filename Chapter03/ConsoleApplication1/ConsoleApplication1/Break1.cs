using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Break1
    {
        static void Main()
        {
            int sum = 0;
            for(int i=0; i < 100; i++)
            {
                if(i%3 == 0)
                {
                    sum += i;
                    System.Console.Write(i + "\t");
     
                }
                if (sum > 200) break;
            }
            System.Console.WriteLine("Sum = " + sum);
                
        }
    }
}
