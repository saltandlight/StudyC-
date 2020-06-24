using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_ch4
{
    public class TypeTest
    {
        public static void Main(String[] args)
        {
            Object o1 = new object();
            Object o2 = new B();
            Object o3 = new D();
            Object o4 = o3;

            B b1 = new B();
            B b2 = new D();
            D d1 = new D();
            B b3 = new Object() as B;
            D d2 = new Object() as D;

            B b4 = d1;
            D d3 = b2 as D;

            D d4 = (D)d1;
            D d5 = (D)b2;

            D d6 = (D)b1;
            B b5 = (B)o1;

            B b6 = (D)b2;
        }
    }
}
