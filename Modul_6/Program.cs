using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul_6
{
    class Program
    {
        static void Main(string[] args)
        {
            //1)
#if false
            Money money = new Money(14, 653, "доллар");
            money.Print();

            Money m = new Money();
            m.Print();

            Product product = new Product("poh", 56, 4, "доллар");
            product.Print();

            product.Reduce_the_price(new Money(32, 30, "доллар"));
            product.Print(); 
#endif
            //2)
#if false
            Teapot teapot = new Teapot("A100", "very Cool");
            teapot.Sound();
            teapot.Show();
            teapot.Desc();

            Nuke nuke = new Nuke("s345", "кипит");
            nuke.Sound();
            nuke.Show();
            nuke.Desc();

            Avto avto = new Avto("SportCar", "nice");
            avto.Sound();
            avto.Show();
            avto.Desc();

            Steamboat steamboat = new Steamboat("Titanic", "утонул");
            steamboat.Sound();
            steamboat.Show();
            steamboat.Desc(); 
#endif

            President president = new President("John","Johan",new DateTime(1987,2,23),2345.77);
            president.Print();
            WriteLine();

            Security security = new Security("Sam","Winchester",new DateTime(2001,11,3),345,"Night");
            security.Print();
            WriteLine();

            Manager manager = new Manager("Dean", "Winchester", new DateTime(1993, 2, 28), 456.7, "A");
            manager.Print();
            WriteLine();

            Engineer engineer = new Engineer("Sally", "Krip", new DateTime(1978, 12, 14), 456.788, 15);
            engineer.Print();

            ReadKey();
        }
    }
}
