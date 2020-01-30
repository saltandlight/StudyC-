using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    class DateInfo : IDisposable
    {
        public int year, month, day;
        public void Display()
        {
            Console.WriteLine("{0}/{1}/{2}", year, month, day);
        }
       
        public void Dispose()
        {// 해당 클래스의 인스턴스가 메모리에서 제거되기 직전에 호출됨

            Console.WriteLine("Dispose 메서드 실행");
        }
    }
    class usingExam
    {
        static void Main(string[] args)
        {
            using (DateInfo obj = new DateInfo())
            {
                obj.year = 2007;
                obj.month = 12;
                obj.day = 25;
                obj.Display();
            }//Dispose 메서드 호출되면서 obj 인스턴스 소멸
            Console.WriteLine("using 문 종료");
        }
    }
}
