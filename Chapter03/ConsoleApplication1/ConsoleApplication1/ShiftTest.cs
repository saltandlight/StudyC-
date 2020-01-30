using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class ShiftTest
    {
        static void Main()
        {
            int x = 1, y = -1;
            System.Console.WriteLine(" 시프트 연산 x=1 , y =-1");
            System.Console.WriteLine(" x << 1 = " + (x << 1));
            System.Console.WriteLine(" y << 1 = " + (y << 1));
            System.Console.WriteLine(" x >> 1 = " + (x >> 1)); //한 번 밀고 가우스 연산하는 것과 같음
            System.Console.WriteLine(" y >> 1 = " + (y >> 1));

            DateTime now;
            DateTime? dt = null;

            if (dt != null)
                now = (DateTime)dt;
            else
                now = DateTime.Now;

            now = dt == null ? DateTime.Now : (DateTime)dt;

            now = dt ?? DateTime.Now;

        }
    }
}

