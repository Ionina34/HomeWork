using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul_7
{
    class Program
    {
        static void Main(string[] args)
        {
            House house = new House();
            Team team = new Team();
            Worker worker = new Worker("df");
            WriteLine(team.Name);

            Random rand = new Random();

            for(int i=0;i<3;i++)
            {
              team.workers[rand.Next(0,4)].Build(house, team.leader);
            }
            foreach (var i in team.leader.report)
                WriteLine(i);

            team.leader.Report();
            WriteLine();
            /////////////////////////////////////////////////////////////////////
            for (int i = 0; i < 5; i++)
            {
                team.workers[rand.Next(0, 4)].Build(house, team.leader);
            }
            foreach (var i in team.leader.report)
                WriteLine(i);

            team.leader.Report();
            WriteLine();
            ///////////////////////////////////////////////////////////////////
            for (int i = 0; i < 3; i++)
            {
                team.workers[rand.Next(0, 4)].Build(house, team.leader);
            }
            foreach (var i in team.leader.report)
                WriteLine(i);

            team.leader.Report();
            WriteLine();

            house.Print(team.leader);

            ReadKey();
        }
    }
}
