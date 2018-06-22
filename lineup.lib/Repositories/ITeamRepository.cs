using LineUp.Lib.Requests;

namespace LineUp.Lib.Repositories
{
    public interface ITeamRepository
    {
        void AddTeam(TeamAdditionRequest request);
    }
}
