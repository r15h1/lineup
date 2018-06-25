using LineUp.Core;
using LineUp.Lib.Commands;
using LineUp.Tests.Mock;
using System;
using Xunit;

namespace LineUp.Tests {
	public class TeamAdditionTests
    {
        private readonly ClubCommandFactory clubCommandFactory;
        private readonly TeamDataStore teamDataStore;
		private readonly Club club;

		public TeamAdditionTests()
        {
            teamDataStore = new TeamDataStore();
            clubCommandFactory = new ClubCommandFactory(teamDataStore, teamDataStore);
			club = new Club(Guid.NewGuid(), clubCommandFactory);
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
            Team team = new Team(club.Guid) { Name = name };
            Assert.Throws<LineUpException>(() => club.AddTeam(team));
        }

		[Fact]
        public void TeamMustHaveValidGuid()
        {
            Team team = new Team(club.Guid, Guid.Empty) { Name = "U10" };
            Assert.Throws<LineUpException>(() => club.AddTeam(team));
        }

        [Theory]
		[InlineData("ABCD")]
		[InlineData("abcd")]
		[InlineData("Abcd ")]
		[InlineData(" abCD ")]
		public void TeamNameMustBeUnique(string name)
        {
			Team team1 = new Team(club.Guid) { Name = "ABCD" };
			club.AddTeam(team1);
            Team team2 = new Team(club.Guid) { Name = name };
            Assert.Throws<LineUpException>(() => club.AddTeam(team2));
        }

		[Fact]
        public void TeamWithValidNameAndGuidCanBeAdded()
        {
            Team team = new Team(club.Guid, Guid.NewGuid()) { Name = "U10" };
			club.AddTeam(team);
        }
    }
}