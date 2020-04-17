using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    class CallbyReference
    {
        static void Main()
        {
            int x, y;
            x = 5;
            y = 10;
            Console.WriteLine("Main1(x, y)값=({0},{1})", x, y);
            Swap1(ref x, ref y);
            Console.WriteLine("Main2(x, y)값=({0},{1})", x, y);
            Swap2(out x, out y);
            Console.WriteLine("Main3(x, y)값=({0},{1})", x, y);
            
        }

        public static void Swap1(ref int x, ref int y)
        {
            //이 함수를 호출 전에 초기화하므로 함수 부분에는 초기화 부분이 없다. 
            int temp = x;
            x = y;
            y = temp;
            Console.WriteLine("ref Swap(x, y) 값=({0},{1})", x, y);
        }
        public static void Swap2(out int x, out int y)
        {
            //out 형식이므로 여기서 x, y의 값을 할당
            x = 100;
            y = 200;
            Console.WriteLine("out Swap(x, y) 값=({0},{1})", x, y);

        }
    }
}
