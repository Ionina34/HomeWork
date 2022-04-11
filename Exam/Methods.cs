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
            slovo.ToLower();
            char[] form = slovo.ToCharArray();
            form[0] = char.ToUpper(form[0]);
            return String.Concat<char>(form);
        }
        public void Perevod(List<string> per, string orig)
        {
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
        }


        public void WriteFile(Dictionary<string, List<string>> dict, string file)
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
            using (FileStream fs = new FileStream(file, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.Unicode))
                {
                    sr.ReadToEnd();
                }
            }
        }
        public void Read(Dictionary<string, List<string>> dict, string files)
        {
            var k = File.ReadAllLines(files).Select(l => l.Split('-'));
            foreach (var splites in k)
            {
                var key = splites.First().ToLower();
                while (key.Contains(" ")) { key = key.Replace(" ", ""); }
                var value = splites.Skip(1).ToList();
                
                try { dict.Add(key, value); }
                catch (Exception ex) { WriteLine(ex.Message); }
            }
        }
    }
}
