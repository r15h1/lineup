using LineUp.Core.Extensions;
using System.Collections.Generic;

namespace LineUp.Core {
	public class ContactInfo
    {
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Relationship { get; set; }
		public bool IsMainContact { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
	}
}