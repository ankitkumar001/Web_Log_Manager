using System;

namespace WSLA
{
	/// <summary>
	/// Summary description for HourlyTrafficListView.
	/// </summary>
	public class HourlyTrafficListView : QueryListView
	{
		public override String GetQuery(DateTime Date1, DateTime Date2)
		{
			String Result =
				"SELECT DISTINCT DateSerial(Year([DT]),Month([DT]),Day([DT])) AS [Date], Hour([DT]) AS [Hour], Sum([Bytes]) AS [Downloads (bytes)]\n" +
				"FROM HTTPInfo\n" +
				"WHERE [HTTPInfo].[DT] >= " + GetSQLDate(Date1) + " AND [HTTPInfo].[DT] < " + GetSQLDate(Date2.AddDays(1)) + "\n" +
				"GROUP BY DateSerial(Year([DT]),Month([DT]),Day([DT])), Hour([DT])\n" +
				"ORDER BY DateSerial(Year([DT]),Month([DT]),Day([DT])), Hour([DT]);";

			return Result;
		}
	}
}
