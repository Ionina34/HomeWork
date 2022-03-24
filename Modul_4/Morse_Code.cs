using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul_4
{
    class Morse_Code
    {
        char[] Alfavit = new char[]
        {
            'А','Б','В','Г','Д','Е','Ё','Ж','З','И','Й','К','Л','М','Н','О','П','Р',
            'С','Т','У','Ф','Х','Ц','Ч','Ш','Щ','Ъ','Ы','Ь','Э','Ю','Я','1','2','3','4',
            '5','6','7','8','9','0'
        };

        string[] Morse = new string[]
        {
            "*-", "-***", "*--", "--*", "-**", "*", "*", "***-", "--**", "**", "*---", "-*-",
            "*-**", "--" ,"-*", "---", "*--*", "*-*", "***", "-", "**-", "**-*", "****", "-*-*",
            "---*", "----", "--*-", "--*--", "-*--", "-**-", "**-**", "**--", "*-*-", "*----",
            "**---", "***--", "****-", "*****", "-****", "--***", "---**", "----*", "-----"
        };

        public Morse_Code()
        {
            WriteLine("Введите строку для зашифровки: ");
            string stroca = ReadLine();
            Encrypt(stroca);
            WriteLine();

            WriteLine("Введите строку для дешифровки: ");
            string str = ReadLine();
            Decrypt(str);

        }

        private void Encrypt(string stroca)
        {
            stroca = stroca.ToUpper();
            string buffer = "";
            int index;
            foreach (char c in stroca)
            {
                if (c != ' ')
                {
                    index = Array.IndexOf(Alfavit, c);
                    buffer += Morse[index];
                }
            }
            Write($"{buffer}") ;
        }

         private void Decrypt(string stroca)
        {
            string[] sumbol = stroca.Split(' ');
           string buffer = "";
            ///string str = "";
            int index;
            foreach (string s in sumbol)
            {
                index = Array.IndexOf(Morse, s);
                buffer += Alfavit[index];
            }
            Write($"{buffer}");
        }
    }
}
