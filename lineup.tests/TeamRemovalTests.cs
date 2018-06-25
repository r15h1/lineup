using LineUp.Core;
using LineUp.Lib.Commands;
using LineUp.Tests.Mock;
using System;
using Xunit;

namespace LineUp.Tests {
	public class TeamRemovalTests
    {
		private readonly ClubCommandFactory clubCommandFactory;
		private readonly TeamDataStore teamDataStore;
		private readonly Club club;

		public TeamRemovalTests() {
			teamDataStore = new TeamDataStore();
			clubCommandFactory = new ClubCommandFactory(teamDataStore, teamDataStore);
			club = new Club(Guid.NewGuid(), clubCommandFactory);
		}

		[Fact]
		public void TeamCannotBeNull() {
			Assert.Throws<ArgumentNullException>(() => club.RemoveTeam(null));
		}

		[Fact]
		public void TeamMustHaveValidGuid() {
			Team team = new Team(club.Guid, Guid.Empty) { Name = "U10" };
			Assert.Throws<LineUpException>(() => club.RemoveTeam(team));
		}

		[Fact]
		public void ValidTeamCanBeRemoved() {
			Team team1 = new Team(club.Guid, Guid.NewGuid()) { Name = "U10" };
			Team team2 = new Team(club.Guid, Guid.NewGuid()) { Name = "U11" };
			Team team3 = new Team(club.Guid, Guid.NewGuid()) { Name = "U12" };

			club.AddTeam(team1);
			club.AddTeam(team2);
			club.AddTeam(team3);
			Assert.True(teamDataStore.GetTeamCount(club.Guid) == 3);

			club.RemoveTeam(team2);
			Assert.True(teamDataStore.GetTeamCount(club.Guid) == 2);
			Assert.Null(teamDataStore.GetTeam(club.Guid, team2.Guid));
		}

		[Fact]
		public void InexistentTeamRemovalFails() {
			Team team1 = new Team(club.Guid, Guid.NewGuid()) { Name = "U10" };
			Team team2 = new Team(club.Guid, Guid.NewGuid()) { Name = "U11" };
			Team team3 = new Team(club.Guid, Guid.NewGuid()) { Name = "U12" };

			club.AddTeam(team1);
			club.AddTeam(team2);
			club.AddTeam(team3);
			Assert.True(teamDataStore.GetTeamCount(club.Guid) == 3);

			var inexistentTeam = new Team(club.Guid, Guid.NewGuid());
			Assert.Throws<LineUpException>(() => club.RemoveTeam(inexistentTeam));			
		}
	}
}