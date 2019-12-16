using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    class Example
    {
        private string text;
        private int data;
        public string Text
        {
            get { return text;  }
            set { text = value; }
        }
        public int Data
        {
            get { return data; }
            set { data = value; }
        }
    }
    class ClassExam5
    {
        static void Main(string[] args)
        {
            Example obj = new Example();
            obj.Text = "안녕하세요!";
            obj.Data = 1000;
            Console.WriteLine("text = {0}, data = {1}", obj.Text, obj.Data);

        }
    }

}
