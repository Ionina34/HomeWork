using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Exam_2_Quiz
{
    [Serializable]
    public class Score
    {
        public string UserLogin { get; set; }
        public int UserScore { get; set; }
        public string Title { get; set; }
        public Score() { }
        public Score(string userLogin, int score, string title)
        {
            UserLogin = userLogin;
            UserScore = score;
            Title = title;
        }

    }
    [Serializable]
    public class Scores : List<Score>
    {
        public Scores() { }
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
