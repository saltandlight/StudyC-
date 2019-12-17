using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    class DataClass
    {
        private int data;
        public DataClass()
        {
            this.data = 0;
        }
        public void PlusData()
        {
            this.data++;
        }
        public void MinusData()
        {
            this.data--;
        }
        public void ShowData()
        {
            Console.WriteLine("Data = {0}", this.data);
        }
        public DataClass getInstance()
        {
            return this;
        }
    }
    
    class thisExam2
    {
        static void Main(string[] args)
        {
            DataClass obj = new DataClass();
            DataClass data = obj.getInstance();
            data.PlusData();
            obj.MinusData();
            data.ShowData();
        }
    }
}
