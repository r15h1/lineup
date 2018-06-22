﻿using LineUp.Core;
using LineUp.Lib.Commands;
using LineUp.Lib.Queries;
using LineUp.Lib.Repositories;
using LineUp.Lib.Requests;
using System;

namespace LineUp.Lib
{
    public class ClubOffice : Club
    {
        private readonly ITeamRepository teamRepository;
        private readonly ITeamQuery teamQuery;

        public ClubOffice(ITeamRepository teamRepository, ITeamQuery teamQuery)
        {
            this.teamRepository = teamRepository;
            this.teamQuery = teamQuery;
        }

        public override ICommand GetTeamAdditionCommand(Team team)
        {
            TeamAdditionRequest request = new TeamAdditionRequest();
            request.ClubGuid = Guid;
            request.TeamGuid = team.Guid;
            request.TeamName = team.Name;

            return new TeamAdditionCommand(request, teamRepository, teamQuery);
        }

        public override ICommand GetTeamRemovalCommand(Team team)
        {
            throw new NotImplementedException();
        }
    }
}