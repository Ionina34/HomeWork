using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul_6
{
    class Money_1
    {
        public int whole_piece; //целая часть денег
        public int kop; //копейки
        public string money;//валюта

        public Money_1()
        {
            Write("Введите вылюту: "); money = ReadLine();
            Write("Введите целую часть: "); whole_piece = int.Parse(ReadLine());
            Write("Введите копейки: "); kop = int.Parse(ReadLine());
            if (kop >= 100) whole_piece += kop / 100;
            kop %= 100;
        }

        public Money_1(int wp, int k, string mon)
        {
            whole_piece = wp;
            if (k >= 100) whole_piece += k / 100;
            kop = k % 100;
            money = mon;
        }

        public void Print()
        {
            WriteLine($"У вас {whole_piece},{kop} {money}");
        }
    }

    class Product : Money_1
    {
        string product;//Продукт 
        public Product(string name, int wp, int k, string mon) : base(wp, k, mon)
        {
            product = name;
        }
        public void Reduce_the_price(Money_1 b)
        {
            try
            {
                if (this.money != b.money) throw new Exception("Разная валюта");
                else
                {
                    if (b.whole_piece > this.whole_piece) this.whole_piece = 0;
                    else
                    {
                        if (b.kop > this.kop)
                        {
                            this.whole_piece = this.whole_piece - b.whole_piece - 1;
                            this.kop = 100 - (b.kop - this.kop);
                        }
                        else
                        {
                            this.whole_piece = this.whole_piece - b.whole_piece;
                            this.kop = (this.kop - b.kop)/100;
                        }
                    }
                }
            }
            catch (Exception e)
            { WriteLine(e.Message); }
        }

        public void Print()
        {
            WriteLine($"Продукт: {product} стоит  {whole_piece},{kop} {money}");
        }

    }
}
