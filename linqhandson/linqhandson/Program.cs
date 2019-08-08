using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linqhandson
{
    class Program
    {
        static void Main(string[] args)
        {
            #region My code
            List<Player> players = new List<Player> { new Player { PlayerId=01,Name="Ajay", Score=45},
                                                    new Player{ PlayerId=02,Name="swizzy",Score=50},
                                                    new Player{PlayerId=03,Name="kate",Score=60}};
            List<Player> players1 = new List<Player> { new Player { PlayerId=04,Name="Ajit", Score=65},
                                                    new Player{ PlayerId=05,Name="sawali",Score=50},
                                                    new Player{PlayerId=06,Name="jay",Score=70}};
            List<Player> players2 = new List<Player> { new Player { PlayerId=07,Name="Wasali", Score=45},
                                                    new Player{ PlayerId=08,Name="Jhunjhun",Score=50},
                                                    new Player{PlayerId=09,Name="ray",Score=60}};
            List<Player> players3 = new List<Player> { new Player { PlayerId=10,Name="Bosco", Score=45},
                                                    new Player{ PlayerId=11,Name="Bipin",Score=50},
                                                    new Player{PlayerId=12,Name="Shen",Score=80}};
            List<Team> teams = new List<Team> { new Team { TeamCode = "KZ01", Players = players },
                                                new Team{TeamCode="KZ02",Players=players1 } };
            List<Team> teams1 = new List<Team> { new Team { TeamCode = "KZ03", Players = players2 },
                                                new Team{TeamCode="KZ04",Players=players3 } };
            List<League> leagues = new List<League> { new League { LeagueName = "Knight Riders", Teams = teams },
                                                        new League{LeagueName="Mash outs", Teams=teams1 } };
            //List<Team> retrievedTeam = leagues.SelectMany(l => l.Teams); This doesn't work since parent(IEnumerable) cannot be assigned to a child(List)
            IEnumerable<Team> retrievedTeams = leagues.SelectMany(l => l.Teams);
            foreach (var team in retrievedTeams)
            {
                Console.WriteLine(team.TeamCode);
                Console.WriteLine(team.Players);
            }

            //IEnumerable<Team> retrievedTeams = leagues.SelectMany((l, i) => new { index = i,l });
            //foreach (var team in retrievedTeams)
            //{
            //    Console.WriteLine(team.TeamCode);
            //    Console.WriteLine(team.Players);
            //}

            //leagues.Select(l => l.Teams);
            //IEnumerable<Player> retrievedPlayers = leagues.SelectMany(l => l.Teams).SelectMany(t => t.Players);
            //foreach (var player in retrievedPlayers)
            //{
            //    Console.WriteLine(player.Name);
            //}
            #endregion

            //SelectVsSelectMany();
            Console.ReadLine();
        }
        static void SelectVsSelectMany()
        {
            List<Bouquet> bouquets = new List<Bouquet>() {
        new Bouquet { Flowers = new List<string> { "sunflower", "daisy", "daffodil", "larkspur" }},
        new Bouquet{ Flowers = new List<string> { "tulip", "rose", "orchid" }},
        new Bouquet{ Flowers = new List<string> { "gladiolis", "lily", "snapdragon", "aster", "protea" }},
        new Bouquet{ Flowers = new List<string> { "larkspur", "lilac", "iris", "dahlia" }}
    };

            // *********** Select ***********              
            IEnumerable<List<string>> query1 = bouquets.Select(bq => bq.Flowers);

            // ********* SelectMany *********  
            IEnumerable<string> query2 = bouquets.SelectMany(bq => bq.Flowers);

            Console.WriteLine("Results by using Select():");
            // Note the extra foreach loop here.  
            foreach (IEnumerable<String> collection in query1)
                foreach (string item in collection)
                    Console.WriteLine(item);

            Console.WriteLine("\nResults by using SelectMany():");
            foreach (string item in query2)
                Console.WriteLine(item);

        }
    }

    class Bouquet
    {
        public List<string> Flowers { get; set; }
    }




}



