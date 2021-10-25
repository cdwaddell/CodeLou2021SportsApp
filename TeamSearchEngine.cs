using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

namespace SportApp
{
    internal class TeamSearchEngine
    {
        public TeamSearchEngine()
        {
        }

        private List<Team> AllTeams { get; set; }

        internal void Initialize()
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://www.thesportsdb.com/api/v1/json/1/");
                var teamJson = client.GetStringAsync("search_all_teams.php?l=NFL").Result;
                var result = JsonSerializer.Deserialize<TeamQueryResult>(teamJson);
                AllTeams = result.teams;
            }
        }

        internal List<Team> GetAllTeams()
        {
            return AllTeams;
        }

        internal List<Team> SearchTeams(string searchTerm)
        {
            return AllTeams.Where(t => t.strTeam.Contains(searchTerm)).ToList();
        }
    }
}