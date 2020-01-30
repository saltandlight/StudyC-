using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    class Example
    {
        public Example()
        {
            Console.WriteLine("생성자 1");
        }
        public Example(int data)
        {
            Console.WriteLine("생성자 2 : " + data);
        }
        public Example(string str)
        {
            Console.WriteLine("생성자 3 : " + str);
        }
        public Example(double a, float b)
        {
            Console.WriteLine("생성자 4 : " + (a + b));
        }
    }
    class ClassExam2
    {
        
        static void Main(string[] args)
        {
            Example obj1 = new Example();
            Example obj2 = new Example(10);
            Example obj3 = new Example("안녕하세요");
            Example obj4 = new Example(10.5, 10.5f);
        }
    }
}
