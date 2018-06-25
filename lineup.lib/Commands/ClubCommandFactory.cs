using LineUp.Core;
using LineUp.Core.Commands;
using LineUp.Lib.Queries;
using LineUp.Lib.Repositories;
using LineUp.Lib.Requests;
using System;

namespace LineUp.Lib.Commands {
	public class ClubCommandFactory : IClubCommandFactory {
		private readonly ITeamRepository teamRepository;
		private readonly ITeamQuery teamQuery;

		public ClubCommandFactory(ITeamRepository teamRepository, ITeamQuery teamQuery) {
			this.teamRepository = teamRepository;
			this.teamQuery = teamQuery;
		}

		public ICommand CreateTeamAdditionCommand(Team team) {
			TeamAdditionRequest request = new TeamAdditionRequest();
			request.ClubGuid = team.ClubGuid;
			request.TeamGuid = team.Guid;
			request.TeamName = team.Name?.Trim();
			return new TeamAdditionCommand(request, teamRepository, teamQuery);
		}

		public ICommand CreateTeamRemovalCommand(Team team) {
			TeamRemovalRequest request = new TeamRemovalRequest();
			request.ClubGuid = team.ClubGuid;
			request.TeamGuid = team.Guid;
			return new TeamRemovalCommand(request, teamRepository, teamQuery);
		}
	}
}
