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
                ConsoleKeyInfo btn;
                do
                {
                    Clear();
                    Write("1-Создать словарь\n2-Работать с существующем словарем" +
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

                            ConsoleKeyInfo btn1;
                            do
                            {
                                Write("1-Добавить слово в словарь\n2-Заменить слово или перевод" +
                                    "\n3-Удалить слово или перевод\n4-Поиск перевода" +
                                    "\n5-Вывести словарь в консоль\nEscape-вернуться в главное меню" +
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
                                    default:
                                        WriteLine("Error");
                                        break;
                                }
                                btn1 = ReadKey();
                            } while (btn1.Key != ConsoleKey.Escape);
                            break;
                        default:
                            WriteLine("Error");
                            break;
                    }
                    btn = ReadKey();

                } while (btn.Key != ConsoleKey.Escape);
            }
        }
    
}
