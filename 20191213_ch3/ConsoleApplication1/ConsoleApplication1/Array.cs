using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Array
    {
        static void Main()
        {
            int sum = 0;
            int[] month;         //정수형 배열 선언
            month = new int[12]; //메모리에 12개의 int 변수를 연속으로 할당

            month[0] = 31;
            month[1] = 28;
            month[2] = 31;
            month[3] = 30;
            month[4] = 31;
            month[5] = 30;
            month[6] = 31;
            month[7] = 31;
            month[8] = 30;
            month[9] = 31;
            month[10] = 30;
            month[11] = 31;

            for(int i = 0; i < 12; i++)
            {
                sum += month[i];
            }

            System.Console.WriteLine("모든 달의 합은 " + sum);
        }
    }
}
