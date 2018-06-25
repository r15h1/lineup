using LineUp.Core;
using LineUp.Core.Commands;
using LineUp.Lib.Queries;
using LineUp.Lib.Repositories;
using LineUp.Lib.Requests;
using System.Collections.Generic;

namespace LineUp.Lib.Commands {
	public class TeamRemovalCommand : ICommand
    {
        private readonly ITeamRepository teamRepository;
        private readonly ITeamQuery teamQuery;
        private readonly TeamRemovalRequest request;

        public TeamRemovalCommand(TeamRemovalRequest request, ITeamRepository teamRepository, ITeamQuery teamQuery)
        {
            this.request = request;
            this.teamRepository = teamRepository;
            this.teamQuery = teamQuery;
        }

        public IRequest Request { get => request; }

        public void Execute()
        {
            request.Validate();
            TeamShouldExist();
            teamRepository.RemoveTeam(request);
        }
		
        private void TeamShouldExist()
        {
            Team team = teamQuery.GetTeam(request.ClubGuid, request.TeamGuid);
            if (team == null)
                throw new LineUpException(new List<string> { "This team does not exist" });
        }
    }
}