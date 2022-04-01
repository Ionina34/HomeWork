using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Modul_8
{
    public delegate void Start();
    public delegate void Finish();
    abstract class Car
    {
        public string Name { get; set; }

        public Car(string name) => Name = name;
        public abstract void Win(string name);
        public int SpeedCar(Random rand, int min, int max)
        {
            int speed;
            return speed = rand.Next(min, max);
        }
        public abstract void Drive();

    }
    class Sport_Car : Car
    {
        public event Finish Message;

        public Sport_Car(string name) : base(name) => Name = name;
        public override void Win(string name)
        {
            WriteLine($"{Name} финишировал");
        }
        public void GoToStart()
        {
            WriteLine($"{Name} вышел на старт и готов к гонке");
            Drive();
        }
        public override void Drive()
        {
            int distance = 0;
            Random r = new Random();
            int speed = r.Next(9, 15);
            Message += () => Win(Name);
            for (distance = 0; distance < 115; distance += speed)
            {
                WriteLine($"{Name} прошел расстояние: {distance}");
                if (distance > 100)
                { Message(); break; }

            }
        }
    }
    class Avto : Car
    {
        public event Finish Message;

        public Avto(string name) : base(name) => Name = name;
        public override void Win(string name)
        {
            WriteLine($"{Name} финишировал");
        }
        public void GoToStart()
        {
            WriteLine($"{Name} вышел на старт и готов к гонке");
            Drive();
        }
        public override void Drive()
        {
            int distance = 0;
            Random r = new Random();
            int speed = r.Next(9, 15);
            Message += () => Win(Name);
            for (distance = 0; distance < 115; distance += speed)
            {
                WriteLine($"{Name} прошел расстояние: {distance}");
                if (distance > 100)
                { Message();break; }
            }
        }
    }
    class Truck : Car
    {
        public event Finish Message;

        public Truck(string name) : base(name) => Name = name;
        public override void Win(string name)
        {
            WriteLine($"{Name} финишировал");
        }
        public void GoToStart()
        {
            WriteLine($"{Name} вышел на старт и готов к гонке");
            Drive();
        }
        public override void Drive()
        {
            int distance = 0;
            Random r = new Random();
            int speed = r.Next(9, 15);
            Message += () => Win(Name);
            for (distance = 0; distance < 115; distance += speed)
            {
                WriteLine($"{Name} прошел расстояние: {distance}");
                if (distance > 100)
                { Message(); break; }

            }
        }
    }
    class Bus : Car
    {
        public event Finish Message;

        public Bus(string name) : base(name) => Name = name;
        public override void Win(string name)
        {
            WriteLine($"{Name} финишировал");
        }
        public void GoToStart()
        {
            WriteLine($"{Name} вышел на старт и готов к гонке");
            Drive();
        }
        public override void Drive()
        {
            int distance = 0;
            Random r = new Random();
            int speed = r.Next(9, 15);
            Message += () => Win(Name);
            for (distance = 0; distance < 115; distance += speed)
            {
                WriteLine($"{Name} прошел расстояние: {distance}");
                if (distance > 100)
                { Message(); break; }

            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Sport_Car sport_Car = new Sport_Car("SportCar");
            Bus bus = new Bus("Bus");

            List<Thread> threads = new List<Thread>
            {
               new Thread( sport_Car.GoToStart),
               new Thread( bus.GoToStart),
            };

            foreach (Thread thread in threads)
            { 
                thread.Start();
            }

            ReadKey();
        }
    }
}
