using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections;

namespace ConsoleApplication1
{
    class ForEachTest
    {
        static void Main()
        {
            int[] count = new int[] { 0, 1, 2, 3, 5, 8, 13 };
            string[] str = { "월", "화", "수", "목", "금", "토", "일" };

            ArrayList arr = new ArrayList();
            arr.Add("한국");    arr.Add("미국");
            arr.Add("중국");    arr.Add("영국");
            arr.Add("일본");

            foreach(int i in count)
            {
                Console.WriteLine(i);
            }

            foreach(String yoil in str)
            {
                Console.Write(yoil + "\t");
            }
            Console.WriteLine();
            foreach(string item in arr)
            {
                Console.WriteLine(item);
            }
        }
    }
}
