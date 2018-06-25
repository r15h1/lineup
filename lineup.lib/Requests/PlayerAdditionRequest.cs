using LineUp.Core;
using System;

namespace LineUp.Lib.Requests {
	public class PlayerAdditionRequest : IRequest {
		public Guid PlayerGuid { get; set; }
		public Guid ClubGuid { get; set; }
		public Guid TeamGuid{ get; set; }

		public void Validate() {
			throw new NotImplementedException();
		}
	}
}
