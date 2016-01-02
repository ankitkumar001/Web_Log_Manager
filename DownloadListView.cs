using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace WSLA
{
	public class DownloadsListView : QueryListView
	{
		public override String GetQuery(DateTime Date1, DateTime Date2)
		{
			String Result =

				"SELECT Count(*) AS [# Requests], Sum([HTTPInfo.Bytes]) AS Bytes, [FileName] AS File\n" +
				"FROM HTTPInfo\n" +
				"WHERE [HTTPInfo].[DT] >= " + GetSQLDate(Date1) + " AND [HTTPInfo].[DT] < " + GetSQLDate(Date2.AddDays(1)) + "\n" +
				"GROUP BY [FileName]\n" +
				"ORDER BY [FileName];\n";

			return Result;
		}
	}
}

