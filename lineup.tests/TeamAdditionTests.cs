using LineUp.Core;
using LineUp.Lib;
using LineUp.Tests.Mock;
using System;
using Xunit;

namespace LineUp.Tests
{
    public class TeamAdditionTests
    {
        private Club club;
        private TeamDataStore teamDataStore;        

        public TeamAdditionTests()
        {
            teamDataStore = new TeamDataStore();
            club = new ClubOffice(teamDataStore, teamDataStore);
            club.Guid = Guid.NewGuid();
        }

        [Fact]
        public void TeamCannotBeNull()
        {            
            Assert.Throws<ArgumentNullException>(() => club.AddTeam(null));
        }

        [Fact]
        public void TeamMustHaveValidName()
        {
            Team team = new TeamSquad();
            Assert.Throws<IllegalOperationException>(() => club.AddTeam(team));
        }

        [Fact]
        public void TeamMustHaveValidGuid()
        {
            Team team = new TeamSquad(Guid.Empty) { Name = "U10" };
            Assert.Throws<IllegalOperationException>(() => club.AddTeam(team));
        }

        [Fact]
        public void TeamNameMustBeUnique()
        {
            Team team1 = new TeamSquad() { Name = "U10" };
            club.AddTeam(team1);
            Team team2 = new TeamSquad() { Name = "U10" };
            Assert.Throws<IllegalOperationException>(() => club.AddTeam(team2));
        }

        [Fact]
        public void TeamWithValidNameAndGuidCanBeAdded()
        {
            Team team = new TeamSquad() { Name = "U10" };
            club.AddTeam(team);
        }

    }
}