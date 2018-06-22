using LineUp.Core;
using LineUp.Lib.Queries;
using LineUp.Lib.Repositories;
using LineUp.Lib.Requests;
using System;
using System.Collections.Generic;

namespace LineUp.Lib.Commands
{
    public class TeamAdditionCommand : ICommand
    {
        private readonly ITeamRepository teamRepository;
        private readonly ITeamQuery teamQuery;
        private readonly TeamAdditionRequest request;

        public TeamAdditionCommand(TeamAdditionRequest request, ITeamRepository teamRepository, ITeamQuery teamQuery)
        {
            this.request = request;
            this.teamRepository = teamRepository;
            this.teamQuery = teamQuery;
        }

        public IRequest Request { get => request; }

        public void Execute()
        {
            request.Validate();
            TeamGuidShouldBeUnique();
            AvoidDuplicateTeamNames();
            teamRepository.AddTeam(request);
        }

        private void AvoidDuplicateTeamNames()
        {
            bool nameIsTaken = teamQuery.IsTeamNameTaken(request.ClubGuid, request.TeamName);
            if (nameIsTaken)
                throw new IllegalOperationException(new List<string> { "This team exists already" });
        }

        private void TeamGuidShouldBeUnique()
        {
            Team team = teamQuery.GetTeam(request.ClubGuid, request.TeamGuid);
            if (team != null)
                throw new IllegalOperationException(new List<string> { "This team exists already" });
        }
    }
}