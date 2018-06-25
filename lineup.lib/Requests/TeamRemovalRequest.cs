using FluentValidation;
using LineUp.Core;
using System;
using System.Linq;

namespace LineUp.Lib.Requests {
	public class TeamRemovalRequest : AbstractValidator<TeamRemovalRequest>, IRequest {
		public TeamRemovalRequest() {
			RuleFor(r => r.ClubGuid).NotEqual(Guid.Empty).WithMessage("Club guid cannot be empty");
			RuleFor(r => r.TeamGuid).NotEqual(Guid.Empty).WithMessage("Team guid cannot be empty");
		}
		public Guid ClubGuid { get; set; }
		public Guid TeamGuid { get; set; }
		public void Validate() {
			var result = Validate(this);
			if (!result.IsValid) throw new LineUpException(result.Errors.Select(e => e.ErrorMessage));
		}
	}
}
