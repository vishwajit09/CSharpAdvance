using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic2
{
    internal class SportLeague<T> where T : Teams
    {
        private List<Teams> teams = new();

        public void AddTeam(T team)
        {
            teams.Add(team);
        }

        public void printTeam()
        {
            foreach (var team in teams)
            {

                Console.WriteLine(team.Name);
            }
        }
    }
}
