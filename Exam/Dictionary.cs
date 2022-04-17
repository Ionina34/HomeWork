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
    class Menu : Replacement
    {
        public Menu()
        {
            try
            {
                bool Out = true;
                do
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
                            File.AppendAllText(file, name + " словарь:");
                            break;
                        case 2:
                            Write("В каком файле храниться словарь: ");
                            string files = ReadLine();
                            var dict = new Dictionary<string, List<string>>();
                            List<string> per = new List<string>();

                            try
                            {
                                bool Exit = true;
                                do
                                {
                                    Clear();
                                    Write("1-Добавить слово в словарь\n2-Заменить слово или перевод" +
                                        "\n3-Удалить слово или перевод\n4-Поиск перевода" +
                                        "\n5-Вывести словарь в консоль\n6-Выход в главное меню" +
                                        "\nВаш выбор: ");
                                    int vr = int.Parse(ReadLine());
                                    switch (vr)
                                    {
                                        case 1:
                                            Clear();
                                            Read(dict, files);

                                            Write("Введите слово оригинал: "); string orig = ReadLine().ToLower();

                                            WriteLine("Введите перевод слова: ");
                                            Perevod(per, orig);
                                            dict.Add(orig, per);

                                            WriteFile(dict, files);
                                            break;
                                        case 2:
                                            Clear();
                                            Replacement replacement = new Replacement();
                                            replacement.Replace(files, dict, per);
                                            break;
                                        case 3:
                                            Clear();
                                            Removes removes = new Removes();
                                            removes.Remove(files, dict);
                                            break;
                                        case 4:
                                            Clear();
                                            Poisk poisk = new Poisk();
                                            poisk.Look(files, dict);
                                            break;
                                        case 5:
                                            Clear();
                                            ReadFile(files);
                                            break;
                                        case 6:
                                            Exit = false;
                                            break;
                                        default:
                                            WriteLine("Error");
                                            break;
                                    }
                                } while (Exit);
                            }catch(Exception e) { WriteLine(e.Message); }
                            break;
                        case 3:
                            Out = false;
                            break;
                        default:
                            WriteLine("Error");
                            break;
                    }
                } while (Out);
            }
            catch(Exception e)
            {
                WriteLine(e.Message);
            }
        }
    }

}
