using System;
using static System.Console;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    interface IDictionary
    {
        string Name { get; }
    }
    class Dictionary : Method, IDictionary
    {
        Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
        string Name { get; set; }
        string IDictionary.Name => Name;
        public Dictionary(string name)
        {
            Name = name;
        }
        public void Add()
        {
            Write("Введите слово оригинал: "); string orig = ReadLine().ToLower();

            WriteLine("Введите перевод слова: ");
            List<string> per = new List<string>();
            ConsoleKeyInfo btn;
            int i = 1;
            WriteLine("Kак только введете все варианты перевода нажмите Escape");
            do
            {
                Write($"Введите {i} перевод слова {Format(orig)}: ");
                string pere = ReadLine();
                i++;
                per.Add(pere);
                btn = ReadKey();
            } while (btn.Key != ConsoleKey.Escape);

            dict.Add(orig, per);
        }
        public void Replacement()
        {
            Write("1 - Замена слова\n2 - Замена перевода\nВы выбрали: ");
            int k = int.Parse(ReadLine());
            switch (k)
            {
                case 1:
                    Write("Введите слово, каторое вы хотите заменить: ");
                    string slovo = ReadLine().ToLower();
                    Write("Введите слово для замены: "); string newslovo = ReadLine().ToLower();
                    List<string> per = new List<string>();

                    string remove = "";
                    bool flag = false;

                    foreach (var j in dict)
                    {
                        if (slovo == j.Key.ToLower())
                        {
                            per = j.Value;
                            remove = j.Key;
                            flag = true;
                            break;
                        }
                    }
                    dict.Remove(remove);
                    if (flag == true)
                        dict.Add(newslovo, per);
                    else WriteLine("Совпадений не найдено");

                    break;
                case 2:
                    Write("Перевод какого слова хотите поменять: ");
                    string slov = ReadLine();

                    if (dict.ContainsKey(slov))
                    {
                        Write("Введите новый перевод: ");

                        List<string> newper = new List<string>();
                        ConsoleKeyInfo btn;
                        int i = 1;
                        WriteLine("Kак только введете все варианты перевода нажмите Escape");
                        do
                        {
                            Write($"Введите {i} перевод слова {slov}: ");
                            string pere = ReadLine();
                            i++;
                            newper.Add(pere);
                            btn = ReadKey();
                        } while (btn.Key != ConsoleKey.Escape);

                        dict[slov] = newper;
                    }
                    else WriteLine("Совпадений не найдено");
                    break;
                default:
                    WriteLine("Error");
                    break;
            }
        }
        public void Remove()
        {
            Write("1-Удалить слово\n2-Удалить перевод\nВы пыбрали: ");
            int k = int.Parse(ReadLine());
            bool flag = false;
            switch (k)
            {
                case 1:
                    Write("Какое слово хотите удалить: ");
                    string slo = ReadLine().ToLower();
                    string remove = "";

                    foreach (var i in dict.Keys)
                        if (i == slo)
                        {
                            remove = i;
                            flag = true;
                        }
                    if (flag == false)
                        WriteLine("Совпадений не найдено");

                    dict.Remove(remove);
                    break;
                case 2:
                    Write("Перевод какого слова хотите удалить: ");
                    string slovo = ReadLine().ToLower();

                    foreach (var i in dict.Keys)
                        if (i == slovo)
                            if (dict[i].Count == 1)
                                WriteLine($"Это единственный перевод слова {Format(slovo)}");
                            else
                            {
                                Write("Какую вариацию перевода хотите удалить: ");
                                string perRemove = ReadLine().ToLower();
                                List<string> per = dict[i];
                                int index = 0;

                                for (int p = 0; p < per.Count; p++)
                                {
                                    if (per[p] != perRemove)
                                        index++;
                                    else break;
                                }

                                WriteLine(index);
                                per.RemoveAt(index);
                            }
                        else WriteLine("Совпадений не найдено");
                    break;
                default:
                    WriteLine("Error");
                    break;
            }
        }
        public void Print()
        {
            WriteLine($"{Name} словарь");
            foreach (var i in dict.Keys)
            {
                WriteLine($"{Format(i)} - {String.Join(", ", dict[i].ToArray())}");
            }
        }
    }
}
