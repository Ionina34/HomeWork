using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul_3_part_2
{
    class Foreign_passport
    {
        public int _PassportNumber;
        public string _FIO;
        public DateTime date_of_issue;

        public Foreign_passport(int passportNumber,string FIO,DateTime date)
        {
            _PassportNumber = passportNumber;
            _FIO = FIO;
            date_of_issue = date;

            Print();
        }

        public void Print()
        {
            //Проверка номера паспорта
            try
            {
                int buffer = _PassportNumber;
                int k = 0;
                while(buffer>0)
                {
                    buffer /= 10;
                    k++;
                }
                if (k != 7) throw new Exception("Неверный номер паспорта");
                else WriteLine($"Номер паспорта: {_PassportNumber}");
            }
            catch(Exception e)
            {
                WriteLine(e.Message);
            }

            //Проверка ФИО
            try
            {
                string[] fio = _FIO.Split(' ');
                int k = 0;
                for(int i=0;i<fio.Length;i++)
                {
                    k++;
                }
                if (k != 3) throw new Exception("ФИО ведено не прaвильно");
                else WriteLine($"ФИО: {_FIO}");
            }
            catch (Exception E)
            {
                WriteLine(E.Message);
            }

            WriteLine($"Дата выдачи: {date_of_issue}");
        }
    }
}
