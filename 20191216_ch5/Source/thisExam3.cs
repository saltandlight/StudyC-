using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    class Construct
    {
        public Construct(): this("Hello")
        {
            Console.WriteLine("매개변수 없는 생성자");
        }
        public Construct(string str): this(str, "World")
        {
            Console.WriteLine("매개변수가 하나인 생성자");
        }
        public Construct(string str1, string str2)
        {
            Console.WriteLine("매개변수가 두 개인 생성자");
            Console.WriteLine("==> {0} {1} ==>", str1, str2);
        }

    }
    class thisExam3
    {
        static void Main(string[] args)
        {
            Construct obj1 = new Construct();
            Console.WriteLine("===================================");
            Construct obj2 = new Construct("New");
            Console.WriteLine("===================================");
            Construct obj3 = new Construct("Korea", "Fighting");
        }
    }
}
