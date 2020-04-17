using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    class ClassExam
    {
        public ClassExam()
        {
            Console.WriteLine("생성자");
        }
        ~ClassExam()
        {
            Console.WriteLine("소멸자");
        }
        public void Display()
        {
            Console.WriteLine("멤버 메서드 호출");
        }
    }
    class ClassExam3
    {
       
        static void Main()
        {
            ClassExam obj = new ClassExam();
            obj.Display();
        }
    }
}
