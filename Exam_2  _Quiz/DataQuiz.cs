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
    public class DataQuiz : DataScores
    {
        public Score StartQuiz(string title, User curUser, int v)
        {
            Random rand = new Random();

            List<Question> q = new List<Question>();
            switch (v)
            {
                case 1:
                    XmlSerializer xml = new XmlSerializer(typeof(List<Question>));
                    q = null;
                    using (Stream stream = File.OpenRead("Математика.xml"))
                        q = (List<Question>)xml.Deserialize(stream);
                    break;
                case 2:
                    XmlSerializer xml1 = new XmlSerializer(typeof(List<Question>));
                    q = null;
                    using (Stream stream = File.OpenRead("Микс.xml"))
                        q = (List<Question>)xml1.Deserialize(stream);
                    break;
                default:
                    WriteLine("Error");
                    break;
            }

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
                // WriteLine("Верный ответ!");
                //else
                // WriteLine($"Неверно! Правильный ответ: {answer.Answer[answer.correct_answer]}");
                q.Remove(answer);
                WriteLine();
            }
            WriteLine("Окончание викторины!");
            WriteLine($"Ваш результат: {res} правильных ответов из {count}");
            ReadKey();

            return new Score(curUser.Login, res, title);

        }
        private static string WriteAndGetAnswer(Question q)
        {
            Random rand = new Random();
            List<string> s = new List<string>(q.Answer);
            int len = s.Count + 1;
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
        public Question() { }
        public Question(string text, string[] answer, int correct)
        {
            this.Text = text;
            this.Answer = answer;
            this.correct_answer = correct;
        }

    }
    public class TestMath
    {
        public TestMath() { }
        public TestMath(List<Question> q)
        {
            q.Add(new Question("Бессектриса это...", new string[] { "Крыса", "Мышь", "Конь", "Жираф" }, 0));
            q.Add(new Question("2+2*2 = ", new string[] { "8", "4", "6" }, 2));
            q.Add(new Question("Теорема Пифагора: ", new string[] { "a^2=b^2+c^2", "c^2=a^2+b^2", "c^2=a^2-b^2" }, 1));
            q.Add(new Question("f(x) = x^2 это ", new string[] { "Прямая", "Гипербола", "Кривая", "Парабола" }, 3));
            q.Add(new Question("Площадь квадрата 49 см^2. Чему равен его периметр", new string[] { "28", "46", "26", "30" }, 0));
            q.Add(new Question("Треугольник со сторонами 3, 4, 5.", new string[] { "Парижский", "Равнобедренный", "Еврейский", "Египетский" }, 3));
            q.Add(new Question("Место, занимаемое цифрой и записи числа ", new string[] { "Место", "Разряд", "Номер" }, 1));
            q.Add(new Question("Сколько цифр «9» в ряду чисел от 1 до 100?", new string[] { "15", "25", "20", "21" }, 2));
            q.Add(new Question("Назовите 13 книгу Евклида по геометрии", new string[] { "Начала", "Начало мира", "Все и про все", "Начало начал" }, 0));
            q.Add(new Question("Сумма углов треугольника?", new string[] { "180", "220 ", "360", "150" }, 0));

            //XmlSerializer xml = new XmlSerializer(typeof(List<Question>));
            //using (Stream stream = File.Create("Математика.xml"))
            //    xml.Serialize(stream, q);
        }
    }
    public class TestMixed
    {
        public TestMixed(List<Question> q)
        {
            q.Add(new Question("Какой стране принадлежит остров Таити?", new string[] { "Португалия", "Испания", "Италия", "Франция" }, 3));
            q.Add(new Question("Какая нота первой октавы пишется на первой линейке нотного стана?", new string[] { "До", "Ре", "Ми", "Фа" }, 2));
            q.Add(new Question("Кто из этих российских императоров и императриц правил раньше остальных?", new string[] { "Елизавета Петровна", "Анна Иоанновна", "Екатерина II", "Петр III" }, 1));
            q.Add(new Question("Где муха-цокотуха нашла денежку?", new string[] { "На лугу", "В лесу", "В поле", "Во дворе" }, 2));
            q.Add(new Question("Какой географический объект носит загадочное название Титикака?", new string[] { "Остров", "Озеро", "Вулкан", "Река" }, 1));
            q.Add(new Question("Из какого литературного произведения цитата: «Что пользы человеку приобрести весь мир, если он теряет собственную душу.»?", new string[] { "Портрет Дориана Грея", "Мёртвые души", "Анна Каренина" }, 0));
            q.Add(new Question("Сколько корней имеет математическое уравнение, если дискриминант больше нуля?", new string[] { "Один", "Три", "Два", "Ноль" }, 2));
            q.Add(new Question("В каких единицах согласно системе СИ измеряется давление?", new string[] { "Паскаль", "Джоуль", "Кулон", "Вольт" }, 0));
            q.Add(new Question("При помощи каких образований передвигается инфузория - туфелька?", new string[] { "Ложноножек", "Ресничек", "Жгутиков" }, 1));
            q.Add(new Question("Кто из учёных открыл физический закон сохранения импульса?", new string[] { "Рене Декарт", "Исаак Ньютон", "Альберт Эйнштейн" }, 0));

            //XmlSerializer xml = new XmlSerializer(typeof(List<Question>));
            //using (Stream stream = File.Create("Микс.xml"))
            //    xml.Serialize(stream, q);
        }
    }
}

