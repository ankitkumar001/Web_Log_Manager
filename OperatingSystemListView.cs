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
	public class OperatingSystemsListView : QueryListView
	{
		public override String GetQuery(DateTime Date1, DateTime Date2)
		{
			String Result = 

			"SELECT count([UserAgent]) AS [# Requests], \"Windows 95\" AS [Operating System]\n" +
			"FROM HTTPInfo\n" +
			"WHERE UserAgent LIKE \"%Windows 95)%\" OR UserAgent LIKE \"%Windows 95;%\";\n" +

			"UNION SELECT count([UserAgent]), \"Windows 98\" AS [Operating System]\n" +
			"FROM HTTPInfo\n" +
			"WHERE UserAgent LIKE \"%Windows 98)%\"\n" +

			"UNION SELECT count([UserAgent]), \"Windows ME\" AS [Operating System]\n" +
			"FROM HTTPInfo\n" +
			"WHERE UserAgent LIKE \"%Win 9x 4.90%\"\n" +

			"UNION SELECT count([UserAgent]) AS [# Requests], \"Windows 2000\" AS [Operating System]\n" +
			"FROM HTTPInfo\n" +
			"WHERE UserAgent LIKE \"%Windows 2000)%\" OR UserAgent LIKE \"%Windows 2000;%\" OR\n" +
			"UserAgent LIKE \"%Windows NT 5.0)%\" OR UserAgent LIKE \"%Windows NT 5.0;%\";\n" +

			"UNION SELECT count([UserAgent]) AS [# Requests], \"Windows NT 4.0\" AS [Operating System]\n" +
			"FROM HTTPInfo\n" +
			"WHERE UserAgent LIKE \"%Windows NT 4.0)%\" OR UserAgent LIKE \"%Windows NT 4.0;%\";\n" +

			"UNION SELECT count([UserAgent]) AS [# Requests], \"Windows XP\" AS [Operating System]\n" +
			"FROM HTTPInfo\n" +
			"WHERE UserAgent LIKE \"%Windows NT 5.1)%\" OR UserAgent LIKE \"%Windows NT 5.1;%\";\n" +

			"UNION SELECT count([UserAgent]) AS [# Requests], \"Windows Server 2003\" AS [Operating System]\n" +
			"FROM HTTPInfo\n" +
			"WHERE UserAgent LIKE \"%Windows NT 5.2)%\" OR UserAgent LIKE \"%Windows NT 5.2;%\";\n";

			return Result;
		}
	}
}
