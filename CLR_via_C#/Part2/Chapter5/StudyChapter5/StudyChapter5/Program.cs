using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyChapter5
{
    class Program
    {
        internal struct Point: IComparable
        {
            private readonly Int32 m_x, m_y;

            //각 필드들을 쉽게 초기화하기 위한 생성자
            public Point(Int32 x, Int32 y)
            {
                m_x = x;
                m_y = y;
            }

            // System.ValueType에 선언된 ToString 메서드를 재정의
            public override string ToString()
            {
                //좌표에 대한 문자열을 반환. 참고: ToString 메서드를 호출하여 박싱을 피할 수 있음.
                return String.Format("({0}, {1})", m_x.ToString(), m_y.ToString());
            }


            //타입 안정성을 추구하는 CompareTo 메서드를 선언함
            public int CompareTo(Point other)
            {
                //피타고라스의 정리를 사용하여 
                //원점 (0,0) 으로부터 얼마나 먼 거리에 있는지 계산함.
                return Math.Sign(Math.Sqrt(m_x * m_x + m_y * m_y)
                    - Math.Sqrt(other.m_x * other.m_x + other.m_y * other.m_y));
            }

            //IComparable 인터페이스의 CompareTo 메서드에 대한 구현
            public int CompareTo(object o)
            {
                if (GetType() != o.GetType())
                {
                    throw new ArgumentException("o는 Point 타입이 아닙니다.");
                }
                // 타입 안정성을 준수하는 CompareTo 메서드를 호출함
                return CompareTo((Point) o);
            }
        }
        static void Main(string[] args)
        {
        }
    }
}
