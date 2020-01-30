using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class MultiArray2
    {
        static void Main()
        {
            int[,] arr = new int[2, 3]; // 선언 및 초기화
            for(int i = 0; i < 2; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    arr[i, j] = i + j;
                }
            }

            for(int i = 0; i < 2; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    System.Console.WriteLine("arr[{0}][{1}]={2}", i, j, arr[i, j]);
                }
            }
        }
    }
}
