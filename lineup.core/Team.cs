using LineUp.Core.Extensions;
using System;

namespace LineUp.Core
{
    public abstract class Team
    {
        public Team()
        {
            Guid = Guid.NewGuid();
        }
        public Team(Guid guid)
        {
            Guid = guid;
        }
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public void AddPlayer(Player player)
        {
            Ensure.ArgumentNotNull(player);
            ICommand playerAdditionCommand = GetPlayerAdditionCommand();
            playerAdditionCommand.Execute();
        }

        public abstract ICommand GetPlayerAdditionCommand();
    }
}