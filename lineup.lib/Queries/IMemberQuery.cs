using LineUp.Core;
using System;

namespace LineUp.Lib.Queries {
	public interface IMemberQuery
    {
		Member GetMember(Guid clubGuid, Guid memberGuid);
    }
}
