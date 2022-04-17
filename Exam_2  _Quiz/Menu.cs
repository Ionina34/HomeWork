using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_2___Quiz
{
    class Menu
    {
        public Menu()
        {
            WriteLine("<<<<<<<<<< ВИКТОРИНА >>>>>>>>>>");
            WriteLine("1-Регистрация");
            WriteLine("2-Вход");
            Write("Ваш выбор: ");int v = int.Parse(ReadLine());
            switch (v)
            {
                case 1:
                    break;
                case 2:
                    break;
            }

            Clear();
            WriteLine("Начать новую викторину");
            WriteLine("Посмотреть результаты своих прошлых викторин");
            WriteLine("Посмотреть Топ-20 по конкретной викторине");
            WriteLine("Изменить настройки");
            WriteLine("Выход");v = int.Parse(ReadLine());
            switch(v)
            {
                case 1:
                    Clear();
                    WriteLine("1-Математика");
                    WriteLine("2-Смешаная викторина");
                    Write("Выберите тему викторины: ");
                    int vQuiz = int.Parse(ReadLine());

                    string heading;
                    QuizType type = (QuizType)vQuiz - 1;

                    if (type == QuizType.Mixed)
                        heading = "Смешаная викторина";
                    else
                    {

                    }

                    break;
                case 2:
                    Clear();
                    break;
                case 3:
                    Clear();
                    break;
                case 4:
                    Clear();
                    break;
                case 5:
                    Clear();
                    break;
            }
        }
    }
}
