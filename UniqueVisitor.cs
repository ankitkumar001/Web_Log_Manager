using System;

namespace WSLA
{
	/// <summary>
	/// Summary description for UniqueVisitorsListView.
	/// </summary>
	public class UniqueVisitorsListView : QueryListView
	{
		public override String GetQuery(DateTime Date1, DateTime Date2)
		{
			String Result =
				"SELECT Count(*) AS [# Unique Visitors]\n" +
				"FROM\n" +
				"(SELECT DISTINCT IPAddress FROM HTTPInfo WHERE DT >= " + GetSQLDate(Date1) + " AND DT < " + GetSQLDate(Date2.AddDays(1)) + ");";

			return Result;
		}

	}
}
