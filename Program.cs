using System;
using System.Collections.Generic;

namespace SportApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var searchEngine = new TeamSearchEngine();
            searchEngine.Initialize();

            while(true)
            {
                ShowRootMenu();
                var option = GetRootMenuOption();
                switch(option){
                    case 1: 
                        var allTeams = searchEngine.GetAllTeams();
                        DisplayTeams(allTeams);
                        break;
                    case 2:
                        var searchTerm = GetTeamSearchTerm();
                        var matchingTeams = searchEngine.SearchTeams(searchTerm);
                        DisplayTeams(matchingTeams);
                        break;
                }
            }
        }

        private static void DisplayTeams(List<Team> allTeams)
        {
            var i = 0;
            foreach(var team in allTeams)
            {
                Console.WriteLine($"{++i}) {team.strTeam}");
            }
        }

        private static string GetTeamSearchTerm()
        {
            Console.WriteLine("Enter a search term:");
            return Console.ReadLine();
        }

        private static int GetRootMenuOption()
        {
            while(true)
            {
                var input = Console.ReadLine();
                if(Int32.TryParse(input, out var option))
                {
                    return option;
                } else
                {
                    Console.WriteLine($"Invalid Selection {option}");
                }
            }
        }

        private static void ShowRootMenu()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1) List All Teams");
            Console.WriteLine("2) Search Teams by Name");
        }
    }
}
