using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul_3
{
    class WebSite
    {
        public string Name { get; set; } = "Название по умолчанию";
        public string URL { get; set; } = "Путь по умолчанию";
        public string Description { get; set; } = "Сайт без описания";
        public string IP { get; set; } = "0.0.0.0";
        public void Print()
        {
            Write($"{Name}, {URL}, {Description}, {IP}");
        }
    }

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

        public static void Filltracia(int[] arr, int[] arr1)
        {
            WriteLine();
            Write("Отфильтрованный массив: ");
            for(int i=0;i<arr1.Length;i++)
            {
                for(int j=0;j<arr.Length;j++)
                {
                    if (arr[j]==arr1[i]) arr[j] = 0;
                }
            }
            foreach (int i in arr)
            {
                if(i!=0)
                Write($"{i}");
            }
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

            //3
            /*Write("Размер оригинального массива: ");
            int n = Int32.Parse(ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < arr.Length; i++)
            {
                Write($"введите {i} элемент массива: ");
                arr[i] = Int32.Parse(Console.ReadLine());
            }
            Write("Размер массива с данными для фильтрации: ");
            int n1 = Int32.Parse(ReadLine());
            int[] arr1 = new int[n1];
            for (int i = 0; i < arr1.Length; i++)
            {
                Write($"введите {i} элемент массива: ");
                arr1[i] = Int32.Parse(Console.ReadLine());
            }
            Clear();


            Write("Оригинальный массив: ");
            foreach (int i in arr)
            {
                Write($"{i} ");
            }
            WriteLine();
            Write("Массив с данными для фильтрации: ");
            foreach (int i in arr1)
            {
                Write($"{i} ");
            }

            Filltracia(arr, arr1);*/

            ReadLine();
        }
    }
}
