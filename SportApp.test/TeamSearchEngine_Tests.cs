using Xunit;
using SportApp;

namespace SportApp.test
{
    public class TeamSearchEngine_Tests
    {
        [Fact]
        public void GetAllTeams_CountCheck(){
            var engine = new TeamSearchEngine();
            engine.Initialize();
            var teams = engine.GetAllTeams();
            Assert.Equal(32, teams.Count);
        }
    }
}
