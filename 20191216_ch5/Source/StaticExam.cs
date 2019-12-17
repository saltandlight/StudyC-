using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    class Example
    {
        public static int i = 10;
        public static void Show()
        {
            Console.WriteLine("Show는 정적 메서드입니다.");
        }
    }
    class StaticExam
    {
        static void Main(string[] args)
        {
            // 인스턴스 없이 직접 사용함.
            Console.WriteLine("Example.i = {0}", Example.i);
            Example.Show();
        }
    }
}
