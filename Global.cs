using System;
using System.Text.RegularExpressions;

namespace WSLA
{
	/// <summary>
	/// Summary description for Globals.
	/// </summary>
	public class Globals
	{
		public static Regex REQuery = new Regex(@"(?<Prefix>(&|\?)(q|query|qkw|qry|p|keywords)=)(?<Query>[^(&|\?)]*)", RegexOptions.IgnoreCase | RegexOptions.Compiled);

		public static DecodeIPAddresses m_DecodeIPAddresses = new DecodeIPAddresses();

		public static Database m_Database = new Database();

		public static readonly String ProgramName = "WSLA";

		private Globals()
		{
		}
	}
}
