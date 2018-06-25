using LineUp.Core.Commands;
using LineUp.Core.Extensions;
using System;
using System.Collections.Generic;

namespace LineUp.Core
{
    public class Club
    {
        private List<string> urls = new List<string>();
		private readonly IClubCommandFactory factory;

		public Club(IClubCommandFactory factory) {
			Ensure.ArgumentNotNull(factory);
			this.Guid = Guid.NewGuid();
			this.factory = factory;
		}

		public Club(Guid guid, IClubCommandFactory factory) {
			Ensure.ArgumentNotNull(factory);
			Ensure.NotEmpty(guid);
			this.Guid = guid;
			this.factory = factory;
		}

        public Guid Guid { get; }
        public string Name { get; set; }
        public Address Address { get; set; } = new Address();
        public IEnumerable<string> Urls { get => urls; }
        public string LogoUrl { get; set; }

        public void AddUrl(string url)
        {
            if (!url.IsEmpty() && !urls.Contains(url))
                urls.Add(url.ToLowerInvariant().Trim());
        }
               
        public void AddTeam(Team team)
        {
            Ensure.ArgumentNotNull(team);
            ICommand addTeamCommand = factory.CreateTeamAdditionCommand(team);
            addTeamCommand.Execute();
        }

        public void RemoveTeam(Team team)
        {
            Ensure.ArgumentNotNull(team);
            ICommand removeTeamCommand = factory.CreateTeamRemovalCommand(team);
            removeTeamCommand.Execute();
        }  
    }
}