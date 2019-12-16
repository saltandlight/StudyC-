using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class IfelseIf
    {
        static void Main()
        {
            int grade = 85;

            if (grade > 90)
                Console.WriteLine("성적은 A입니다.");
            else if (grade > 80)
                Console.WriteLine("성적은 B입니다.");
            else if (grade > 70)
                Console.WriteLine("성적은 C입니다.");
            else if (grade > 60)
                Console.WriteLine("성적은 D입니다.");
            else
                Console.WriteLine("성적은 F입니다.");
        }
    }
}
