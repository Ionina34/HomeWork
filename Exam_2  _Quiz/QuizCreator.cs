using System;
using System.IO;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_2_Quiz
{
    public class QuizCreator
    {
        public QuizCreator()
        {
            DataUsers users = new DataUsers();
            bool Exit = true;

            Clear();
            ForegroundColor = ConsoleColor.Green;
            WriteLine("Добро пожаловать в приложения для редактирования викторин!");
            WriteLine("Для начала войдите в аккаунт");
            ResetColor();
            ReadKey();

            users.DisplaySignIn();

            do
            {
                try
                {
                    Clear();
                    WriteLine("1-Создать новую викторину");
                    WriteLine("2-Редактировать викторину");
                    WriteLine("3-Удалить викторину");
                    WriteLine("4-Выход");
                    Write("Ваш выбор: "); int v = Int32.Parse(ReadLine());

                    switch (v)
                    {
                        case 1:
                            Creator creator = new Creator();
                            break;
                        case 2:
                            Edit edit = new Edit();
                            break;
                        case 3:
                            Clear();
                            WriteLine("Какую викторину хотите удалить: ");
                            WriteLine("1-Викторину по математике\n2-Смешанную викторину");
                            Write("Ваш выбор: "); int removes = int.Parse(ReadLine());

                            string stroka = "";
                            switch (removes)
                            {
                                case 1:
                                    stroka = "Математика.xml";
                                    break;
                                case 2:
                                    stroka = "Микс.xml";
                                    break;
                                default:
                                    WriteLine("Error");
                                    break;
                            }
                            File.Delete(stroka);
                            WriteLine($"Викторина успешно удалена!");
                            break;
                        case 4:
                            Exit = false;
                            break;
                    }
                }
                catch (Exception e)
                {
                    Clear(); WriteLine(e.Message);
                    WriteLine("Продoлжить (y/n)? - ");
                    string answer = ReadLine();
                    bool z = answer == "n" ? Exit = false : Exit = true;
                }
            } while (Exit);
        }
    }
}
