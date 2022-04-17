using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_2___Quiz
{
    public enum QuizType
    {
        Math,
        Mixed
    };

    public class Quiz
    {
        public QuizType Type { get; set; }
        public string Heading { get; set; }
        public List<Question> Questions { get; set; }
        public Quiz() { }
        public Quiz(QuizType type,string heading,List<Question> questions)
        {
            Type = type;
            Heading = heading;
            Questions = questions;
        }
    }
    public class Answer
    {
        public string Text { get; set; }
        public bool Right { get; set; }
        public Answer() { }
        public Answer(string text, bool right)
        {
            Text = text;
            Right = right;
        }
    }
    public class Question
    {
        public string Text { get; set; }
        public List<Answer> Answer { get; set; }
        public Question() { }
        public Question(string text,List<Answer> answers)
        {
            Text = text;
            Answer = answers;
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
        public bool SignUp(string login, string parol, DateTime date)
        {
            if (CheckUser(login))
                return false;
            else
            {
                this.Add(new User(login, parol, date));
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
        public void ChangeBirth(string login, DateTime newDate)
        {
            User user = FindUser(login);
            this.Add(new User(login, user.Password, newDate));
            this.Remove(user);
        }
    }

}
