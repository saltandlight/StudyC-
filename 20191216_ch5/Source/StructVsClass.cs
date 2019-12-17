using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    class ClassData //클래스
    {
        public string data;
    }
    struct StructData //구조체
    {
        public string data;
    }
    class StructVsClass
    {
        static void ClassCopy(ClassData obj)
        {
            obj.data = "변경";
        }
        static void StructCopy(StructData obj)
        {
            obj.data = "변경";
        }

        static void Main()
        {
            ClassData obj_class = new ClassData();
            StructData obj_struct = new StructData();

            obj_class.data = "변경되지 않음";
            obj_struct.data = "변경되지 않음";

            ClassCopy(obj_class); // 메서드에 클래스 개체를 전달
            //ClassData 클래스의 obj 개체 주소 참조해서 해당 개체의 값을 변경함.
            StructCopy(obj_struct); //메서드에 구조체 개체를 전달
            //메서드의 매개변수로 구조체 개체 사용 시 값에 의한 전달 발생
            //매개변수로 전달되는 obj는 메모리 다른 영역을 사용하는 복사본 
               

            System.Console.WriteLine("Class field = {0}", obj_class.data);
            System.Console.WriteLine("Struct field = {0}", obj_struct.data);
        }
    }
}
