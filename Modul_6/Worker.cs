using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul_6
{
   abstract class Worker
    {
        public string  Name { get; set; }
        public string  LastName { get; set; }
        public DateTime  BirthDate { get; set; }
        public double Salary { get; set; }

        public Worker(string name, string lastName, DateTime date, double salary) { }
        public abstract void Print();
        public override string ToString()
        {
            return $"Имя: {Name}\nФамилия: {LastName}\nДень рождения: {BirthDate.ToLongDateString()}\n" +
                $"Зарплата: {Salary}";
        }
    }
    class President:Worker
    {
        public President(string name,string lastName,DateTime date,double salary):base(name,lastName,date,salary)
        {
            Name = name;
            LastName = lastName;
            BirthDate = date;
            Salary = salary;
        }
        public override void Print()
        {
            WriteLine(base.ToString());
        }
    }
    class Security:Worker
    {
        string Smena;
        public Security(string name, string lastName, DateTime date, double salary, string smena) : base(name, lastName, date, salary)
        {
            Name = name;
            LastName = lastName;
            BirthDate = date;
            Salary = salary;
            Smena = smena;
        }
        public override void Print()
        {
            WriteLine(base.ToString()+$"\nСмена: {Smena}");
        }
    }

    class Manager : Worker
    {
        string Qualifications;
        public Manager(string name, string lastName, DateTime date, double salary, string qua) : base(name, lastName, date, salary)
        {
            Name = name;
            LastName = lastName;
            BirthDate = date;
            Salary = salary;
            Qualifications = qua;
        }
        public override void Print()
        {
            WriteLine(base.ToString() + $"\nКвалификация: {Qualifications}");
        }
    }
    class Engineer : Worker
    {
        int Work_experience;
        public Engineer(string name, string lastName, DateTime date, double salary,int work) : base(name, lastName, date, salary)
        {
            Name = name;
            LastName = lastName;
            BirthDate = date;
            Salary = salary;
            Work_experience = work;
        }
        public override void Print()
        {
            WriteLine(base.ToString() + $"\nСтаж работы: {Work_experience}");

        }
    }

}
