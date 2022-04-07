using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul_7
{
    public interface IWorker
    {
        string Name { get; }
    }
    public interface IPart
    {
        void Build(House house);
    }

    public class House
    {
        public Basement basement;
        public List<Walls> walls;
        public Door door;
        public List<Window> windows;
        public Roof roof;

        public void Print(TeamLeader leader)
        {
            if (leader.report.Count == 11)
            {
                string house = @"
   

                                            ~~
                                          (  9 )
                                         (  )   )
                          __            (     9  ) 
                         /  \          (   (   )  )
                        /    \        (  9         )
                       /      \        (     (   9  )
                      /        \      (   )        )
                     /          \    (  )  9   (  )
                    /            \    (    (     )
                  _/______________\_    ( _   __)
                  |                |       | |
                  |    __    __    |       | |
                  |   | .|  |__|   |       | |        
                  |___|__|_________|       | |
             ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";
                WriteLine(house);
            }
            else WriteLine("Дом не достроен");
        }
    }
    public class Basement:IPart
    {
       public void Build(House house)
        {
            house.basement = new Basement();
        }
    }
    public class Walls:IPart
    {
        public void Build(House house)
        {
            house.walls.Add(new Walls());
        }
    }
    public class Door:IPart
    {
        public void Build(House house)
        {
            house.door = new Door();
        }
    }
    public class Window : IPart
    {
        public void Build(House house)
        {
            house.windows.Add(new Window());
        }
    }
    public class Roof:IPart
    {
        public void Build(House house)
        {
            house.roof = new Roof();
        }
    }
    public class Team:IWorker
    {
        public TeamLeader leader;
        public List<Worker> workers;
        public string Name { get => "СуперБригада)"; }
        public Team()
        {
            leader = new TeamLeader("Bobby Singer");
            workers = new List<Worker> { new Worker("Dean Winchester"), new Worker("Sam Winchester"), new Worker("Castiel"),new Worker("Helen Harwell") };
        }
    }
    public class Worker:IWorker
    {
        string Name  {get;set;}
       string IWorker.Name => Name;
        public Worker(string name) => Name = name;
        public void Build(House house , TeamLeader leader)
        {
            if(house.basement == null)
            {
                Basement basement = new Basement();
                basement.Build(house);
                leader.report.Add($"Рабочий {Name} построил фундамент");
            }
            else if(house.walls == null||house.walls.Count<4)
            {
                if (house.walls == null) house.walls = new List<Walls>();
                Walls walls = new Walls();
                walls.Build(house);
                leader.report.Add($"Рабочий {Name} построил {house.walls.Count} стены из 4");
            }
            else if (house.door == null)
            {
                Door door = new Door();
                door.Build(house);
                leader.report.Add($"Рабочий {Name} поставил дверь на место");
            }
            else if(house.windows == null|| house.windows.Count<4)
            {
                if (house.windows == null) house.windows = new List<Window>();
                Window window = new Window();
                window.Build(house);
                leader.report.Add($"Рабочий {Name} поставил на место {house.windows.Count} окна из 4 ");
            }
            else if (house.roof==null)
            {
                Roof roof = new Roof();
                roof.Build(house);
                leader.report.Add($"Рабочий {Name} посторил крышу");
            }
        }
    }
    public class TeamLeader:IWorker
    {
        string Name { get; set; }
        string IWorker.Name => Name;
        public List<string> report = new List<string>();
        public TeamLeader(string name) => Name = name;
        public void Report()
        {
            WriteLine($"{(int)((report.Count / 11.0) * 100)} % работы проделано");
        }
    }
}

