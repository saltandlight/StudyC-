﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class ForExam
    {
        static void Main()
        {
            for (int i = 1, j = 10; (i < 10) && (j >= 1); i++, j--)
            {
                System.Console.WriteLine("{0} \t {1}", i, j);
            }
        }
    }
}
