using System;
using static System.Console;
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
                int s=0;
                do
                {
                WriteLine("1-ВИКТОРИНА");
                WriteLine("2-РЕДАКЦИЯ");
                WriteLine("Ваш выбор: "); int v = int.Parse(ReadLine());

                    switch (v)
                    {
                        case 1:
                            Menu menu = new Menu();
                            s = 1;
                            break;
                        case 2:
                            QuizCreator creator = new QuizCreator();
                            s = 2;
                            break;
                    }
                    Clear();
                } while (s < 1 || s > 2);
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
    }
}
