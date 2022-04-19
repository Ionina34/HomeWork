using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_2___Quiz
{
    class Menu: Data
    {
        public Menu()
        {
            DataUsers users = new DataUsers();

            WriteLine("<<<<<<<<<< ВИКТОРИНА >>>>>>>>>>");
            WriteLine("1-Регистрация");
            WriteLine("2-Вход");
            Write("Ваш выбор: "); int v = int.Parse(ReadLine());
            switch (v)
            {
                case 1:
                   users.DisplaySignUp();
                    break;
                case 2:
                    users.DisplaySignIn();
                    break;
            }

            Clear();
            WriteLine("1-Начать новую викторину");
            WriteLine("2-Посмотреть результаты своих прошлых викторин");
            WriteLine("3-Посмотреть Топ-20 по конкретной викторине");
            WriteLine("4-Изменить настройки");
            WriteLine("5-Выход"); v = int.Parse(ReadLine());
            switch (v)
            {
                case 1:
                    Clear();
                    Quiz quiz = new Quiz();
                    break;
                case 2:
                    Clear();

                    break;
                case 3:
                    Clear();

                    break;
                case 4:
                    Clear();
                    WriteLine("Изменить пароль\nИзменить день рождение\n");
                    Write("Ваш выбор: ");v = int.Parse(ReadLine());
                    switch(v)
                    {
                        case 1:
                            Clear();

                            break;
                        case 2:

                            break;
                    }
                    break;
                case 5:
                    Clear();

                    break;
            }
        }
    }
}
