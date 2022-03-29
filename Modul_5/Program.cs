using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul5
{
    class Program
    {
        static void Main(string[] args)
        {

            List_of_books_to_read s = new List_of_books_to_read(new[]
            {
                new Book("sdg","srgdg"),
                new Book("qwer","xcv"),
                new Book("ghjk","op")
            }) ;

            s.Print();
            WriteLine();

            s.AddBooks();
            s.Print();

            s.Remove();
            s.Print();

            WriteLine();
            try
            {
                WriteLine($"Поиск по названию: {s["sdg"]}");
                WriteLine($"Поиск по автору: {s["xcv"]}");
            }
            catch(Exception e)
            {
                WriteLine(e.Message);
            }

            ReadKey();
        }
    }
}
