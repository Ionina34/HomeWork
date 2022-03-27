using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul_3_part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //1)
            // "Число", Исходная СС числа, СС в которую переводим число
            // new Calculator_CC("1111210111111122", 4, 36);

            //2)
            //new Translating_a_number();

            //3)
            //new Foreign_passport(1223534,"Иван Иванов Иванович",new DateTime(1987,4,23));

            //4)
            Write("Введите логическое выражение: ");
            string str = ReadLine();
            bool itog = false;
            int index = 0;
            string a = "";
            string b = "";

            str.ToCharArray();


            try
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == ',' || str[i] == '.' || str[i] == '+' || str[i] == '-' || str[i] == '/' || str[i] == '%')
                        throw new Exception("Неверный формат: в сторке могут быть только целые числа и операторы сравнения");
                    if (str[i] == '<' || str[i] == '>' || str[i] == '=' || str[i] == '!')
                        index = i;
                    if(str[i]=='='&&str[i+1]!='=')throw new Exception("Неверный формат: в сторке могут быть только целые числа и операторы сравнения");
                    if(str[i]=='!'&&str[i+1]!='=')throw new Exception("Неверный формат: в сторке могут быть только целые числа и операторы сравнения");
                }

                for (int i = 0; i < index; i++)
                {
                    if(str[i]!='=')
                    a = a.Insert(i, str[i].ToString());
                }
                for (int i = index+1,j=0; i < str.Length; i++,j++)
                {
                    if(str[i]!='=')
                    b = b.Insert(j, str[i].ToString());
                }
                int l = Int32.Parse(a);
                int p = Int32.Parse(b);
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == '<')
                        if (l < p) itog = true;

                    if (str[i] == '>')
                        if (l > p) itog = true;

                    if (str[i] == '<' && str[i + 1] == '=')
                        if (l <= p) itog = true;

                    if (str[i] == '>' && str[i + 1] == '=')
                        if (l >= p) itog = true;

                    if (str[i] == '=' && str[i + 1] == '=')
                        if (l == p) itog = true;

                    if (str[i] == '!' && str[i + 1] == '=')
                        if (l != p) itog = true;
                }
                WriteLine(itog);
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }

            ReadKey();
        }
    }
}
