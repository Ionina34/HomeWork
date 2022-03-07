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
            ConsoleKeyInfo btn;
            do
            {
                Console.Clear();
                Console.Write("Задание 1\nЗадание 2\nЗадание 3\nЗадание 4\nЗадание 5\nЗадание 6\nЗадание 7\n");
                Console.Write("Сделайте свой выбор: ");
                int s = Int32.Parse(Console.ReadLine());
                switch (s)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Введите число в диапозоне от 1 до 100: ");
                        int num = Int32.Parse(Console.ReadLine());
                        if (num < 1 || num > 100) Console.WriteLine("Error: Число не вxодит в диапозон");
                        if (num >= 1 && num <= 100)
                        {
                            if (num % 5 == 0 && num % 3 == 0) Console.WriteLine("Fizz Buzz");
                            else if (num % 3 == 0) Console.WriteLine("Fizz");
                            else if (num % 5 == 0) Console.WriteLine("Buzz");
                            else if (num % 3 != 0 && num % 5 != 0) Console.WriteLine(num);
                        }
                        btn = Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.Write("Введите число: ");
                        int num1 = Int32.Parse(Console.ReadLine());
                        Console.Write("Введите процент: ");
                        int percent = Int32.Parse(Console.ReadLine());
                        Console.WriteLine($"{percent}% от числа {num1} = {(double)(num1 * percent) / 100}");
                        btn = Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        Console.Write("Введите 4 числа: ");
                        int chislo = 0;
                        for (int i = 0; i < 4; i++)
                        {
                            chislo *= 10;
                            int c = Int32.Parse(Console.ReadLine());
                            chislo += c;
                        }
                        Console.WriteLine(chislo);
                        btn = Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        Console.Write("Введите 6-ое число: ");
                        int num_1 = Int32.Parse(Console.ReadLine());
                        if (num_1 < 100000 || num_1 > 999999)
                        {
                            Console.WriteLine("Error: Число не 6-ое ");
                        }
                        else
                        {
                            //string tmp = num_1.ToString();
                            string tmp =Convert.ToString(num_1);
                            Console.Write("Введите разряды цифр: ");
                            int a = Int32.Parse(Console.ReadLine());
                            int b = Int32.Parse(Console.ReadLine());
                            for (int i = 0; i < tmp.Length; i++)
                            {
                                if (i == a) Console.Write(tmp[b]);
                                else if (i == b) Console.Write(tmp[a]);
                                else Console.Write(tmp[i]);
                            }
                            Console.ReadLine();
                        }
                        btn = Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();
                        Console.Write("Введите день: ");
                        int day_of_month = Int32.Parse(Console.ReadLine());
                        Console.Write("Введите месяц: ");
                        int month = Int32.Parse(Console.ReadLine());
                        Console.Write("Введите год: ");
                        int year = Int32.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine($"{day_of_month}.{month}.{year}");
                        bool proverka = true;
                        if (year % 4 == 0 && month == 2 && day_of_month > 29)
                        {
                            Console.WriteLine("В феврале в этом году 29 дней");
                            proverka = false;
                        }
                        else if (month > 12)
                        {
                            Console.WriteLine("Такого месяца не существует!");
                            proverka = false;
                        }
                        else
                        {
                            if (((month <= 7 && month % 2 != 0) || (month > 7 && month % 2 == 0)) && day_of_month > 31)
                            {
                                Console.WriteLine("В этом месяце такого дня нет!");
                                proverka = false;
                            }
                            if (((month <= 7 && month % 2 == 0) || (month > 7 && month % 2 != 0)) && day_of_month > 30)
                            {
                                Console.WriteLine("В этом месяце такого дня нет!");
                                proverka = false;
                            }
                        }
                        string season = "0";
                        string day_of_week = "0";
                        if (proverka == true)
                        {
                            if (month == 1 || month == 2 || month == 12) season = "Winter";
                            else if (month >= 3 && month <= 5) season = "Spring";
                            else if (month >= 6 && month <= 8) season = "Summer";
                            else if (month >= 9 && month <= 11) season = "Autumn";
                            //Для определения дня недели воспользуемся структорой DateTime
                            DateTime dateTime = new DateTime(year, month, day_of_month);
                            Console.WriteLine($"{season} {dateTime.DayOfWeek}");
                        }
                        btn = Console.ReadKey();
                        break;
                    case 6:
                        Console.Clear();
                        double temperature = 0;
                        Console.Write("Введите показания температуры: ");
                        temperature = Double.Parse(Console.ReadLine());
                        Console.WriteLine("1 - из Фарангейта в Цельсий\n2 - из Цельсия в Фарангейт");
                        int min = Int32.Parse(Console.ReadLine());
                        switch (min)
                        {
                            case 1:
                                Console.WriteLine($"{temperature}F = {(temperature - 32) / 1.8}C");
                                break;
                            case 2:
                                Console.WriteLine($"{temperature}C = {(temperature * 1.8) + 32}");
                                break;
                        }
                        btn = Console.ReadKey();
                        break;
                    case 7:
                        Console.Clear();
                        Console.Write("Введите 2 числа: ");
                        int min1 = Int32.Parse(Console.ReadLine());
                        int max = Int32.Parse(Console.ReadLine());
                        if (min1 > max)
                        {
                            int c = min1;
                            min1 = max;
                            max = c;
                            Console.Clear();
                            Console.WriteLine($"Ваш диапозон от {min1} до {max}");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine($"Ваш диапозон от {min1} до {max}");
                        }
                        for (int i = min1; i <= max; i++)
                        {
                            if (i % 2 == 0) Console.WriteLine(i);
                        }
                        btn = Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Error");
                        btn = Console.ReadKey();
                        break;
                }
            } while (btn.Key != ConsoleKey.Escape);
        }
    }
}
