using System;
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
            //1)
            /* int[] A = new int[5];
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
                 for (int j = 0; j < cols; j++)
                 {
                     //B[i, j] = rand.NextDouble()*100;
                     B[i, j] = (double)rand.Next(0, 1000) / 100;
                     Write($"{B[i, j]} \t");
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
                 for (int j = 0; j < cols; j++)
                 {
                     if (B[i, j] > max) max = B[i, j];
                     if (B[i, j] < min) min = B[i, j];
                     sum += B[i, j];
                     proz *= B[i, j];
                     if ((j + 1) % 2 != 0) sumB += B[i, j];
                 }
             }
             WriteLine();
             WriteLine($"Общий максимальный элемент: {max}\nОбщий минимальный элемент: {min}\n" +
                 $"Сумма элементов: {sum}\nПроизведение элементов: {proz}\nСумма четных элементов массива А: {sumA}\n" +
                 $"Сумма нечетных столбцов массива В: {sumB}");*/

            //2)
            /*Clear();
            int[,] arr = new int[5, 5];
            int rows = arr.GetUpperBound(0) + 1;
            int cols = arr.Length / rows;
            int sum=0,min = arr[0,0] ,max=0;
            Random rand = new Random();
            WriteLine("Ваш массив: ");
            for(int i=0;i<rows;i++)
            {
                for(int j=0;j<cols;j++)
                {
                    arr[i, j] = rand.Next(-100, 100);
                    Write($"{arr[i, j]}\t");
                    if (arr[i, j] <min)min=arr[i,j];
                    if (arr[i, j] > max) max = arr[i, j];
                }
                WriteLine();
            }
            for(int i=0;i<rows;i++)
            {
                for(int j =0;j<cols;j++)
                {
                    if (arr[i, j] > min && arr[i, j] < max) sum += arr[i, j];
                }
            }
            WriteLine();
            Write($"Сумма элементов расположенынных между min и max значениями: {sum}");*/

            //3)
            /*Clear();
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
                'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };
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
                            if (nomer > 32)
                            {
                                nomer -= 33;
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
                            nomer = nomer + (33 - sdvig);
                            if (nomer > 32)
                            {
                                nomer -= 33;
                            }
                            massege[i] = alf[nomer];
                        }
                    }
                    result = new string(massege);
                    WriteLine($"Расшифрованная строка: {result}");
                    break;
            default:
            WriteLine("Error);
            break;
            }*/

            //4)
            /*Clear();
            int[,] arr = new int[3, 3];
            int rows = arr.GetUpperBound(0) + 1;
            int cols = arr.Length / rows;
            int[,] arr1 = new int[3, 3];
            int rows1 = arr1.GetUpperBound(0) + 1;
            int cols1 = arr1.Length / rows;
            int[,] res = new int[rows, cols1];
            int rows2 = res.GetUpperBound(0) + 1;
            int cols2 = res.Length / rows2;

            Random rand = new Random();
            WriteLine("1 Матрица: ");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    arr[i, j] = rand.Next(0, 10);
                    Write($"{arr[i, j]}\t");
                }
                WriteLine();
            }
            WriteLine();

            WriteLine("2 Матрица");
            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols1; j++)
                {
                    arr1[i, j] = rand.Next(0, 10);
                    Write($"{arr1[i, j]}\t");
                }
                WriteLine();
            }
            WriteLine();

            Write($"Какую матрицу будем умножать 1 или 2? ");
            int v = Int32.Parse(ReadLine());
            Write($"Ведите множитель: ");
            int num = Int32.Parse(ReadLine());
            switch (v)
            {
                case 1:
                    WriteLine($"1 Матрица умноженная на {num}"); ;
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            res[i,j]=arr[i, j] * num;
                            Write($"{res[i, j]}\t");
                        }
                        WriteLine();
                    }
                    break;
                case 2:
             WriteLine($"2 Матрица умноженная на {num}"); ;
                    for(int i=0;i<rows1;i++)
                    {
                        for(int j=0;j<cols1;j++)
                        {
                            res[i,j]=arr1[i, j] * num;
                            Write($"{res[i, j]}\t");
                        }
                        WriteLine();
                    }
                    break;
            }
            WriteLine();

            WriteLine("Сложение 1 и 2 Матриц: ");
            if(rows==rows1 && cols==cols1)
            {
                for(int i=0;i<rows;i++)
                {
                   for( int j = 0;j < cols;j++)
                    {
                        res[i,j]=arr[i, j] + arr1[i, j];
                        Write($"{res[i, j]}\t");
                    }
                    WriteLine();
                }
            }
            WriteLine();
            WriteLine("Произведение матриц: ");
            if (rows == cols1)
            {
                for (int i = 0; i < rows1; i++)
                {
                    for (int j = 0; j < cols1; j++)
                    {
                        res[i,j]=0;
                        for (int k = 0; k < rows1; k++)
                        {
                            res[i, j] += arr[i, k] * arr1[k, j];
                        }
                    }
                }
                for(int i=0;i<rows2;i++)
                {
                    for(int j=0;j<cols2;j++)
                    {
                        Write($"{res[i, j]}\t");
                    }
                    WriteLine();
                }
            }*/

            //7
            Clear();
            string s = $"To be, or not to be, that is the question,\n" +
$"Whether 'tis nobler in the mind to suffer\n" +
               $"Or to take arms against a sea of troubles,\n" +
$"And by opposing end them? To die: to sleep;\n" +
          $"No more; and by a sleep to say we end\n" +
$"The heart-ache and the thousand natural shocks\n" +
$"That flesh is heir to, 'tis a consummation\n" +
$"Devoutly to be wish'd. To die, to sleep\n";
            int statistica = 0;
            //string a = "die";
            for(int i=0;i<s.Length;i++)
            {
                if (s[i] == 'd' && s[i + 1] == 'i' && s[i + 2] == 'e')
                {
                    statistica++;
                }
            }
             s = s.Replace("die", "***");

            //WriteLine();
            WriteLine(s);
            WriteLine($"{statistica} замены слова die");

            Console.ReadLine();
        }
    }
}
