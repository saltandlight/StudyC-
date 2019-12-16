using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    class ParamExam
    {
        static void Main()
        {
            Month(31, 28, 31, 30, 31, 31, 30, 31, 30, 31);
        }
        public static void Month(params int[] args)
        {
            for(int i = 0; i < args.Length; i++)
            {
                Console.WriteLine("{0}월 = {1}일", i + 1, args[i]);
            }
        }
    }
}
