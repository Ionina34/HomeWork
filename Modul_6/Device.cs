using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul_6
{
     class Device
    {
        protected string Name; //Название устройства
        protected string Specifications; //Хар-ка

        public Device(string name,  string har)
        {
            Name = name;
            Specifications = har;
        }

        public override string ToString()
        {
            return ($"Название устройства: {Name}\n" +
                $"Характеристика: {Specifications}");
        }
    }

    class Teapot:Device
    {
        public Teapot(string name, string har) :base(name,har)
        {
            Name = name;
            Specifications = har;
        }
        public void Sound()
        {
            WriteLine("*очень раздражающий свист чайника*\n\t тфиииииииииииии");
        }
        public  void Show()
        {
            WriteLine($"Название стройства: {Name}");
        }
        public  void Desc()
        {
            WriteLine($"Характеристика устройства: {Specifications}");
        }
    }

    class Nuke:Device
    {
        public Nuke(string name, string har):base(name,har)
        {
            Name = name;
            Specifications = har;
        }
        public  void Sound()
        {
            WriteLine($"*звуки приготовления еды*\n\tтыыыыыыыыыыыыыыын пик пик");
        }
        public  void Show()
        {
            WriteLine($"Название стройства: {Name}");

        }
        public  void Desc()
        {
            WriteLine($"Характеристика устройства: {Specifications}");

        }
    }

    class Avto:Device
    {
        public Avto(string name, string har) : base(name, har)
        {
            Name = name;
            Specifications = har;
        }
        public  void Sound()
        {
            WriteLine($"*звуки лихача*\n\tбжиииииииии бжииииии птхххххх");
        }
        public  void Show()
        {
            WriteLine($"Название стройства: {Name}");

        }
        public  void Desc()
        {
            WriteLine($"Характеристика устройства: {Specifications}");

        }
    }

    class Steamboat : Device
    {
        public Steamboat(string name, string har) : base(name, har)
        {
            Name = name;
            Specifications = har;
        }
        public void Sound()
        {
            WriteLine($"*звук морского путешествия*\n\tпииии пиииии жжжжжжжжжжжж");
        }
        public  void Show()
        {
            WriteLine($"Название стройства: {Name}");

        }
        public  void Desc()
        {
            WriteLine($"Характеристика устройства: {Specifications}");

        }
    }

}
