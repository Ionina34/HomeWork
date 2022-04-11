using System;
using System.IO;
using static System.Console;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{

    class Dictionary : Method
    {
        public string Name { get; set; }
        public Dictionary(string name)
        {
            Name = name;
        }
#if false
        public void Add(Dictionary<string, List<string>> dict)
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
#endif
#if false
        public void Replacement(Dictionary<string, List<string>> dict)
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
                    {
                        dict.Add(newslovo, per);
                    }
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
#endif
#if false
        public void Remove(Dictionary<string, List<string>> dict)
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
                            {
                                WriteLine($"Это единственный перевод слова {Format(slovo)}");
                                flag = true;
                            }
                            else
                            {
                                Write("Какую вариацию перевода хотите удалить: ");
                                string perRemove = ReadLine().ToLower();
                                List<string> per = dict[i];
                                int index = 0;

                                for (int p = 0; p < per.Count; p++)
                                {
                                    if (per[p] == perRemove)
                                    {
                                        index = p;
                                        flag = true;
                                        per.RemoveAt(index);
                                    }
                                }
                            }
                    if (flag == false)
                        WriteLine("Совпадений не найдено");
                    break;
                default:
                    WriteLine("Error");
                    break;
            }
        } 
#endif
        public void Poisk(Dictionary<string, List<string>> dict)
        {
            Write("Какой перевод хотите найти: ");
            string per = ReadLine();
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
        }
        public void Print(Dictionary<string, List<string>> dict)
        {
            foreach (var i in dict.Keys)
            {
                WriteLine($"{Format(i)} - {String.Join(", ", dict[i].ToArray())}");
            }
            //Clear();

            //WriteLine($"{Name} словарь: ");
            //ReadFile(dict);
        }
    }

    class Menu : Replacement
    {
        public Menu()
        {
#if false
            Write("Введите название файла для хранения словаря: ");
            string file = ReadLine();
            FileInfo fi1 = new FileInfo(file);
            if (!fi1.Exists)
            {
                WriteFile(dict, file);
            }

            Write("2-Добавить в словарь слово");
            int v = int.Parse(ReadLine());



            switch (v)
            {
                case 1:
                    ReadFile(dict, file);
                    Add();
                    WriteFile(dict, file);
                    break;
            } 
#endif

            Write("1-Создать словарь\n2-Работать с существующем словарем ");
            int v = int.Parse(ReadLine());

            switch (v)
            {
                case 1:
                    Write("Укажите тип словаря: ");
                    string name = ReadLine();
                    Dictionary dictionary = new Dictionary(name);

                    Write("Введите название файла для хранения словаря: ");
                    string file = ReadLine();
                    File.AppendAllText(file, name+" словарь:");

                    break;
                case 2:
                    Write("В каком файле храниться словарь: ");
                    string files = ReadLine();
                    var dict = new Dictionary<string, List<string>>();
                    List<string> per = new List<string>();

                    Write("1-Добавить слово в словарь\n2-Заменить слово или перевод" +
                        "\n3-Удалить слово или перевод ");
                    int vr = int.Parse(ReadLine());

                    switch (vr)
                    {
                        case 1:
                            Read(dict, files);

                            Write("Введите слово оригинал: "); string orig = ReadLine().ToLower();

                            WriteLine("Введите перевод слова: ");
                            Perevod(per, orig);
                            dict.Add(orig, per);

                            WriteFile(dict, files);
                            break;
                        case 2:
                            Replacement replacement = new Replacement();
                            replacement.Replace(files, dict, per);
                            break;
                        case 3:
                            Removes removes = new Removes();
                            removes.Remove(files, dict);
                            break;

                    }
                    break;
            }

        }
    }
}
