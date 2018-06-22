using LineUp.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace LineUp.Lib
{
    public class TeamSquad : Team
    {
        public TeamSquad() : base() { }
        public TeamSquad(Guid guid) : base(guid) { }

        public override ICommand GetPlayerAdditionCommand()
        {
            throw new NotImplementedException();
        }
    }
}
