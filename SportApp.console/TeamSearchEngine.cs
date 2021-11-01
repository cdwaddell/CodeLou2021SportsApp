using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text.Json;

namespace SportApp
{
    public class TeamSearchEngine
    {
        public TeamSearchEngine()
        {
        }

        private List<Team> AllTeams { get; set; }

        public void Initialize()
        {
            AllTeams = GetAllTeamsFromJson();
            if(AllTeams == null)
            {
                using(var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://www.thesportsdb.com/api/v1/json/1/");
                    var teamJson = client.GetStringAsync("search_all_teams.php?l=NFL").Result;
                    var result = JsonSerializer.Deserialize<TeamQueryResult>(teamJson);
                    AllTeams = result.teams;
                }
                WriteAllTeamsToJson();
            }
        }

        private void WriteAllTeamsToJson()
        {
            string filePath = GetJsonFilePath();
            var teamJson = JsonSerializer.Serialize(AllTeams);
            File.WriteAllText(filePath, teamJson);
        }

        private List<Team> GetAllTeamsFromJson()
        {
            string filePath = GetJsonFilePath();
            if(File.Exists(filePath))
            {
                var teamJson = File.ReadAllText(filePath);
                var result = JsonSerializer.Deserialize<TeamQueryResult>(teamJson);
                return result.teams;
            } else
                return null;
        }

        private static string GetJsonFilePath()
        {
            var location = new Uri(Assembly.GetEntryAssembly().GetName().CodeBase);
            var executingPath = new FileInfo(location.AbsolutePath).Directory.FullName;
            var filePath = Path.Combine(executingPath, "..", "..", "..", "teams.json");
            return filePath;
        }

        public List<Team> GetAllTeams()
        {
            return AllTeams;
        }

        public List<Team> SearchTeams(string searchTerm)
        {
            return AllTeams.Where(t => t.strTeam.Contains(searchTerm)).ToList();
        }
    }
}