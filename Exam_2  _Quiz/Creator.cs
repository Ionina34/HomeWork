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
    public class Creator
    {
        public  Creator()
        {
            List<Question> questions = new List<Question>();
            bool Exists = true;
            string oblast;
            do
            {
                Clear();
                Write("Введите область знаний, т.е загаловок: "); oblast = ReadLine();
                oblast = oblast + ".xml";
                if (File.Exists(oblast))
                {
                    Clear();
                    WriteLine("Викторина с таким заголовком уже существует!");
                    WriteLine("Придумайте новый");
                    oblast = ReadLine() + "xml";
                }
                else Exists = false;
            } while (Exists);

            Write("Введите количество вопросов: "); int numQuestion = int.Parse(ReadLine());
            for(int i=0;i<numQuestion;i++)
            {
                Clear();
                Write($"Вопрос №{i + 1}");
                questions.Add(CreateQuestion());
            }
            WriterQuiz(questions,oblast);
        }
        public static Question CreateQuestion()
        {
             WriteLine();
            Write("Введите вопрос: ");
            string text = ReadLine();
            Write("Введите количество ответов: ");
            int numAnswers = int.Parse(Console.ReadLine());

            string[] answer=new string[numAnswers];

            int Correct=0;
            bool isCorrect=false;
            for(int i=0;i<answer.Length;i++)
            {
                Clear();
                WriteLine($"Ответ №{i + 1}");
                Write("Введите ответ: ");
                answer[i] = ReadLine();
                if (isCorrect == false)
                {
                    Write(" Он правильный (y/n)? - ");
                    string ans = ReadLine();
                    if (ans == "y")
                    {
                        Correct = i;
                        isCorrect = true;
                    }
                }
            }
            
            return new Question(text, answer, Correct);
        }
        public void WriterQuiz(List<Question> questions,string path)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Question>));
            using (Stream stream = File.Create(path))
                xml.Serialize(stream, questions);
        }
    }
}
