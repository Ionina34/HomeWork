using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul5
{
    class Shop
    {
        public string Name { get; set; } = "Без названия";
        public string Adress { get; set; } = "Адрес неизвестен";
        public string Description { get; set; } = "Описание не добавили";
        public string Phone { get; set; } = "Номер телефона не известен";
        public string Email { get; set; } = "Почту не завели";
        public double Square { get; set; }=0;

        public static Shop operator +(Shop w, int num)
        {
            return new Shop { Square = w.Square + num };
        }
        public static Shop operator -(Shop w, int num)
        {
            return new Shop { Square = w.Square + num };
        }
        public static bool operator ==(Shop w, Shop s)
        {
            if (w.Square == s.Square)
                return true;
            else return false;
        }
        public static bool operator !=(Shop w, Shop s)
        {
            return !w.Square.Equals(s.Square);
        }
        public static bool operator <(Shop w, Shop s)
        {
            if (w.Square < s.Square)
                return true;
            else return false;
        }
        public static bool operator >(Shop w, Shop s)
        {
            if (w.Square > s.Square)
                return true;
            else return false;
        }

        public void Print()
        {
            Write($"Название магазина: {Name}" +
                $"Адрес магазина: {Adress}" +
                $"Описание магазина {Description}: " +
                $"Номер телефона магазина: {Phone}" +
                $"E-mail: {Email}" +
                $"Площадь магазина: {Square} м.кв");
        }
        public override bool Equals(object obj)
        {
            Shop shop = (Shop)obj;
            return (Square == shop.Square);
        }

    }
}
