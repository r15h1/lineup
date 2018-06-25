using LineUp.Core.Commands;
using LineUp.Core.Extensions;
using System;

namespace LineUp.Core
{
    public class Team
    {
		public Team(Guid clubGuid) {
			Initialize(clubGuid, Guid.NewGuid());
		}		
		
		public Team(Guid clubGuid, Guid teamGuid)
        {
			Initialize(clubGuid, teamGuid);
		}
		private void Initialize(Guid clubGuid, Guid guid) {
			this.ClubGuid = clubGuid;
			this.Guid = guid;
		}

		public Guid ClubGuid { get; private set; }
		public Guid Guid { get; private set; }
        public string Name { get; set; }

        public void AddPlayer(Player player)
        {
            //Ensure.ArgumentNotNull(player);
            //ICommand playerAdditionCommand = CreatePlayerAdditionCommand(player);
            //playerAdditionCommand.Execute();
        }

		public void AddCoach(Coach coach) {
			//Ensure.ArgumentNotNull(coach);
			//ICommand coachAdditionCommand = CreateCoachAdditionCommand(coach);
			//coachAdditionCommand.Execute();
		}
    }
}