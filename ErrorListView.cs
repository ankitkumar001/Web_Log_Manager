using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace WSLA
{
	/// <summary>
	/// Summary description for ErrorsListView.
	/// </summary>
	public class ErrorsListView : QueryListView
	{
		public override String GetQuery(DateTime Date1, DateTime Date2)
		{
			String Result =
				"SELECT DateSerial(Year([DT]),Month([DT]),Day([DT])) AS [Date], [StatusCodes].[Code] AS [Error Code], [StatusCodes].[Category] AS Category, [StatusCodes].[Description] AS Description, [HTTPInfo].[FileName] AS [File Name], [HTTPInfo].[ReferringURL] AS [Referring URL]\n" +
				"FROM HTTPInfo, StatusCodes\n" +
				"WHERE [HTTPInfo].[DT] >= " + GetSQLDate(Date1) + " AND [HTTPInfo].[DT] < " + GetSQLDate(Date2.AddDays(1)) + " AND\n" +
				"[HTTPInfo].[StatusCode]=[StatusCodes].[Code] And [HTTPInfo].[StatusCode]>=400 AND [HTTPInfo].[StatusCode]<500\n" +
				"ORDER BY DateSerial(Year([DT]),Month([DT]),Day([DT])), [StatusCodes].[Code];\n";

			return Result;
		}
	}
}
