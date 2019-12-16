using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class MultiArray3
    {
        static void Main()
        {
            int[][] var = new int[3][];
            var[0] = new int[1];
            var[1] = new int[2];
            var[2] = new int[3];

            int i, j, k = 0;
            for (i = 0; i < 3; i++)
                for (j = 0; j < i + 1; j++)
                    var[i][j] = k++;

            for (i = 0; i < 3; i++)
            {
                for (j = 0; j < i+1; j++)
                    System.Console.Write(var[i][j] + "\t");
                System.Console.WriteLine();
            }

        }
    }
}
