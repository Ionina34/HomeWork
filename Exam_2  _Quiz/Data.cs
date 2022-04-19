using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Exam_2___Quiz
{

    class Data 
    {
       public class DataUsers : Users
        {
            public Users Users { get; set; }
            public User CurUser { get; set; }

            public void WriteUsers(Users users)
            {
                BinaryFormatter bin = new BinaryFormatter();
                using (FileStream fs = new FileStream("Users.bin", FileMode.OpenOrCreate, FileAccess.Write))
                    bin.Serialize(fs, users);
            }
            public Users ReadUsers()
            {
                BinaryFormatter bin = new BinaryFormatter();
                Users users = null;
                using (FileStream fs = new FileStream("Users.bin", FileMode.Create, FileAccess.Read))
                    users = (Users)bin.Deserialize(fs);
                return users;
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
                    isSignUp = SignUp(login, parol, date);

                } while (!isSignUp);
                WriteUsers(Users);
                CurUser = FindUser(login);
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
                        WriteLine("Неверный логин или пароль!");
                    }
                    WriteLine("Введите логин и пароль для входа");
                    Write("  Логин: "); login = ReadLine();
                    Write("  Пароль: "); parol = ReadLine();
                    isSignIn = SignIn(login, parol);

                } while (!isSignIn);
                CurUser = FindUser(login);
            }
            public void DisplayChangeBerth()
            {
                string newDate;
                WriteLine($"Текущая дата рождения: {CurUser.BirthDate.ToShortDateString()}");
                Write("  Введите новую дату рождения в формате(yy-mm-dd): ");
                newDate = ReadLine();
                ChangeBirth(CurUser.Login, newDate);
                WriteUsers(Users);
                CurUser = FindUser(CurUser.Login);
            }
            public void DisplayChangePassword()
            {
                string newParol, parol;

            }
        }

    }
}
