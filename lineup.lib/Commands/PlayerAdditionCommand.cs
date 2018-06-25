using System;
using System.Collections.Generic;
using LineUp.Core;
using LineUp.Core.Commands;
using LineUp.Lib.Queries;
using LineUp.Lib.Repositories;
using LineUp.Lib.Requests;

namespace LineUp.Lib.Commands {
	public class PlayerAdditionCommand : ICommand {
		private readonly PlayerAdditionRequest request;
		private readonly IMemberRepository memberRepository;
		private readonly IMemberQuery memberQuery;

		public PlayerAdditionCommand(PlayerAdditionRequest request, IMemberRepository memberRepository, IMemberQuery memberQuery)
		{
			this.request = request;
			this.memberRepository = memberRepository;
			this.memberQuery = memberQuery;
		}
		
		public IRequest Request => request;

		public void Execute() {
			request.Validate();
			TeamShouldBelongToClub(request.ClubGuid, request.TeamGuid);
			PlayerGuidShouldBeUnique();			
			PlayerShouldBeAboveAge(5);
			memberRepository.AddPlayer(request);
		}

		private void TeamShouldBelongToClub(Guid clubGuid, Guid teamGuid) {
			throw new NotImplementedException();
		}

		private void PlayerShouldBeAboveAge(int minimumAge) {
			throw new NotImplementedException();
		}

		private void PlayerGuidShouldBeUnique() {
			var member = memberQuery.GetMember(request.ClubGuid, request.PlayerGuid);
			if (member != null)
				throw new LineUpException(new List<string> { "Another member already has this guid" });
		}
	}
}
