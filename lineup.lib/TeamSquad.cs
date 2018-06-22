using LineUp.Core;
using LineUp.Lib.Commands;
using LineUp.Lib.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace LineUp.Lib
{
    public class TeamSquad : Team
    {        
        public TeamSquad(Guid clubGuid) : base(clubGuid) { }
		public TeamSquad(Guid clubGuid, Guid teamGuid) : base(clubGuid, teamGuid) { }

		public override ICommand CreateCoachAdditionCommand(Coach coach) {
			throw new NotImplementedException();
		}

		public override ICommand CreatePlayerAdditionCommand(Player player) {
			PlayerAdditionRequest request = new PlayerAdditionRequest();

			return new PlayerAdditionCommand(request, null, null);
		}
	}
}
