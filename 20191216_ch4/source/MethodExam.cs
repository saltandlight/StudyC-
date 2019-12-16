using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    class MethodExam
    {
        static void Main()
        {
            int data;
            data = sample(10);
            System.Console.WriteLine("return data = {0}", data);
        }

        public static int sample(int x)
        {
            return (x * x);
        }
    }

}
