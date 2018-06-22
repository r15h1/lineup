using LineUp.Core;
using LineUp.Core.Extensions;
using LineUp.Lib;
using LineUp.Lib.Queries;
using LineUp.Lib.Repositories;
using LineUp.Lib.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LineUp.Tests.Mock
{
    public class TeamDataStore : ITeamRepository, ITeamQuery
    {
        private Dictionary<Guid, List<Team>> teams = new Dictionary<Guid, List<Team>>();
        public void AddTeam(TeamAdditionRequest request)
        {
            Team team = new TeamSquad(request.TeamGuid) { Name = request.TeamName };
            if (teams.ContainsKey(request.ClubGuid))
                teams[request.ClubGuid].Add(team);
            else
                teams.Add(request.ClubGuid, new List<Team> { team });                            
        }

        public Team GetTeam(Guid clubGuid, Guid teamGuid)
        {
            if(teams.ContainsKey(clubGuid))
                return teams[clubGuid].SingleOrDefault(t => t.Guid == teamGuid);

            return null;
        }

        public bool IsTeamNameTaken(Guid clubGuid, string teamName)
        {            
            if (!teamName.IsEmpty() && teams.ContainsKey(clubGuid))
            {
                return teams[clubGuid].Any(t => t.Name.ToLowerInvariant().Equals(teamName.ToLowerInvariant()));
            }
            return false;
        }
    }
}
