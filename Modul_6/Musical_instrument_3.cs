using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul_6
{
     class Musical_instrument_3
    {
        public string Name { get; set; }
        public string Specifications { get; set; }
        public void Print()
        {
            WriteLine($"Название: {Name}\n Хар-ка: {Specifications}");
        }

    }

    class Violin:Musical_instrument_3
    {
        public Violin(string name, string har)
        {
            Name = name;
            Specifications = har;
        }
        public  void Sound()
        {
            WriteLine($"*приятные скрипучии звуки скрипки*");
        }
        public  void Show()
        {
            WriteLine($"Название инструмента: {Name}");
        }
        public  void Desc()
        {
            WriteLine($"Описание инструмента: {Specifications}");
        }
        public  void History()
        {
            string History = ReadLine();
            WriteLine($"История создания иструмента: {History}");
        }
    }
    class Trombone:Musical_instrument_3
    {
        public Trombone(string name, string har)
        {
            Name = name;
            Specifications = har;
        }
        public  void Sound()
        {
            WriteLine($"*звуки тромбона*\n\t виуивуиуив");
        }
        public  void Show()
        {
            WriteLine($"Название инструмента: {Name}");
        }
        public  void Desc()
        {
            WriteLine($"Описание инструмента: {Specifications}");
        }
        public  void History()
        {
           string History = ReadLine();
            WriteLine($"История создания иструмента: {History}");
        }
    }
    class Ukulele:Musical_instrument_3
    {
        public Ukulele(string name, string har)
        {
            Name = name;
            Specifications = har;
        }
        public  void Sound()
        {
            WriteLine($"*звуки укулеле*\n\t тинтинтнитнтииииии");
        }
        public  void Show()
        {
            WriteLine($"Название инструмента: {Name}");
        }
        public  void Desc()
        {
            WriteLine($"Описание инструмента: {Specifications}");
        }
        public  void History()
        {
            string History = ReadLine();
            WriteLine($"История создания иструмента: {History}");
        }
    }
    class Cello:Musical_instrument_3
    {
        public Cello(string name, string har)
        {
            Name = name;
            Specifications = har;
        }
        public  void Sound()
        {
            WriteLine($"*звуки виолончели*\n\t пааампампаааапапам");
        }
        public void Show()
        {
            WriteLine($"Название инструмента: {Name}");
        }
        public void Desc()
        {
            WriteLine($"Описание инструмента: {Specifications}");
        }
        public void History()
        {
            string History = ReadLine();
            WriteLine($"История создания иструмента: {History}");
        }
    }
}
