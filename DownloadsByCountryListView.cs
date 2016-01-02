using System;
using System.Windows.Forms;

namespace WSLA
{
	/// <summary>
	/// Summary description for DownloadsByCountryListView.
	/// </summary>
	public class DownloadsByCountryListView : QueryListView
	{
		public override String GetQuery(DateTime Date1, DateTime Date2)
		{
			String Result = 
				"SELECT [CountryCodes].[Description] AS [Country], [FileName] AS [File], Count([HTTPInfo].[FileName]) AS [# Requests], Sum([Bytes]) AS [Bytes]\n" +
				"FROM HTTPInfo, CountryCodes\n" +
				"WHERE [HTTPInfo].[TopLevelDomain]=[CountryCodes].[Code] AND\n" +
				"[HTTPInfo].[DT] >= " + GetSQLDate(Date1) + " AND [HTTPInfo].[DT] < " + GetSQLDate(Date2.AddDays(1)) + "\n" +
				"GROUP BY [Description], [FileName]\n" + 
				"ORDER BY [Description], [FileName];";

			return Result;
		}
	}
}
