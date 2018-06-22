using System;

namespace LineUp.Core {
	public class Member
    {
		public Guid Guid{ get; set; }
		public PersonalInfo PersonalInfo { get; set; } = new PersonalInfo();
	}
}
