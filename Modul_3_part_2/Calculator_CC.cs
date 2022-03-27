using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul_3_part_2
{
    class Calculator_CC
    {
        string _number;
        int _fromBase;
        int _toBase;
        char[] CC = { '0','1','2','3','4','5','6','7','8','9','A','B','C',
                'D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T',
            'U','V','W','X','Y','Z' };
      //ABCDEFGHIJKLMNOPRSTUVXYZ";
        public Calculator_CC(string number, int fromBase, int toBase)
        {
            try
            {
                _number = number;
                _fromBase = fromBase;
                _toBase = toBase;

                if (fromBase <= 1 || toBase <= 1 || fromBase>=37 || toBase>=37) 
                    throw new Exception("Такой системы счисления нет");

                //Проверка на корректность веденных данных
                for (int i=0;i<_number.Length;i++)
                {
                    for(int j=0;j<CC.Length;j++)
                    {
                        if (_number[i] == CC[j] && CC[j] > CC[fromBase-1])
                            throw new Exception("Выход за пределы СС");
                        
                    }
                }

                 WriteLine($"{_number} в {_fromBase}-ой = " +
               $"{ Convert(_number, _fromBase, _toBase)} в {_toBase}-ой");
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
        }

        private string Convert(string number, int fromBase, int toBase)
        {
            number.ToLower();
            string res = "";
            int dec = 0;
            string CC = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            //Переводим число в 10 - ую
            for (int i = 0; i < number.Length; i++)
            {
                int chislo = CC.IndexOf(number[i]);
                dec += chislo * (int)Math.Pow(fromBase, number.Length - i - 1);
            }
            //Из 10-ой в заданную
            while (dec >= toBase)
            {
                int ost = dec % toBase;
                res = res.Insert(0, CC[ost].ToString());
                dec /= toBase;
            }
            res = res.Insert(0, CC[dec].ToString());
            return res;
        }
    }
}
