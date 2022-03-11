﻿using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo btn;
            do
            {
                Console.Clear();
                Console.Write("Задание 1:\nЗадание 2:\nЗадание 3:\nЗадание 4:\nЗадание 5:\nЗадание 7:\n");
                Console.Write("Сделайте свой выбор: ");
                int s = Int32.Parse(Console.ReadLine());
                switch (s)
                {
                    case 1:
                        Clear();
                        int[] A = new int[5];
                        double[,] B = new double[3, 4];
                        Random rand = new Random();
                        WriteLine("заполните массив a: ");
                        for (int i = 0; i < A.Length; i++)
                        {
                            Write($"введите {i} элемент массива: ");
                            A[i] = Int32.Parse(Console.ReadLine());
                        }
                        Clear();
                        WriteLine("массив A: ");
                        foreach (int i in A)
                        {
                            Write($"{i} ");
                        }
                        WriteLine();
                        WriteLine("массив B:");
                        int rows = B.GetUpperBound(0) + 1;
                        int cols = B.Length / rows;
                        for (int i = 0; i < rows; i++)
                        {
                            for (int h = 0; h < cols; h++)
                            {
                                B[i, h] = rand.NextDouble() * 100;
                                B[i, h] = (double)rand.Next(0, 1000) / 100;
                                Write($"{B[i, h]} \t");
                            }
                            WriteLine();
                        }
                        double max = 0, min = A[0], sum = 0, proz = 1, sumB = 0;
                        int sumA = 0;

                        foreach (int i in A)
                        {
                            if (i > max) max = i;
                            if (i < min) min = i;
                            sum += i;
                            proz *= i;
                            if (i % 2 == 0) sumA += i;
                        }
                        for (int i = 0; i < rows; i++)
                        {
                            for (int h = 0; h < cols; h++)
                            {
                                if (B[i, h] > max) max = B[i, h];
                                if (B[i, h] < min) min = B[i, h];
                                sum += B[i, h];
                                proz *= B[i, h];
                                if ((h + 1) % 2 != 0) sumB += B[i, h];
                            }
                        }
                        WriteLine();
                        WriteLine($"Общий максимальный элемент: {max}\nОбщий минимальный элемент: {min}\n" +
                            $"Сумма элементов: {sum}\nПроизведение элементов: {proz}\nСумма четных элементов массива А: {sumA}\n" +
                            $"Сумма нечетных столбцов массива В: {sumB}");
                        btn = Console.ReadKey();
                        break;
                    case 2:
                        Clear();
                        int[,] arr = new int[5, 5];
                        int _rows = arr.GetUpperBound(0) + 1;
                        int _cols = arr.Length / _rows;
                        int sum1 = 0, min1 = arr[0, 0], max1 = 0;
                        Random rand1 = new Random();
                        WriteLine("Ваш массив: ");
                        for (int i = 0; i < _rows; i++)
                        {
                            for (int h = 0; h < _cols; h++)
                            {
                                arr[i, h] = rand1.Next(-100, 100);
                                Write($"{arr[i, h]}\t");
                                if (arr[i, h] < min1) min1 = arr[i, h];
                                if (arr[i, h] > max1) max1 = arr[i, h];
                            }
                            WriteLine();
                        }
                        for (int i = 0; i < _rows; i++)
                        {
                            for (int h = 0; h < _cols; h++)
                            {
                                if (arr[i, h] > min1 && arr[i, h] < max1) sum1 += arr[i, h];
                            }
                        }
                        WriteLine();
                        Write($"Сумма элементов расположенынных между min и max значениями: {sum1}");
                        btn = Console.ReadKey();
                        break;
                    case 3:
                        Clear();
                        WriteLine("1 - Зашифровка\n2 - Дешифровка");
                        int v = Int32.Parse(ReadLine());

                        Write("Введите строку: ");
                        string stroka = ReadLine();

                        int nomer = 0, sdvig = 0, j = 0;
                        // Номер в алфавите, Смещение, для цикла
                        string result = "0";
                        Write("Введите ключ: ");
                        sdvig = Int32.Parse(ReadLine());

                        char[] massege = stroka.ToCharArray();
                        char[] alf = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з',
                            'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т',
                            'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я',
                        'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o',
                        'p','q','r','s','t','u','v','w','x','y','z'};
                        switch (v)
                        {
                            case 1:
                                for (int i = 0; i < massege.Length; i++)
                                {
                                    for (j = 0; j < alf.Length; j++)
                                    {
                                        if (massege[i] == alf[j])
                                        {
                                            break;
                                        }
                                    }
                                    if (j != 33) ;//Если 33 символ  не из алфовита
                                    {
                                        nomer = j;
                                        nomer += sdvig;
                                        if (nomer > 58)
                                        {
                                            nomer -= 59;
                                        }
                                        massege[i] = alf[nomer];
                                    }
                                }
                                result = new string(massege);
                                WriteLine($"Зашифрованная строка: {result}");
                                break;
                            case 2:
                                for (int i = 0; i < massege.Length; i++)
                                {
                                    for (j = 0; j < alf.Length; j++)
                                    {
                                        if (massege[i] == alf[j])
                                        {
                                            break;
                                        }
                                    }
                                    if (j != 33) ;//Если 33 - символ не из алфовита
                                    {
                                        nomer = j;
                                        nomer = nomer + (59 - sdvig);
                                        if (nomer > 32)
                                        {
                                            nomer -= 59;
                                        }
                                        massege[i] = alf[nomer];
                                    }
                                }
                                result = new string(massege);
                                WriteLine($"Расшифрованная строка: {result}");
                                break;
                            default:
                                WriteLine("Error");
                                break;
                        }
                        btn = Console.ReadKey();
                        break;
                    case 4:
                        Clear();
                        int[,] arr0 = new int[3, 3];
                        int rows0 = arr0.GetUpperBound(0) + 1;
                        int cols0 = arr0.Length / rows0;
                        int[,] arr1 = new int[3, 3];
                        int rows1 = arr1.GetUpperBound(0) + 1;
                        int cols1 = arr1.Length / rows0;
                        int[,] res = new int[rows0, cols1];
                        int rows2 = res.GetUpperBound(0) + 1;
                        int cols2 = res.Length / rows2;
                        Random rand2 = new Random();

                        WriteLine("1 Матрица: ");
                        for (int i = 0; i < rows0; i++)
                        {
                            for (int h = 0; h < cols0; h++)
                            {
                                arr0[i, h] = rand2.Next(0, 10);
                                Write($"{arr0[i, h]}\t");
                            }
                            WriteLine();
                        }
                        WriteLine();

                        WriteLine("2 Матрица");
                        for (int i = 0; i < rows1; i++)
                        {
                            for (int h = 0; h < cols1; h++)
                            {
                                arr1[i, h] = rand2.Next(0, 10);
                                Write($"{arr1[i, h]}\t");
                            }
                            WriteLine();
                        }
                        WriteLine();

                        Write($"Какую матрицу будем умножать 1 или 2? ");
                        int v1 = Int32.Parse(ReadLine());
                        Write($"Ведите множитель: ");
                        int num = Int32.Parse(ReadLine());
                        switch (v1)
                        {
                            case 1:
                                WriteLine($"1 Матрица умноженная на {num}"); ;
                                for (int i = 0; i < rows0; i++)
                                {
                                    for (int h = 0; h < cols0; h++)
                                    {
                                        res[i, h] = arr0[i, h] * num;
                                        Write($"{res[i, h]}\t");
                                    }
                                    WriteLine();
                                }
                                break;
                            case 2:
                                WriteLine($"2 Матрица умноженная на {num}"); ;
                                for (int i = 0; i < rows1; i++)
                                {
                                    for (int h = 0; h < cols1; h++)
                                    {
                                        res[i, h] = arr1[i, h] * num;
                                        Write($"{res[i, h]}\t");
                                    }
                                    WriteLine();
                                }
                                break;
                        }
                        WriteLine();

                        WriteLine("Сложение 1 и 2 Матриц: ");
                        if (rows0 == rows1 && cols0 == cols1)
                        {
                            for (int i = 0; i < rows0; i++)
                            {
                                for (int h = 0; h < cols0; h++)
                                {
                                    res[i, h] = arr0[i, h] + arr1[i, h];
                                    Write($"{res[i, h]}\t");
                                }
                                WriteLine();
                            }
                        }
                        WriteLine();
                        WriteLine("Произведение матриц: ");
                        if (rows0 == cols1)
                        {
                            for (int i = 0; i < rows1; i++)
                            {
                                for (int h = 0; h < cols1; h++)
                                {
                                    res[i, h] = 0;
                                    for (int k = 0; k < rows1; k++)
                                    {
                                        res[i, h] += arr0[i, k] * arr1[k, h];
                                    }
                                }
                            }
                            for (int i = 0; i < rows2; i++)
                            {
                                for (int h = 0; h < cols2; h++)
                                {
                                    Write($"{res[i, h]}\t");
                                }
                                WriteLine();
                            }
                        }
                        btn = Console.ReadKey();
                        break;
                    case 5:
                        Clear();
                        Write("Введите выражение: ");
                        string stroc = ReadLine();
                        char[] operat = { '-', '+' };

                        var data = stroc.Split(operat, StringSplitOptions.None);
                        int resul = int.Parse(data[0]);

                        for (int i = 1; i < data.Length; i++)
                        {
                            if (stroc.Contains("+"))
                            {
                                resul += int.Parse(data[i]);
                            }
                            else //(stroc.Contains("-"))
                            {
                                resul -= int.Parse(data[i]);
                            }
                        }
                        WriteLine(resul);
                        btn = Console.ReadKey();
                        break;
                    case 7:
                        Clear();
                        string a = $"To be, or not to be, that is the question,\n" +
            $"Whether 'tis nobler in the mind to suffer\n" +
                           $"Or to take arms against a sea of troubles,\n" +
            $"And by opposing end them? To die: to sleep;\n" +
                      $"No more; and by a sleep to say we end\n" +
            $"The heart-ache and the thousand natural shocks\n" +
            $"That flesh is heir to, 'tis a consummation\n" +
            $"Devoutly to be wish'd. To die, to sleep\n";
                        int statistica = 0;
                        for (int i = 0; i < a.Length; i++)
                        {
                            if (a[i] == 'd' && a[i + 1] == 'i' && a[i + 2] == 'e')
                            {
                                statistica++;
                            }
                        }
                        a = a.Replace("die", "***");

                        //WriteLine();
                        WriteLine(a);
                        WriteLine($"{statistica} замены слова die");
                        btn = Console.ReadKey();
                        break;
                    default:
                        WriteLine("Error");
                        btn = Console.ReadKey();
                        break;
                }
            } while (btn.Key != ConsoleKey.Escape);
        }
    }
}
