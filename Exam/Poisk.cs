using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    class Poisk : Method
    {
        public void Look(string files, Dictionary<string, List<string>> dict)
        {
            Write("1-Поиск слова по переводу\n2-Поиск перевода по слову\nВаш выбор: ");
            int n = int.Parse(ReadLine());

            Clear();
            Write("Введите слово для поиска: ");
            string per = ReadLine().ToLower();

            switch (n)
            {
                case 1:
                    List<string> p = new List<string>();
                    bool flag = false;

                    foreach (var i in dict.Keys)
                    {
                        p = dict[i];
                        foreach (string j in p)
                            if (j == per)
                            {
                                WriteLine($"{per} это перевод слова {Format(i)}");
                                flag = true;
                            }
                    }
                    if (flag == false)
                        WriteLine("Совпадений не найдено");
                    ReadKey();
                    break;
                case 2:
                    bool is_per = false;
                    foreach (var i in dict.Keys)
                    {
                        if (i.ToLower() == per)
                        {
                            WriteLine($"{Format(i)} - {String.Join(", ", dict[i])}");
                            is_per = true;
                        }
                    }
                    if (is_per == false)
                        WriteLine("Совпадений не найдено");
                    ReadKey();
                    break;
            }


        }
    }
}
