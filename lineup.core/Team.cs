using LineUp.Core.Extensions;
using System;

namespace LineUp.Core
{
    public abstract class Team
    {
        public Team(Guid clubGuid)
        {
			ClubGuid = clubGuid;
			Guid = Guid.NewGuid();
        }
        public Team(Guid clubGuid, Guid teamGuid)
        {
			ClubGuid = clubGuid;
            Guid = teamGuid;
        }
		public Guid ClubGuid { get; }
		public Guid Guid { get; }
        public string Name { get; set; }
        public void AddPlayer(Player player)
        {
            Ensure.ArgumentNotNull(player);
            ICommand playerAdditionCommand = CreatePlayerAdditionCommand(player);
            playerAdditionCommand.Execute();
        }

		public void AddCoach(Coach coach) {
			Ensure.ArgumentNotNull(coach);
			ICommand coachAdditionCommand = CreateCoachAdditionCommand(coach);
			coachAdditionCommand.Execute();
		}

		public abstract ICommand CreateCoachAdditionCommand(Coach coach);
		public abstract ICommand CreatePlayerAdditionCommand(Player player);
    }
}