using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul_3
{
    class Program
    {
        public static void Square(int a, string simbol)
        {
            int storona = 0;
            //Чтобы был квадрат был визульно квадратом
            if (a % 2 == 0)
                storona = a / 2;
            else storona = a / 2 + 1;
            WriteLine("1 - заполненный квадрат\n2 - пустой квадрат");
            int s = Int32.Parse(ReadLine());

            switch (s)
            {
                case 1:
                    for (int i = 0; i < storona; i++)
                    {
                        for (int j = 0; j < a; j++)
                        {
                            Write(simbol);
                        }
                        WriteLine();
                    }
                    break;
                case 2:
                    for (int i = 0; i <= storona; i++)
                    {
                        for (int j = 0; j <= a; j++)
                        {
                            if (j == 0 || j == a || i == 0 || i == storona)
                                Write(simbol);
                            else Write(" ");
                        }
                        WriteLine();
                    }
                    break;
            }
        }

        public static bool Palindrom(string chislo)
        {
            for (int i = 0; i < chislo.Length / 2; i++)
                if (chislo[i] != chislo[chislo.Length - 1 - i]) return false;
            return true;

        }
        static void Main(string[] args)
        {
            //1)
            //Write("Введите сторону квадрата: ");
            //int a = Int32.Parse(ReadLine());
            //Write("Введите символ: ");string simbol = ReadLine();
            //Square(a, simbol);

            //2)
            //Write("Введите число: ");string chislo = ReadLine();
            //WriteLine( Palindrom(chislo));

            ReadLine();
        }
    }
}
