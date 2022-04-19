using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_2___Quiz
{
    public class Quiz
    {
        public Quiz()
        {
            WriteLine("1-Викторина по математике\n2-Смешанная викторина");
            Random rand = new Random();
            List<Question> q = new List<Question>();
            q.Add(new Question("Гепотинуза это...", new string[] { "Крыса", "Мышь", "Конь", "Жираф" }, 0));
            q.Add(new Question("2+2*2 = ", new string[] { "8", "4", "6" }, 2));
            q.Add(new Question("Теорема Пифагора: ", new string[] { "a^2=b^2+c^2", "c^2=a^2+b^2", "c^2=a^2-b^2" }, 1));
            q.Add(new Question("f(x) = x^2 это ", new string[] { "Прямая", "Гипербола", "Кривая", "Парабола" }, 3));
            q.Add(new Question("Площадь квадрата 49 см^2. Чему равен его периметр", new string[] { "28", "46", "26", "30" }, 0));
            q.Add(new Question("Треугольник со сторонами 3, 4, 5.", new string[] { "Парижский", "Равнобедренный", "Еврейский", "Египетский" }, 3));
            q.Add(new Question("Место, занимаемое цифрой и записи числа ", new string[] { "Место", "Разряд", "Номер" },1 ));
            q.Add(new Question("Сколько цифр «9» в ряду чисел от 1 до 100?", new string[] { "15", "25", "20","21" },2 ));
            q.Add(new Question("Назовите 13 книгу Евклида по геометрии", new string[] { "Начала", "Начало мира", "Все и про все","Начало начал" },0 ));
            q.Add(new Question("Сумма углов треугольника = …?", new string[] { "180", "220 ", "360","150" },2 ));
          
            int res = 0;
            int count = q.Count;
            while (q.Count > 0)
            {
                Question answer = q[rand.Next(0, q.Count)];
                WriteLine(answer.Text);
                string input = WriteAndGetAnswer(answer);
                if (input.ToUpper() == "Q")
                    break;
                if (input == answer.correct_answer.ToString())
                    res++;
                    //WriteLine("Верный ответ!");
                //else
                //    WriteLine($"Неверно! Правильный ответ: {answer.Answer[answer.correct_answer]}");
                q.Remove(answer);
                WriteLine();
            }
            WriteLine("Окончание викторины!");
            WriteLine($"Ваш результат: {res} правильных ответов из {count}");
            ReadKey();
        }
        private static string WriteAndGetAnswer(Question q)
        {
            Random rand = new Random();
            List<string> s = new List<string>(q.Answer);
            int len = s.Count+1;
            int new_correct = 0;
            for (int i = 1; i < len; i++)
            {
                string str = s[rand.Next(0, s.Count)];
                if (str == q.Answer[q.correct_answer])
                    new_correct = i;
                WriteLine($"{i}.{str}");
                s.Remove(str);
            }
            Write("Введите номер ответа: ");
            string input = ReadLine();
            if (new_correct.ToString() == input)
                return q.correct_answer.ToString();
            else return input;
        }
    }
    public class Question
    {
        public string Text { get; set; }
        public string[] Answer { get; set; }
        public int correct_answer;
        public Question(string text, string[] answer, int correct)
        {
            this.Text = text;
            this.Answer = answer;
            this.correct_answer = correct;
        }
    }

    [Serializable]
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }

        public User() { }
        public User(string login, string parol, DateTime date)
        {
            Login = login;
            Password = parol;
            BirthDate = date;
        }
    }

    [Serializable]
    public class Users : List<User>
    {
        public bool CheckPassword(string login, string parol)
        {
            return FindUser(login).Password == parol;
        }
        private bool CheckUser(string login)//Сущ-ет ли такой пользователь
        {
            return FindUser(login) != null;
        }
        public User FindUser(string login)
        {
            return this.FirstOrDefault(s => s.Login == login);
        }
        public bool SignUp(string login, string parol, string date)
        {
            if (CheckUser(login))
                return false;
            else
            {
                this.Add(new User(login, parol,DateTime.Parse( date)));
                return true;
            }
        }
        public bool SignIn(string login, string parol)
        {
            User user = FindUser(login);
            if (!CheckUser(login))
                return false;
            return user.Password == parol;
        }
        public void ChangePassword(string login, string newParol)
        {
            User user = FindUser(login);
            this.Add(new User(login, newParol, user.BirthDate));
            this.Remove(user);
        }
        public void ChangeBirth(string login, string newDate)
        {
            User user = FindUser(login);
            this.Add(new User(login, user.Password, newDate));
            this.Remove(user);
        }
    }


    [Serializable]
    public class Score
    {
        public string UserLogin { get; set; }
        public Score() { }
    }

    [Serializable]
    public class Scores:List<Score>
    {
        public Scores() { }
        public bool CheckScoreExists(string login)
        {
            return FindScore(login) != null;
        }
        public Score FindScore(string login)
        {
            return this.FirstOrDefault(s => s.UserLogin == login);
        }
    }
}
