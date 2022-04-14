using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    class Removes : Method
    {
        public void Remove(string files, Dictionary<string, List<string>> dict)
        {
            Write("1-Удалить слово\n2-Удалить перевод\nВы выбрали: ");
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
                        if (i.ToLower() == slo)
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
                    List<string> newper = new List<string>();

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
                                int index = 0;
                                newper = dict[i];

                                for (int p = 0; p < newper.Count; p++)
                                {
                                    if (newper[p] == perRemove)
                                    {
                                        index = p;
                                        flag = true;
                                        newper.RemoveAt(index);
                                    }
                                }
                            }
                    if(flag==true)
                    dict[slovo] = newper;
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
