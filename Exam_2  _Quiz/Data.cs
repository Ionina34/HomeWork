using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_2_Quiz
{
    public class Data
    {
        public class DataUsers : Users
        {
            public Users users { get; set; }
            public User CurUser { get; set; }

            public DataUsers()
            {
                users = ReadUsers();
            }

            public void DisplaySignUp()
            {
                string login, parol, date = "";
                bool isSignUp = true;

                do
                {
                    Clear();
                    if (!isSignUp)
                    {
                        WriteLine("Пользователь с таким логином уже существует!");
                        WriteLine("Попробуйте снова");
                    }
                    else
                    {
                        Write("Введите дату рождения в формате(yy-mm-dd): ");
                        date = ReadLine();
                    }
                    WriteLine("Придумайте логин и пароль");
                    Write("  Логин: "); login = ReadLine();
                    Write("  Пароль: "); parol = ReadLine();
                    isSignUp = users.SignUp(login, parol, date);

                } while (!isSignUp);
                WriteUsers(users);
                CurUser = users.FindUser(login);
            }
            public void DisplaySignIn()
            {
                string login, parol;
                bool isSignIn = true;

                do
                {
                    Console.Clear();
                    if (!isSignIn)
                    {
                        WriteLine("Неверный логин или пароль!");
                        WriteLine("Попробуйте снова");
                    }
                    WriteLine("Введите логин и пароль для входа");
                    Write("  Логин: "); login = ReadLine();
                    Write("  Пароль: "); parol = ReadLine();
                    isSignIn = users.SignIn(login, parol);

                } while (!isSignIn);
                CurUser = users.FindUser(login);
            }
            public void DisplayChangeBirth()
            {
                string newDate;
                WriteLine($"Текущая дата рождения: {CurUser.BirthDate.ToShortDateString()}");
                Write("  Введите новую дату рождения в формате(yy-mm-dd): ");
                newDate = ReadLine();
                users.ChangeBirth(CurUser.Login, newDate);
                WriteUsers(users);
                CurUser = users.FindUser(CurUser.Login);
            }
            public void DisplayChangePassword()
            {
                string newParol, parol;
                bool parolCorrect = true;

                do
                {
                    if (!parolCorrect)
                    {
                        WriteLine("Неверный пароль!");
                        WriteLine("Попробуйте снова");
                    }
                    Write("  Введите ваш старый пароль: ");
                    parol = ReadLine();
                    parolCorrect = users.CheckPassword(CurUser.Login, parol);
                } while (!parolCorrect);

                Write("  Введите новый пароль: ");
                newParol = ReadLine();
                users.ChangePassword(CurUser.Login, newParol);
                WriteUsers(users);
                CurUser = users.FindUser(CurUser.Login);
            }
        }
        public class DataScores:DataUsers
        {

        }
    }
}
