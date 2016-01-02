using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace WSLA
{
	/// <summary>
	/// Summary description for DailyTrafficListView.
	/// </summary>
	public class DailyTrafficListView : QueryListView
	{
		public override String GetQuery(DateTime Date1, DateTime Date2)
		{
			String Result =
				"SELECT DISTINCT DateSerial(Year([DT]),Month([DT]),Day([DT])) AS [Date], Sum([Bytes]) AS [Downloads (bytes)]\n" +
				"FROM HTTPInfo\n" +
				"WHERE [HTTPInfo].[DT] >= " + GetSQLDate(Date1) + " AND [HTTPInfo].[DT] < " + GetSQLDate(Date2.AddDays(1)) + "\n" +
				"GROUP BY DateSerial(Year([DT]),Month([DT]),Day([DT]))\n" +
				"ORDER BY DateSerial(Year([DT]),Month([DT]),Day([DT]));";

			return Result;
		}

	}
}
