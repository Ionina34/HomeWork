using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul_3_part_2
{
    class Translating_a_number
    {
        string[] Number ={"zero","one","two","three","four","five","six","seven",
        "eight","nine"};
        int[] num = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        public Translating_a_number()
        {
            bool proverca=false;

            Write("Введите цифру от 0 до 9 словом: ");
            string str = ReadLine().ToLower();

            for (int i = 0; i < Number.Length; i++)
            {
                if (Number[i] == str)
                {
                    WriteLine($"{str} это цифра {num[i]}");
                    proverca = true;
                }
            }
            if (proverca == false) WriteLine("Проверьте правильность написания");
        }
    }
}
