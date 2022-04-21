using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_2_Quiz
{
    public class Menu
    {
        public Menu()
        {
            DataUsers users = new DataUsers();
            DataScores scores = new DataScores();
            DataQuiz quiz = new DataQuiz();
            bool Out = true;

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

            do
            {
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
                        WriteLine("1-Викторина по математике\n2-Смешанная викторина");
                        Write("Ваш выбор: ");  v = int.Parse(ReadLine());
                        string title;
                        if (v == 1)
                            title = "Математика";
                        else title = "Микс";
                        Score score = quiz.StartQuiz(title, users.CurUser, v);
                        scores.AddScore(score);
                        break;
                    case 2:
                        scores.ScoreUser(users.CurUser.Login);
                        break;
                    case 3:
                        Clear();
                        WriteLine("1-Топ 20 по математике\n2-Топ 20 по смешанной викторине");
                        Write("Ваш выбор: ");  v = int.Parse(ReadLine());
                        if (v == 1)
                            title = "Математика";
                        else title = "Микс";
                        scores.TopScores(title);
                        break;
                    case 4:
                        Clear();
                        WriteLine("1-Изменить пароль\n2-Изменить день рождения\n");
                        Write("Ваш выбор: "); v = int.Parse(ReadLine());
                        switch (v)
                        {
                            case 1:
                                Clear();
                                users.DisplayChangePassword();
                                break;
                            case 2:
                                Clear();
                                users.DisplayChangeBirth();
                                break;
                        }
                        break;
                    case 5:
                        Out = false;
                        break;
                }
            } while (Out);
        }
    }
}
