using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_2_Quiz
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Menu menu = new Menu();
            }catch(Exception e) { Console.WriteLine(e.Message); }
        }
    }
}
