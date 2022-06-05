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

            int v;
            bool Exit = true;
            bool In = true;
            do
            {
                try
                {
                    Clear();
                    WriteLine("<<<<<<<<<< ВИКТОРИНА >>>>>>>>>>");
                    WriteLine("1-Регистрация");
                    WriteLine("2-Вход");
                    WriteLine("3-Выход");
                    Write("Ваш выбор: "); v = int.Parse(ReadLine());
                    switch (v)
                    {
                        case 1:
                            users.DisplaySignUp();
                            In = false;
                            break;
                        case 2:
                            users.DisplaySignIn();
                            In = false;
                            break;
                        case 3:
                            Exit = false;
                            break;
                        default:
                            Clear();
                            WriteLine("Error");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Clear();
                    WriteLine(e.Message);
                    WriteLine("Продалжить (y/n)? - ");
                    string answer = ReadLine();
                    bool z = answer=="n"? Exit = false : Exit = true;
                }
            } while (!(Exit || In));

            bool Out = true;
            if (In == false)
                do
                {
                    try
                    {
                        Clear();
                        WriteLine("1-Начать новую викторину");
                        WriteLine("2-Посмотреть результаты своих прошлых викторин");
                        WriteLine("3-Посмотреть Топ-20 по конкретной викторине");
                        WriteLine("4-Изменить настройки");
                        WriteLine("5-Выход");
                        Write("Ваш выбор: "); v = int.Parse(ReadLine());
                        switch (v)
                        {
                            case 1:
                                Clear();
                                WriteLine("1-Викторина по математике\n2-Смешанная викторина");
                                Write("Ваш выбор: "); v = int.Parse(ReadLine());
                                string title;
                                if (v == 1)
                                    title = "Математика";
                                else title = "Микс";
                                Score score = quiz.StartQuiz(title, users.CurUser, v);
                                scores.AddScore(score);
                                break;
                            case 2:
                                Clear();
                                scores.ScoreUser(users.CurUser.Login);
                                break;
                            case 3:
                                Clear();
                                WriteLine("1-Топ 20 по математике\n2-Топ 20 по смешанной викторине");
                                Write("Ваш выбор: "); v = int.Parse(ReadLine());
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
                    }
                    catch (Exception e) { Clear(); WriteLine(e.Message); }
                } while (Out);
        }
    }
}
