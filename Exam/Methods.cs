using System;
using System.IO;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    public class Method
    {
        public string Format(string slovo)
        {
            char[] form = slovo.ToCharArray();
            form[0] = char.ToUpper(form[0]);
            return String.Concat<char>(form);
        }

        public void WriteFile(Dictionary<string, List<string>> dict,string file)
        {
            using (FileStream fs = new FileStream(file, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
                {
                    foreach (var i in dict.Keys)
                    {
                        sw.WriteLine($"{Format(i)} - {String.Join(", ", dict[i].ToArray())}");
                    }
                }
            }
        }
        public void ReadFile(string file)
        {
            using (FileStream fs = new FileStream(file,FileMode.Open))
            {
                using(StreamReader sr = new StreamReader(fs,Encoding.Unicode))
                {
                    sr.ReadToEnd();
                }
            }
        }
    }
}
