using LineUp.Core.Extensions;
using System;
using System.Collections.Generic;

namespace LineUp.Core
{
    public abstract class Club
    {
        private List<string> urls = new List<string>();

        public Guid Guid { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; } = new Address();
        public IEnumerable<string> Urls { get => urls; }
        public string LogoUrl { get; set; }

        public void AddUrl(string url)
        {
            if (!urls.Contains(url))
                urls.Add(url);
        }
               
        public void AddTeam(Team team)
        {
            Ensure.ArgumentNotNull(team);
            ICommand addTeamCommand = CreateTeamAdditionCommand(team);
            addTeamCommand.Execute();
        }

        public void RemoveTeam(Team team)
        {
            Ensure.ArgumentNotNull(team);
            ICommand removeTeamCommand = CreateTeamRemovalCommand(team);
            removeTeamCommand.Execute();
        }

        public abstract ICommand CreateTeamAdditionCommand(Team team);
        public abstract ICommand CreateTeamRemovalCommand(Team team);        
    }
}