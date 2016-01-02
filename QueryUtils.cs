using System;
using System.Text.RegularExpressions;
using System.Text;

namespace WSLA
{
	/// <summary>
	/// Summary description for QueryUtils.
	/// </summary>
	public class QueryUtils
	{
		public static readonly String []Patterns = 
			{ "?q=", "&q=",
			  "?query=", "&query=",
			  "?qkw=", "&qkw=",
			  "?qry=", "&qry=",
			  "?p=", "&p=",
			  "?keywords=", "&keywords="
			};
		
		public static readonly Regex WordsRE = new Regex(@"[A-Z]+[A-Z']+|C#|C\+\+", RegexOptions.IgnoreCase | RegexOptions.Compiled);
		public static readonly Regex QueryRE = new Regex(QueryREPattern(), RegexOptions.IgnoreCase | RegexOptions.Compiled);
		private static readonly Regex REPlus = new Regex(@"[\+]+", RegexOptions.Compiled);

		private QueryUtils()
		{
		}

		private static String ProcessCharCodes(string s)
		{
			string result = s;

			if (s.IndexOf('%') != -1)
			{
				StringBuilder stringBuilder = new StringBuilder("");

				for (int i = 0; i < s.Length; i++)
				{
					char c = s[i];

					if (c != '%')
					{
						stringBuilder.Append(c);
					}
					else if (i + 2 < s.Length)
					{
						int index = 0;
						stringBuilder.Append(Uri.HexUnescape(s.Substring(i, 3), ref index));
						i += 2;
					}
					else
					{
						stringBuilder.Append(c);
					}
				}

				result = stringBuilder.ToString();
			}

			return result;
		}

		private static String ProcessPlusSigns(String S)
		{
			return REPlus.Replace(S, " ");
		}

		public static String ExtractQuery(String ReferringURL)
		{
			return ProcessPlusSigns(ProcessCharCodes(Globals.REQuery.Match(ReferringURL).Result("${Query}"))).Trim();
		}

		private static String QueryREPattern()
		{
			String Result = "";

			for (int i = 0; i < QueryUtils.Patterns.Length; i++)
			{
				Result += QueryUtils.Patterns[i];
				
				if (i < QueryUtils.Patterns.Length - 1)
				{
					Result += "|";
				}
			}

			Result = Result.Replace("=", "\\=");
			Result = Result.Replace("&", "\\&");
			Result = Result.Replace("?", "\\?");

			return Result;
		}

	}
}
