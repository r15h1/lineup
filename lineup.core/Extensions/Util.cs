using System;
using System.Text.RegularExpressions;

namespace LineUp.Core.Extensions
{
    public static class Util
    {
        public static bool IsEmpty(this Guid guid)
        {
            return guid == Guid.Empty;
        }

        public static bool IsEmpty(this string s)
        {
            return string.IsNullOrWhiteSpace(s);
        }

		public static bool IsValidEmail(this string email) {
			if (email.IsEmpty()) return false;

			try {
				return Regex.IsMatch(email,
						@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
						@"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
						RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
			} catch (RegexMatchTimeoutException) {
				return false;
			}
		}

		public static bool IsValidUrl(this string url) {
			return Uri.IsWellFormedUriString(url, UriKind.Absolute);
		}		
	}
}
