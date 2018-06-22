using LineUp.Core;
using System;

namespace LineUp.Lib.Queries
{
    public interface ITeamQuery
    {
        Team GetTeam(Guid clubGuid, Guid teamGuid);
        bool IsTeamNameTaken(Guid clubGuid, string teamName);
    }
}