using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            //1)
            /* Console.Write("Введите число в диапозоне от 1 до 100: ");
             int num = Int32.Parse(Console.ReadLine());
             if (num < 1 || num > 100) Console.WriteLine("Error: Число не вxодит в диапозон");
             if (num >= 1 && num <= 100)
             {
                  if (num % 5 == 0 && num % 3 == 0) Console.WriteLine("Fizz Buzz");
                 else if (num % 3 == 0) Console.WriteLine("Fizz"); 
                 else if (num % 5 == 0) Console.WriteLine("Buzz");
                 else if (num % 3 != 0 && num % 5 != 0) Console.WriteLine(num);
             } */

            //2)
            /*Console.Clear();
            Console.Write("Введите число: ");
            int num1 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Введите процент: ");
            int percent = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"{percent}% от числа {num1} = {(double)(num1 * percent) / 100}");*/

            //3)
            /*Console.Clear();
            Console.Write("Введите 4 числа: ");
            int chislo=0;
            for (int i=0;i<4;i++)
            {
                chislo *= 10;
                int num = Int32.Parse(Console.ReadLine());
                chislo += num ;
            }
            Console.WriteLine(chislo);*/

            //4)
            /* Console.Clear();
             Console.Write("Введите 6-ое число: ");
             int num = Int32.Parse(Console.ReadLine());
             if (num < 100000 || num > 999999)
             {
                 Console.WriteLine("Error: Число не 6-ое ");
             }
             else
             {
                string tmp = num.ToString();
                 Console.Write("Введите разряды цифр: ");
                 int a = Int32.Parse(Console.ReadLine());
                 int b = Int32.Parse(Console.ReadLine());
                 for(int i=0;i<tmp.Length;i++)
                 {
                     //-1 т.к счет с 0
                     if (i == a - 1) Console.Write(tmp[b-1]);
                     else if (i == b - 1) Console.Write(tmp[a -1]);
                     else Console.Write(tmp[i]);
                 }
                 Console.ReadLine();
             }*/

            //5)
            Console.Write("Введите день: ");
            int day_of_month = Int32.Parse(Console.ReadLine());
            Console.Write("Введите месяц: ");
            int month = Int32.Parse(Console.ReadLine());
            Console.Write("Введите год: ");
            int year = Int32.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine($"{day_of_month}.{month}.{year}");
            if (year % 4 == 0 && month == 2 && day_of_month > 29) Console.WriteLine("В феврале в этом году 29 дней");
            else if (month > 12) Console.WriteLine("Такого месяца не существует!");
            else
            {
                if ((month <= 7 && month % 2 != 0) || (month > 7 && month % 2 == 0) && day_of_month > 31)
                    Console.WriteLine("В этом месяце не столько дней!");
                if ((month <= 7 && month % 2 == 0) || (month > 7 && month % 2 != 0) && day_of_month > 30)
                    Console.WriteLine("В этом месяце не столько дней!");
            }
            



            //6)
            /*double temperature = 0;
            Console.Write("Введите показания температуры: ");
            temperature = Double.Parse(Console.ReadLine());
            Console.WriteLine("1 - из Фарангейта в Цельсий\n2 - из Цельсия в Фарангейт");
            int a = Int32.Parse(Console.ReadLine());
            switch (a)
            {
                case 1:
                    Console.WriteLine($"{temperature}F = {(temperature - 32) / 1.8}C");
                    break;
                case 2:
                    Console.WriteLine($"{temperature}C = {(temperature * 1.8) + 32}");
                    break;
            }*/

            //7)
            /* Console.Write("Введите 2 числа: ");
             int a = Int32.Parse(Console.ReadLine());
             int b = Int32.Parse(Console.ReadLine());
             if(a>b)
             {
                 int c = a;
                 a = b;
                 b = c;
             Console.Clear();
             Console.WriteLine($"Ваш диапозон от {a} до {b}");
             }
             else
             {
                 Console.Clear();
                 Console.WriteLine($"Ваш диапозон от {a} до {b}");
             }
             for(int i=a;i<=b;i++)
             {
                 if (i % 2 == 0) Console.WriteLine(i);
             }*/
        }
    }
}
