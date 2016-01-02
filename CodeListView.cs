using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace WSLA
{
	/// <summary>
	/// Summary description for StatusCodesListView.
	/// </summary>
	public class StatusCodesListView : QueryListView
	{
		public override String GetQuery(DateTime Date1, DateTime Date2)
		{
			String Result = 

				"SELECT Count(*) AS [# Occurrences], [StatusCodes].[Code] AS [Number], [StatusCodes].[Category] AS Category, [StatusCodes].[Description] AS Description\n" +
				"FROM HTTPInfo, StatusCodes\n" +
				"WHERE [HTTPInfo].[StatusCode]=[StatusCodes].[Code] AND\n" +
				"[HTTPInfo].[StatusCode] < 400 AND\n" +
				"[HTTPInfo].[DT] >= " + GetSQLDate(Date1) + " AND [HTTPInfo].[DT] < " + GetSQLDate(Date2.AddDays(1)) + "\n" +
				"GROUP BY [StatusCodes].[Code], [StatusCodes].[Category], [StatusCodes].[Description]\n" +
				"ORDER BY [StatusCodes].[Code];";

			return Result;
		}
	}
}
