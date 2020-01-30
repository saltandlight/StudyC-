using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class CastExam
    {
        static void Main()
        {
            byte A;
            int B = 365;
            double C = 1024.512;
            System.Console.WriteLine("축소형 변환 결과");
            A = (byte)B; //byte는 255까지 커버됨 아마 오버플로우가 발생할 듯
            System.Console.WriteLine(" int 형 365를 byte형으로 바꾸면 " + A);
            B = (int)C;
            System.Console.WriteLine(" double 형 1024.512를 int형으로 바꾸면 " + B);
            A = (byte)C;
            System.Console.WriteLine(" double 형 1024.512를 byte형으로 바꾸면 " + A);
        }
    }
}
