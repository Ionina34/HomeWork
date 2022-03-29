using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul5
{
    class Book
    {
        public string Name { get; set; }// Название книги
        public string Author { get; set; }// Автор книги 
        public Book(string name, string author)
        {
            Name = name;
            Author = author;
        }
        public override string ToString()
        {
            return $"{Name} {Author}";
        }
    }
    class List_of_books_to_read
    {
        Book[] books;
        public List_of_books_to_read(Book[] book) => books = book;

        public void Print()
        {
            for (int i = 0; i < books.Length; i++)
            {
                WriteLine($"{i + 1}. {books[i].Name} {books[i].Author}");
            }
        }

        public void AddBooks()
        {
            Clear();
            Write("Введите названиие книги: ");
            string name = ReadLine();
            Write("Введите название автора: ");
            string author = ReadLine();
            Book book = new Book(name, author);

            try
            {
                for (int i = 0; i < books.Length; i++)
                {
                    if (books[i].Name == name && books[i].Author == author)
                        throw new Exception("Такая книга уже есть в списке");
                }

                Clear();
                WriteLine("Новый список книг: ");
                Book[] b = new Book[books.Length + 1];
                for (int i = 0; i < books.Length; i++)
                {
                    b[i] = books[i];
                }
                b[b.Length - 1] = book;
                books = b;
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
        }

        public void Remove()
        {
            try
            {
                Write("Введите названиие книги которую хотите удалить из списка: ");
                string name = ReadLine();
                Write("Введите название автора которую хотите удалить из списка: ");
                string author = ReadLine();
                Book book = new Book(name, author);

                Book[] b = new Book[books.Length - 1];
                int index = 0;

                for (int i = 0; i < books.Length; i++)
                {
                    if (books[i].Name == book.Name && books[i].Author == book.Author)
                        index = i;
                    else throw new Exception("Такой книги в списке нет");
                }
                for (int i = 0; i < index; i++)
                {
                    b[i] = books[i];
                }
                for (int i = index + 1; i < books.Length; i++)
                {
                    b[i - 1] = books[i];
                }
                books = b;
            }
            catch(Exception e)
            {
                WriteLine(e.Message);
            }
        }

        public Book this[string Name]
        {
            get
            {
                return books[(int)PoiskName(Name)];
            }
            set
            {
                books[(int)PoiskName(Name)] = value;
            }
        }
        public int PoiskName(string Name)
        {
            for(int i=0;i<books.Length;i++)
            {
                if ( books[i].Author == Name|| books[i].Name == Name)
                    return i;
                else throw new Exception("Такой книги в списке нет");
            }
            return -1;
        }
        
        
    }
}
