using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// XML 주석 예제 프로그램
/// </summary>
namespace ConsoleApplication1
{
    
    class CommentExam3
    {
        /// <remarks>
        /// 프로그램 시작부분
        /// remarks 태그는 애플리케이션 상세
        /// 설명에 사용됨
        /// </remarks>
        static void Main()
        {
            bool A = (3 > 10);
            bool B = (10 > 3);
            Console.WriteLine("A=" + A + " B=" + B);
        }
    }
}
