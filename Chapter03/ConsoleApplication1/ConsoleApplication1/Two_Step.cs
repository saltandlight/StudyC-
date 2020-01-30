using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Two_Step
    {
        static void Main()
        {
            int sum = 0;
            int k = 0;
            for(int i = 1; i < 1001; i++)
            {
                sum = 0;
                for(int j = 1; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        sum += j;
                    }
                }
                if (sum == i && i!=1) Console.WriteLine(i);
            }
        }
    }
}
