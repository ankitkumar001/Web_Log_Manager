using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WSLA
{
    /// <summary>
    /// Summary description for DomainsListView.
    /// </summary>
    public class DomainsListView : QueryListView
    {
        public override String GetQuery(DateTime Date1, DateTime Date2)
        {
            String Result =
"SELECT [CountryCodes].[Description] AS [Country]," +
"  Count(*) AS [# Requests], Sum([Bytes]) " +
"  AS [Bytes]\n" +
"FROM HTTPInfo, CountryCodes\n" +
"WHERE [HTTPInfo].[TopLevelDomain] = " +
"  [CountryCodes].[Code] AND\n" +
"  [HTTPInfo].[DT] >= " + GetSQLDate(Date1) +
"  AND [HTTPInfo].[DT] < " +
GetSQLDate(Date2.AddDays(1)) + "\n" +
"GROUP BY [Description]\n" +
"ORDER BY [Description];";

            return Result;
        }
    }
}
