using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    class Removes:Method
    {
        public void Remove(string files, Dictionary<string, List<string>> dict)
        {
            Write("1-Удалить слово\n2-Удалить перевод\nВы пыбрали: ");
            int k = int.Parse(ReadLine());
            bool flag = false;
            switch (k)
            {
                case 1:
                    Read(dict, files);
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
                    WriteFile(dict, files);
                    break;
                case 2:
                    Read(dict, files);
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
                    WriteFile(dict, files);
                    break;
                default:
                    WriteLine("Error");
                    break;
            }
        }
    }
}
