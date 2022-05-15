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
    }
    enum Choice { Add, Replace, Remove, Poisk, Read, Exit }
    class Menu : Replacement
    {
        public Menu()
        {
            var dict = new Dictionary<string, List<string>>();

            bool Out = true;
            do
            {
                try
                {
                    Clear();
                    Write("1-Создать словарь\n2-Работать с существующем словарем\n3-Выход" +
                        "\nВаш выбор: ");
                    int v = int.Parse(ReadLine());
                    switch (v)
                    {
                        case 1:
                            Write("Укажите тип словаря: ");
                            string name = ReadLine();
                            Dictionary dictionary = new Dictionary(name);

                            Write("Введите название файла для хранения словаря: ");
                            string file = ReadLine();
                            if (!(file.Contains(".txt"))) file = file + ".txt";

                            File.AppendAllText(file, name + " словарь:");
                            break;

                        case 2:
                            Write("В каком файле храниться словарь: ");
                            string files = ReadLine();
                            if (!(files.Contains(".txt"))) files = files + ".txt";

                            List<string> per = new List<string>();

                            bool Exit = true;
                            if (File.Exists(files))
                            {
                                do
                                {
                                    try
                                    {
                                        Clear();
                                        Write("1-Добавить слово в словарь\n2-Заменить слово или перевод" +
                                            "\n3-Удалить слово или перевод\n4-Поиск перевода" +
                                            "\n5-Вывести словарь в консоль\n6-Выход в главное меню" +
                                            "\nВаш выбор: ");
                                        int vr = int.Parse(ReadLine()) - 1;
                                        var choice = (Choice)vr;

                                        Read(dict, files);

                                        switch (choice)
                                        {
                                            case Choice.Add:
                                                Clear();

                                                Write("Введите слово оригинал: "); string orig = ReadLine().ToLower();

                                                WriteLine("Введите перевод слова: ");
                                                Perevod(per, orig);
                                                dict.Add(orig, per);

                                                WriteFile(dict, files);
                                                dict.Clear();
                                                break;
                                            case Choice.Replace:
                                                Clear();
                                                Replacement replacement = new Replacement();
                                                replacement.Replace(files, dict, per);
                                                dict.Clear();
                                                break;
                                            case Choice.Remove:
                                                Clear();
                                                Removes removes = new Removes();
                                                removes.Remove(files, dict);
                                                dict.Clear();
                                                break;
                                            case Choice.Poisk:
                                                Clear();
                                                Poisk poisk = new Poisk();
                                                poisk.Look(files, dict);
                                                dict.Clear();
                                                break;
                                            case Choice.Read:
                                                Clear();
                                                ReadFile(files);
                                                break;
                                            case Choice.Exit:
                                                Exit = false;
                                                dict.Clear();
                                                break;
                                            default:
                                                WriteLine("Error");
                                                break;
                                        }
                                    }
                                    catch (Exception e) { Clear(); WriteLine(e.Message); ReadKey(); dict.Clear(); }
                                } while (Exit);
                            }
                            else
                            {
                                Clear();
                                WriteLine("Файл не найден");
                                ReadKey();
                            }
                            break;
                        case 3:
                            Out = false;
                            break;
                        default:
                            Clear();
                            WriteLine("Error");
                            ReadKey();
                            break;
                    }
                }
                catch (Exception e)
                {
                    Clear();
                    WriteLine(e.Message);
                    Write("Продолжить (y/n)? - ");
                    string answer = ReadLine();
                    bool z = answer == "n" ? Out = false : Out = true;
                    dict.Clear();
                }
            } while (Out);
        }
    }

}
