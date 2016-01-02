using System;
using System.Text.RegularExpressions;

namespace WSLA
{
	/// <summary>
	/// Summary description for ExtractURL.
	/// </summary>
	public class ExtractURL
	{
		private ExtractURL()
		{
		}

		public static String Extract(String Text)
		{
			String Result = "about:blank";

			// Extract URL from UserAgent field if there is one.
			String URLCharacters = @"[a-zA-Z0-9\._~/#%&+-:?;]+";
			String Pattern = @"http://" + URLCharacters + @"|www\." + URLCharacters;

			Regex R = new Regex(Pattern, RegexOptions.IgnoreCase);

			MatchCollection M = R.Matches(Text);

			if (M.Count > 0)
			{
				String URL = M[0].Value;

				if (URL.ToUpper().IndexOf("HTTP://") != 0)
				{
					URL = "http://" + URL;
				}

				if (URL.Length > 0 && URL.IndexOf(";") == URL.Length - 1)
				{
					URL = URL.Substring(0, URL.Length - 1);
				}

				Result = URL;
			}

			return Result;
		}
	}
}
