using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    class Poisk:Method
    {
        public void Look(string files,Dictionary<string,List<string>> dict)
        {
            Read(dict,files);
            Write("Какой перевод хотите найти: ");
            string per = ReadLine().ToLower();
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
    }
}
