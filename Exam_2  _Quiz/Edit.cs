using System;
using System.IO;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Exam_2_Quiz
{
    public class Edit
    {
        public Edit()
        {
            Clear();
            WriteLine("Какую викторину хотите редактировать: ");
            WriteLine("1-Викторину по математике\n2-Смешанную викторину");
            Write("Ваш выбор: "); int v = int.Parse(ReadLine());

            List<Question> q = new List<Question>();
            XmlSerializer xml = new XmlSerializer(typeof(List<Question>));
            q = null;

            string stroka="";
            switch (v)
            {
                case 1:
                    using (Stream stream = File.OpenRead("Математика.xml"))
                        q = (List<Question>)xml.Deserialize(stream);
                    stroka = "Математика.xml";
                    break;
                case 2:
                    using (Stream stream = File.OpenRead("Микс.xml"))
                        q = (List<Question>)xml.Deserialize(stream);
                    stroka = "Микс.xml";
                    break;
                default:
                    WriteLine("Error");
                    break;
            }

            Clear();
            WriteLine("1-Удалить вопрос");
            WriteLine("2-Добавить вопрос");
            Write("Ваш выбор: "); int d = int.Parse(ReadLine());

            Clear();
            switch(d)
            {
                case 1:
                    for (int i=0;i<q.Count;i++)
                    {
                        Question question = q[i];
                        WriteLine($"{i + 1}. {question.Text}");
                    }
                    WriteLine();
                    Write("Выберете вопрос который нужно удалить: ");
                    int choice = int.Parse(ReadLine());
                    Question choisen = q[choice - 1];
                    q.Remove(choisen);
                    WriteLine("Вопрос удален!");
                    ReadKey();
                    WriterQuiz(q,stroka);
                    break;
                case 2:
                    Question newQuestion =Creator.CreateQuestion();
                    WriterQuiz(q,stroka);
                    q.Add(newQuestion);
                    WriteLine("Вопрос добавлен!");
                    ReadKey();
                    WriterQuiz(q,stroka);
                    break;
            }
        }
        public void WriterQuiz(List<Question> questions, string path)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Question>));
            using (Stream stream = File.Create(path))
                xml.Serialize(stream, questions);
        }
    }
}
