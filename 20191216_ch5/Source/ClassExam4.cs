using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    class Example
    {
        public readonly int x;
        public const int y = 10;
        public Example(int data)
        {
            x = data;
        }
    }
    class ClassExam4
    {
        static void Main(string[] args)
        {
            Example obj = new Example(20);
            Console.WriteLine("상수 X의 값={0}, Y값={1}", obj.x, Example.y);
        }
    }
}
