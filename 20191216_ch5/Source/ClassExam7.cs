using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    class Class1
    {
        public int i = 0;
        private int j = 1;
        protected int k = 2; //상속에서 private처럼 작동
    }

    class Class2: Class1 //Class1을 상속받은 Class2
    {
        void Display()
        {
            Console.WriteLine("i + k = {0}", i + k);
            // Console.WriteLine(" j = {0}", j);
            // 오류 CS0122  보호 수준 때문에 'Class1.j'에 액세스할 수 없습니다.	

        }
    }
    class ClassExam7
    {
        static void Main(string[] args)
        {
            Class1 obj1 = new Class1();
            Console.WriteLine("Class1.i = {0}", obj1.i);
            //  Console.WriteLine("Class1.j = {0}", obj1.j);
            //  Console.WriteLine("Class1.k = {0}", obj1.k);
            // protected 멤버는 클래스 내부, 또는 파생 클래스에서만 사용 가능

            Class2 obj2 = new Class2();
            //obj2.Display();

            OutClass obj3 = new OutClass();
            obj3.i = 1000;
            Console.WriteLine("OutClass.i = {0}", obj3.i);
        }
    }
}
