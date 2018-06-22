using FluentValidation;
using LineUp.Core;
using System;
using System.Linq;

namespace LineUp.Lib.Requests
{
    public class TeamAdditionRequest :AbstractValidator<TeamAdditionRequest>, IRequest
    {
        public TeamAdditionRequest()
        {
            RuleFor(r => r.ClubGuid).NotEqual(Guid.Empty).WithMessage("Club guid cannot be empty");
            RuleFor(r => r.TeamGuid).NotEqual(Guid.Empty).WithMessage("Team guid cannot be empty");
            RuleFor(r => r.TeamName).NotEmpty().WithMessage("Team name cannot be empty");
        }

        public Guid ClubGuid { get; set; }
        public Guid TeamGuid { get; set; }
        public string TeamName { get; set; }

        public void Validate()
        {
            var result = Validate(this);
            if (!result.IsValid) throw new IllegalOperationException(result.Errors.Select(e => e.ErrorMessage));
        }
    }
}
