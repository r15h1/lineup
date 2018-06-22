using System.Collections.Generic;

namespace LineUp.Core {
	public class Player:Member
    {
		private List<ContactInfo> contactInfoList = new List<ContactInfo>();
		public IEnumerable<ContactInfo> ContactInfo { get; set; }

		public void AddContactInfo(ContactInfo contactInfo) {
			if (contactInfo != null && !contactInfoList.Contains(contactInfo)) {
				contactInfoList.Add(contactInfo);
			}
		}

		public void RemoveContactInfo(ContactInfo contactInfo) {
			if (contactInfo != null && contactInfoList.Contains(contactInfo)) {
				contactInfoList.Remove(contactInfo);
			}
		}
	}
}
