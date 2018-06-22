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

        [Theory]
		[InlineData(null)]
		[InlineData("")]
		[InlineData("  ")]
		public void TeamNameMusBeValid(string name)
        {			
            Team team = new TeamSquad(Guid.NewGuid()) { Name = name };
            Assert.Throws<IllegalOperationException>(() => club.AddTeam(team));
        }

		[Fact]
        public void TeamMustHaveValidGuid()
        {
            Team team = new TeamSquad(club.Guid, Guid.Empty) { Name = "U10" };
            Assert.Throws<IllegalOperationException>(() => club.AddTeam(team));
        }

        [Theory]
		[InlineData("ABCD")]
		[InlineData("abcd")]
		[InlineData("Abcd ")]
		[InlineData(" abCD ")]
		public void TeamNameMustBeUnique(string name)
        {
			Team team1 = new TeamSquad(club.Guid) { Name = "ABCD" };
            club.AddTeam(team1);
            Team team2 = new TeamSquad(club.Guid) { Name = name };
            Assert.Throws<IllegalOperationException>(() => club.AddTeam(team2));
        }

		[Fact]
        public void TeamWithValidNameAndGuidCanBeAdded()
        {
            Team team = new TeamSquad(club.Guid, Guid.NewGuid()) { Name = "U10" };
            club.AddTeam(team);
        }

    }
}