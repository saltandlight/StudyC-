using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyChapter5
{
    internal struct Point: IComparable
    {
        private readonly Int32 m_x, m_y;

        // 각 필드들을 손쉽게 초기화하기 위한 생성자
        public Point(Int32 x, Int32 y)
        {
            m_x = x;
            m_y = y;
        }

        // System.ValueType에 선언된 ToString 메서드를 재정의
        public override string ToString()
        {
            // 좌표에 대한 문자열을 반환한다. 참고: ToString 메서드를 호출하여 박싱 피할 수 있음
            return String.Format("({0}, {1})", m_x.ToString(), m_y.ToString());
        }

        // 타입 안정성을 준수하는 CompareTo 메서드를 선언한다. 
        public int CompareTo(Point other)
        {
            // 피타고라스의 정리를 사용하여
            // 원점으로부터 얼마나 먼 거리에 있는지 계산한다.
            return Math.Sign(Math.Sqrt(m_x * m_x + m_y * m_y)
                - Math.Sqrt(other.m_x * other.m_x + other.m_y * other.m_y));
        }

        // IComparable 인터페이스와 CompareTo 메서드에 대한 구현이다.
        public Int32 CompareTo(object o)
        {
            if (GetType() != o.GetType())
            {
                throw new ArgumentException("o는 Point 타입이 아닙니다.");
            }
            // 타입 안정성을 준수하는 CompareTo 메서드를 호출한다.
            return CompareTo((Point)o);
        }
    }
    public static class Program2
    {
        public static void Main()
        {
            // 스택에 두 개의 Point 타입의 인스턴스를 생성한다.
            Point p1 = new Point(10, 10);
            Point p2 = new Point(20, 20);

            // p1은 가상 메서드 ToString를 호출하면서 박싱되지 않음
            Console.WriteLine(p1.ToString()); // "(10, 10)"

            // p1은 비가상 메서드 GetType을 호출하면서 박싱된다.
            Console.WriteLine(p1.GetType()); // "Point"

            // p1은  CompareTo 메서드를 호출하면서 박싱되지 않는다.
            // p2는 CompareTo(Point) 메서드를 호출하면서 박싱되지 않는다.
            Console.WriteLine(p1.CompareTo(p2)); //"-1"

            //p1은 CompareTo 메서드를 호출하면서 

        }
    }
}
