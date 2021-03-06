using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul_4
{
    class Game
    {
        private char[,] _field = new char[3, 3]
        {
            { ' ',' ',' ' },
            { ' ',' ',' ' },
            { ' ',' ',' ' },
        };
        private bool _isXMove = true;

        public Game()
        {
            WriteLine("1 - 1игрок vs 2игрок\n2 - игрок vs компьютера ");
            int v = Int32.Parse(ReadLine());
            Draw();
            int rows, cols;
            switch (v)
            {
                case 1:
                    do
                    {
                        Write("Введите номер ряда: "); rows = int.Parse(ReadLine());
                        Write("Введите номер столбца: "); cols = int.Parse(ReadLine());

                        Update(rows, cols);
                        Draw();
                    } while (true);


                    break;
                case 2:
                    Random rand = new Random();
                    int player = rand.Next(1, 3);
                    if (player == 1)
                    {
                        WriteLine("\nПервым ходит игрок");
                        do
                        {
                            Write("Введите номер ряда: "); rows = int.Parse(ReadLine());
                            Write("Введите номер столбца: "); cols = int.Parse(ReadLine());

                            Player_1(rows, cols);
                            Draw();


                        } while (true);
                    }
                    if (player == 2)
                    {
                        do
                        {
                            Computer1();
                            Draw();

                            Player_2();
                            Draw();
                        } while (true);
                    }

                    break;
            }
        }
        private void Draw()
        {
            Clear();

            WriteLine();
            WriteLine("  0   1   2");
            WriteLine(string.Format("0 {0} | {1} | {2}", _field[0, 0], _field[0, 1], _field[0, 2]));
            WriteLine(" ---+---+---");
            WriteLine(string.Format("1 {0} | {1} | {2}", _field[1, 0], _field[1, 1], _field[1, 2]));
            WriteLine(" ---+---+---");
            WriteLine(string.Format("2 {0} | {1} | {2}", _field[2, 0], _field[2, 1], _field[2, 2]));

        }
        private void Update(int rows, int cols)
        {
            if (0 <= rows && rows <= 2 && 0 <= cols && cols <= 2)
            {
                if (_field[rows, cols] == ' ')
                {
                    _field[rows, cols] = _isXMove ? 'X' : 'O';
                    if (IsWinner('X'))
                    {
                        Draw();
                        EndGame("Крестики");
                    }
                    else if (IsWinner('O'))
                    {
                        Draw();
                        EndGame("Нолики");
                    }
                    else if (_field[0, 0] != ' ' && _field[0, 1] != ' ' && _field[0, 2] != ' '
                         && _field[1, 0] != ' ' && _field[1, 1] != ' ' && _field[1, 2] != ' '
                         && _field[2, 0] != ' ' && _field[2, 1] != ' ' && _field[2, 2] != ' ')
                    {
                        Draw();
                        EndGame1("Ничья");
                    }

                    _isXMove = !_isXMove;
                }
                else WriteLine("Клетка занята!");
            }
        }
        private void Player_1(int rows, int cols)
        {
            if (0 <= rows && rows <= 2 && 0 <= cols && cols <= 2)
            {
                if (_field[rows, cols] == ' ')
                {
                    _field[rows, cols] = 'X';
                }
                else WriteLine("Клетка занята!");

                //Дальше ход делает компьютер:
                Computer();
                Draw();
                Proverka();
            }
        }
        private void Player_2()
        {
            
            Proverka();
            int rows, cols;
            WriteLine("\nПервым ходит компьютер");

            Write("Введите номер ряда: "); rows = int.Parse(ReadLine());
            Write("Введите номер столбца: "); cols = int.Parse(ReadLine());
            //Ход делает игрок
            if (0 <= rows && rows <= 2 && 0 <= cols && cols <= 2)
            {

                if (_field[rows, cols] == ' ')
                {
                    _field[rows, cols] = 'O';
                }
                else WriteLine("Клетка занята!");
            }
            Proverka();
        }
        private void Proverka()
        {
            if (IsWinner('X'))
            {
                Draw();
                EndGame("Крестики");
            }
            else if (IsWinner('O'))
            {
                Draw();
                EndGame("Нолики");
            }
            else if (_field[0, 0] != ' ' && _field[0, 1] != ' ' && _field[0, 2] != ' '
                         && _field[1, 0] != ' ' && _field[1, 1] != ' ' && _field[1, 2] != ' '
                         && _field[2, 0] != ' ' && _field[2, 1] != ' ' && _field[2, 2] != ' ')
            {
                Draw();
                EndGame1("Ничья");
            }
        }
        private void Computer()
        {
            bool hod = false;
            if (_field[1, 1] == ' ') { _field[1, 1] = 'O'; hod = true; }
            if (hod == false)
            { if (_field[0, 0] == ' ') { _field[0, 0] = 'O'; hod = true; } }

            if (hod == false)
            {
                if (_field[0, 0] == 'O' && _field[0, 1] == 'O' && _field[0, 2] == ' ')
                { _field[0, 2] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[0, 0] == 'O' && _field[0, 2] == 'O' && _field[0, 1] == ' ')
                { _field[0, 1] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[0, 1] == 'O' && _field[0, 2] == 'O' && _field[0, 0] == ' ')
                { _field[0, 0] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[0, 0] == 'O' && _field[1, 0] == 'O' && _field[2, 0] == ' ')
                { _field[2, 0] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[0, 0] == 'O' && _field[2, 0] == 'O' && _field[1, 0] == ' ')
                { _field[1, 0] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[1, 0] == 'O' && _field[2, 0] == 'O' && _field[0, 0] == ' ')
                { _field[0, 0] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 0] == 'O' && _field[2, 1] == 'O' && _field[2, 2] == ' ')
                { _field[2, 2] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 0] == 'O' && _field[2, 2] == 'O' && _field[2, 1] == ' ')
                { _field[2, 1] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 1] == 'O' && _field[2, 2] == 'O' && _field[2, 0] == ' ')
                { _field[2, 0] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 2] == 'O' && _field[1, 2] == 'O' && _field[0, 2] == ' ')
                { _field[0, 2] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 2] == 'O' && _field[0, 2] == 'O' && _field[1, 2] == ' ')
                { _field[1, 2] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[1, 2] == 'O' && _field[0, 2] == 'O' && _field[2, 2] == ' ')
                { _field[2, 2] = 'O'; hod = true; }
            }

            if (hod == false)
            {
                if (_field[0, 0] == 'O' && _field[1, 1] == 'O' && _field[2, 2] == ' ')
                { _field[2, 2] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 2] == 'O' && _field[1, 1] == 'O' && _field[0, 0] == ' ')
                { _field[0, 0] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[0, 2] == 'O' && _field[1, 1] == 'O' && _field[2, 0] == ' ')
                { _field[2, 0] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 0] == 'O' && _field[1, 1] == 'O' && _field[0, 2] == ' ')
                { _field[0, 2] = 'O'; hod = true; }
            }

            if (hod == false)
            {
                if (_field[1, 0] == 'O' && _field[1, 1] == 'O' && _field[1, 2] == ' ')
                { _field[1, 2] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[1, 2] == 'O' && _field[1, 1] == 'O' && _field[1, 0] == ' ')
                { _field[1, 0] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[0, 1] == 'O' && _field[1, 1] == 'O' && _field[2, 1] == ' ')
                { _field[2, 1] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 1] == 'O' && _field[1, 1] == 'O' && _field[0, 1] == ' ')
                { _field[0, 1] = 'O'; hod = true; }
            }

            ////////////////////////////////////////////////////////
            if (hod == false)
            {
                if (_field[0, 0] == 'X' && _field[0, 1] == 'X' && _field[0, 2] == ' ')
                { _field[0, 2] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[0, 0] == 'X' && _field[0, 2] == 'X' && _field[0, 1] == ' ')
                { _field[0, 1] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[0, 1] == 'X' && _field[0, 2] == 'X' && _field[0, 0] == ' ')
                { _field[0, 0] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[0, 0] == 'X' && _field[1, 0] == 'X' && _field[2, 0] == ' ')
                { _field[2, 0] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[0, 0] == 'X' && _field[2, 0] == 'X' && _field[1, 0] == ' ')
                { _field[1, 0] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[1, 0] == 'X' && _field[2, 0] == 'X' && _field[0, 0] == ' ')
                { _field[0, 0] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 0] == 'X' && _field[2, 1] == 'X' && _field[2, 2] == ' ')
                { _field[2, 2] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 0] == 'X' && _field[2, 2] == 'X' && _field[2, 1] == ' ')
                { _field[2, 1] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 1] == 'X' && _field[2, 2] == 'X' && _field[2, 0] == ' ')
                { _field[2, 0] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 2] == 'X' && _field[1, 2] == 'X' && _field[0, 2] == ' ')
                { _field[0, 2] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 2] == 'X' && _field[0, 2] == 'X' && _field[1, 2] == ' ')
                { _field[1, 2] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[1, 2] == 'X' && _field[0, 2] == 'X' && _field[2, 2] == ' ')
                { _field[2, 2] = 'O'; hod = true; }
            }

            if (hod == false)
            {
                if (_field[0, 0] == 'X' && _field[1, 1] == 'X' && _field[2, 2] == ' ')
                { _field[2, 2] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 2] == 'X' && _field[1, 1] == 'X' && _field[0, 0] == ' ')
                { _field[0, 0] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[0, 2] == 'X' && _field[1, 1] == 'X' && _field[2, 0] == ' ')
                { _field[2, 0] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 0] == 'X' && _field[1, 1] == 'X' && _field[0, 2] == ' ')
                { _field[0, 2] = 'O'; hod = true; }
            }

            if (hod == false)
            {
                if (_field[1, 0] == 'X' && _field[1, 1] == 'X' && _field[1, 2] == ' ')
                { _field[1, 2] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[1, 2] == 'X' && _field[1, 1] == 'X' && _field[1, 0] == ' ')
                { _field[1, 0] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[0, 1] == 'X' && _field[1, 1] == 'X' && _field[2, 1] == ' ')
                { _field[2, 1] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 1] == 'X' && _field[1, 1] == 'X' && _field[0, 1] == ' ')
                { _field[0, 1] = 'O'; hod = true; }
            }


            if (hod == false)
            { if (_field[2, 2] == ' ') { _field[2, 2] = 'O'; hod = true; } }
            if (hod == false)
            { if (_field[0, 2] == ' ') { _field[0, 2] = 'O'; hod = true; } }
            if (hod == false)
            { if (_field[2, 0] == ' ') { _field[2, 0] = 'O'; hod = true; } }

            if (hod == false)
            { if (_field[2, 1] == ' ') { _field[2, 1] = 'O'; hod = true; } }
            if (hod == false)
            { if (_field[0, 1] == ' ') { _field[0, 1] = 'O'; hod = true; } }
            if (hod == false)
            { if (_field[1, 0] == ' ') { _field[1, 0] = 'O'; hod = true; } }
            if (hod == false)
            { if (_field[1, 2] == ' ') { _field[1, 2] = 'O'; hod = true; } }

        }
        private void Computer1()
        {
            bool hod = false;
            if (_field[1, 1] == ' ') { _field[1, 1] = 'X'; hod = true; }
            if (hod == false)
            { if (_field[0, 0] == ' ') { _field[0, 0] = 'X'; hod = true; } }

            if (hod == false)
            {
                if (_field[0, 0] == 'X' && _field[0, 1] == 'X' && _field[0, 2] == ' ')
                { _field[0, 2] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[0, 0] == 'X' && _field[0, 2] == 'X' && _field[0, 1] == ' ')
                { _field[0, 1] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[0, 1] == 'X' && _field[0, 2] == 'X' && _field[0, 0] == ' ')
                { _field[0, 0] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[0, 0] == 'X' && _field[1, 0] == 'X' && _field[2, 0] == ' ')
                { _field[2, 0] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[0, 0] == 'X' && _field[2, 0] == 'X' && _field[1, 0] == ' ')
                { _field[1, 0] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[1, 0] == 'X' && _field[2, 0] == 'X' && _field[0, 0] == ' ')
                { _field[0, 0] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 0] == 'X' && _field[2, 1] == 'X' && _field[2, 2] == ' ')
                { _field[2, 2] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 0] == 'X' && _field[2, 2] == 'X' && _field[2, 1] == ' ')
                { _field[2, 1] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 1] == 'X' && _field[2, 2] == 'X' && _field[2, 0] == ' ')
                { _field[2, 0] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 2] == 'X' && _field[1, 2] == 'X' && _field[0, 2] == ' ')
                { _field[0, 2] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 2] == 'X' && _field[0, 2] == 'X' && _field[1, 2] == ' ')
                { _field[1, 2] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[1, 2] == 'X' && _field[0, 2] == 'X' && _field[2, 2] == ' ')
                { _field[2, 2] = 'X'; hod = true; }
            }

            if (hod == false)
            {
                if (_field[0, 0] == 'X' && _field[1, 1] == 'X' && _field[2, 2] == ' ')
                { _field[2, 2] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 2] == 'X' && _field[1, 1] == 'X' && _field[0, 0] == ' ')
                { _field[0, 0] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[0, 2] == 'X' && _field[1, 1] == 'X' && _field[2, 0] == ' ')
                { _field[2, 0] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 0] == 'X' && _field[1, 1] == 'X' && _field[0, 2] == ' ')
                { _field[0, 2] = 'X'; hod = true; }
            }

            if (hod == false)
            {
                if (_field[1, 0] == 'X' && _field[1, 1] == 'X' && _field[1, 2] == ' ')
                { _field[1, 2] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[1, 2] == 'X' && _field[1, 1] == 'X' && _field[1, 0] == ' ')
                { _field[1, 0] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[0, 1] == 'X' && _field[1, 1] == 'X' && _field[2, 1] == ' ')
                { _field[2, 1] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 1] == 'X' && _field[1, 1] == 'X' && _field[0, 1] == ' ')
                { _field[0, 1] = 'X'; hod = true; }
            }

            ////////////////////////////////////////////////////////
            if (hod == false)
            {
                if (_field[0, 0] == 'O' && _field[0, 1] == 'O' && _field[0, 2] == ' ')
                { _field[0, 2] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[0, 0] == 'O' && _field[0, 2] == 'O' && _field[0, 1] == ' ')
                { _field[0, 1] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[0, 1] == 'O' && _field[0, 2] == 'O' && _field[0, 0] == ' ')
                { _field[0, 0] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[0, 0] == 'O' && _field[1, 0] == 'O' && _field[2, 0] == ' ')
                { _field[2, 0] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[0, 0] == 'O' && _field[2, 0] == 'O' && _field[1, 0] == ' ')
                { _field[1, 0] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[1, 0] == 'O' && _field[2, 0] == 'O' && _field[0, 0] == ' ')
                { _field[0, 0] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 0] == 'O' && _field[2, 1] == 'O' && _field[2, 2] == ' ')
                { _field[2, 2] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 0] == 'O' && _field[2, 2] == 'O' && _field[2, 1] == ' ')
                { _field[2, 1] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 1] == 'O' && _field[2, 2] == 'O' && _field[2, 0] == ' ')
                { _field[2, 0] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 2] == 'O' && _field[1, 2] == 'O' && _field[0, 2] == ' ')
                { _field[0, 2] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 2] == 'O' && _field[0, 2] == 'O' && _field[1, 2] == ' ')
                { _field[1, 2] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[1, 2] == 'O' && _field[0, 2] == 'O' && _field[2, 2] == ' ')
                { _field[2, 2] = 'X'; hod = true; }
            }

            if (hod == false)
            {
                if (_field[0, 0] == 'O' && _field[1, 1] == 'O' && _field[2, 2] == ' ')
                { _field[2, 2] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 2] == 'O' && _field[1, 1] == 'O' && _field[0, 0] == ' ')
                { _field[0, 0] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[0, 2] == 'O' && _field[1, 1] == 'O' && _field[2, 0] == ' ')
                { _field[2, 0] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 0] == 'O' && _field[1, 1] == 'O' && _field[0, 2] == ' ')
                { _field[0, 2] = 'X'; hod = true; }
            }

            if (hod == false)
            {
                if (_field[1, 0] == 'O' && _field[1, 1] == 'O' && _field[1, 2] == ' ')
                { _field[1, 2] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[1, 2] == 'O' && _field[1, 1] == 'O' && _field[1, 0] == ' ')
                { _field[1, 0] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[0, 1] == 'O' && _field[1, 1] == 'O' && _field[2, 1] == ' ')
                { _field[2, 1] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 1] == 'O' && _field[1, 1] == 'O' && _field[0, 1] == ' ')
                { _field[0, 1] = 'X'; hod = true; }
            }


            if (hod == false)
            { if (_field[2, 2] == ' ') { _field[2, 2] = 'X'; hod = true; } }
            if (hod == false)
            { if (_field[0, 2] == ' ') { _field[0, 2] = 'X'; hod = true; } }
            if (hod == false)
            { if (_field[2, 0] == ' ') { _field[2, 0] = 'X'; hod = true; } }

            if (hod == false)
            { if (_field[2, 1] == ' ') { _field[2, 1] = 'X'; hod = true; } }
            if (hod == false)
            { if (_field[0, 1] == ' ') { _field[0, 1] = 'X'; hod = true; } }
            if (hod == false)
            { if (_field[1, 0] == ' ') { _field[1, 0] = 'X'; hod = true; } }
            if (hod == false)
            { if (_field[1, 2] == ' ') { _field[1, 2] = 'X'; hod = true; } }

        }

        private bool IsWinner(char player)
        {
            return
                (
                //Rows: 
                (_field[0, 0] == player && _field[0, 1] == player && _field[0, 2] == player) ||
                (_field[1, 0] == player && _field[1, 1] == player && _field[1, 2] == player) ||
                (_field[2, 0] == player && _field[2, 1] == player && _field[2, 2] == player) ||
                //Cols:
                (_field[0, 0] == player && _field[1, 0] == player && _field[2, 0] == player) ||
                (_field[0, 1] == player && _field[1, 1] == player && _field[2, 1] == player) ||
                (_field[0, 2] == player && _field[1, 2] == player && _field[2, 2] == player) ||
                //Diagonal:
                (_field[0, 0] == player && _field[1, 1] == player && _field[2, 2] == player) ||
                (_field[0, 2] == player && _field[1, 1] == player && _field[2, 0] == player)
                );
        }
        private void EndGame(string player)
        {
            WriteLine($"Победили {player}!");
            ReadKey();
            ClearField();
        }
        private void EndGame1(string player)
        {
            WriteLine($"Ничья!");
            ReadKey();
            ClearField();
        }

        private void ClearField()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _field[i, j] = ' ';
                }
            }
        }
    }
}
