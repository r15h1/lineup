using System;
using System.Collections.Generic;
using System.Text;

namespace LineUp.Core.Extensions
{
    public static class Ensure
    {
        public static void ArgumentNotNull(object obj)
        {
            if (obj == null) throw new ArgumentNullException();
        }

		public static void NotEmpty(Guid guid) {
			if (guid.IsEmpty()) throw new ArgumentNullException();
		}
	}
}
