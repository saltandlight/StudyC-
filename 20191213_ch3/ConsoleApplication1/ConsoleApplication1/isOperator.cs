using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class isOperator
    {
        static void Main()
        {
            char data = 'a';
            if (data is char) // data가 char형이면 true를 반환
                System.Console.WriteLine("문자 데이터입니다.");
            else
                System.Console.WriteLine("문자 데이터가 아닙니다.");
        }
    }
}
