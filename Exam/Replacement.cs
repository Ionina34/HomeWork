using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    class Replacement : Method
    {
        public void Replace(string files, Dictionary<string, List<string>> dict, 
            List<string> per)
        {
            Write("1 - Замена слова\n2 - Замена перевода\nВы выбрали: ");
            int k = int.Parse(ReadLine());
            switch (k)
            {
                case 1:
                    Read(dict, files);
                    Write("Введите слово, кoторое вы хотите заменить: ");
                    string slovo = ReadLine().ToLower();
                    Write("Введите слово для замены: "); string newslovo = ReadLine().ToLower();

                    string remove = "";
                    bool flag = false;

                    foreach (var j in dict.Keys)
                    {
                        if (slovo == j)
                        {
                            per = dict[j];
                            remove = j;
                            flag = true;
                            break;
                        }
                    }
                    if (flag == true)
                    {
                        dict.Remove(remove);
                        dict.Add(newslovo, per);
                    }
                    else WriteLine("Совпадений не найдено");
                    WriteFile(dict, files);
                    break;
                case 2:
                    Read(dict, files);
                    Write("Перевод какого слова хотите поменять: ");
                    string slov = ReadLine().ToLower();

                    if (dict.ContainsKey(slov))
                    {
                        Write("Введите новый перевод: ");
                        List<string> newper = new List<string>();
                        Perevod(newper, slov);

                        dict[slov] = newper;
                    }
                    else WriteLine("Совпадений не найдено");
                    WriteFile(dict, files);
                    break;
                default:
                    WriteLine("Error");
                    break;
            }
        }
    }
}
