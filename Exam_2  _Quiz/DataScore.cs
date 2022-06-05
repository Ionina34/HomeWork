using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_2_Quiz
{ 
    public class DataScores : Scores
    {
        public Scores scores { get; set; }
        public DataScores()
        {
            scores = ReadScores();
        }
        public void ScoreUser(string login)
        {
            List<Score> s = GetScoreUser(login);
            if (s.Count == 0)
                WriteLine("Нет результатов!");
            else
            {
                foreach (var score in s)
                    WriteLine($"{score.Title} - {score.UserScore}");
            }
            ReadKey();
        }
        public List<Score> GetScoreUser(string login)
        {
            return scores.FindAll(s => s.UserLogin == login);
        }
        public void TopScores(string title)
        {
            List<Score> top = GetTop(title);
            if (top.Count == 0)
                WriteLine("Нет результатов по данной векторине!");
            else
            {
                for (int i = 0; i < top.Count; i++)
                {
                    Score score = top[i];
                    WriteLine($"{i + 1}. {score.UserLogin} - {score.UserScore}");
                }
            }
            ReadKey();
        }
        public List<Score> GetTop(string title)
        {
            List<Score> quiz = scores.FindAll(s => s.Title == title);
            return quiz;
        }
        public void AddScore(Score score)
        {
            scores.Add(score);
            WriterScored(scores);
        }
    }
}
