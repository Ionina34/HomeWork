﻿using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Exam_2_Quiz
{
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
            this.Add(new User(login, parol, DateTime.Parse(date)));
            return true;
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
            this.Add(new User(login, user.Password, DateTime.Parse(newDate)));
            this.Remove(user);
        }
        /////////////////////////////////////////////////////////////
        public void WriteUsers(Users users)
        {
            BinaryFormatter bin = new BinaryFormatter();
            using (FileStream fs = new FileStream("Users.bin", FileMode.OpenOrCreate, FileAccess.Write))
                bin.Serialize(fs, users);
        }
        public Users ReadUsers()
        {
            BinaryFormatter bin = new BinaryFormatter();
            Users users = null; ;
            using (FileStream fs = new FileStream("Users.bin", FileMode.Open, FileAccess.Read))
                users = (Users)bin.Deserialize(fs);
            return users;
        }
    }


    [Serializable]
    public class Score
    {
        public string UserLogin { get; set; }
        public int UserScore { get; set; }
        public string Title { get; set; }
        public Score() { }
        public Score(string userLogin, int score,string title)
        {
            UserLogin = userLogin;
            UserScore = score;
            Title = title;
        }

    }
    [Serializable]
    public class Scores : List<Score>
    {
        public Scores() {}
        public bool CheckScoreExists(string login)
        {
            return FindScore(login) != null;
        }
        public Score FindScore(string login)
        {
            return this.FirstOrDefault(s => s.UserLogin == login);
        }
        //////////////////////////////////////////////////////////////////////
        public void WriterScored(Scores scores)
        {
            BinaryFormatter bin = new BinaryFormatter();
            using (FileStream fs = new FileStream("Scores.bin", FileMode.OpenOrCreate, FileAccess.Write))
                bin.Serialize(fs, scores);
        }
        public Scores ReadScores()
        {
            BinaryFormatter bin = new BinaryFormatter();
            Scores scores = null;
            using (FileStream fs = new FileStream("Scores.bin", FileMode.OpenOrCreate, FileAccess.Read))
                if (!(fs.Length == 0))
                    scores = (Scores)bin.Deserialize(fs);
            return scores;
        }
    }
}
