using System;

namespace WSLA
{
	/// <summary>
	/// Summary description for DotNetListView.
	/// </summary>
	public class DotNetListView : QueryListView
	{
		public override String GetQuery(DateTime Date1, DateTime Date2)
		{
			String Result =
				"SELECT round(count(*) / (select count(*) from (Select distinct IPAddress from HTTPInfo )) * 100) AS [%]\n" +
				"FROM [select distinct IPAddress from HTTPInfo where UserAgent LIKE \"%.NET CLR%\"]. AS [result];\n";

				return Result;
		}
	}
}
