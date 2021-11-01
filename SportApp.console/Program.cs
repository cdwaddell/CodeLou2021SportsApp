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
                    case 3:
                        return;
                }
            }
        }

        private static void DisplayTeams(List<Team> allTeams)
        {
            if(allTeams.Count == 0)
            {
                Console.WriteLine("No teams found");
            }
            var i = 0;
            foreach(var team in allTeams)
            {
                Console.WriteLine($"{++i}) {team.strTeam}");
            }
        }

        private static string GetTeamSearchTerm()
        {
            while(true)
            {
                Console.WriteLine("Enter a search term:");
                var searchTerm = Console.ReadLine();
                if(!string.IsNullOrWhiteSpace(searchTerm))
                {
                    return searchTerm;
                }else{
                    Console.WriteLine($"Invalid search term {searchTerm}");
                }
            }
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
            Console.WriteLine("3) Exit");
        }
    }
}
