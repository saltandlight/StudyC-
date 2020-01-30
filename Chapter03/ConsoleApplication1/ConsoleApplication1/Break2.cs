using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Break2
    {
        static void Main()
        {
            int grade = 100;
            System.Console.WriteLine("문장1");
            switch (grade)
            {
                case 100:
                    System.Console.WriteLine("문장2");
                    break;
                case 200:
                    System.Console.WriteLine("문장3");
                    break;
            }
            System.Console.WriteLine("문장4");
        }
    }
}
