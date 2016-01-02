using System;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;

namespace WSLA
{
	/// <summary>
	/// Summary description for SearchWordsListView.
	/// </summary>
	public class SearchWordsListView : QueryListView
	{
		private System.ComponentModel.Container components = null;

		public SearchWordsListView()
		{
			InitializeComponent();
		}

		public override String GetQuery(DateTime Date1, DateTime Date2)
		{
			String Result = 
				"SELECT DISTINCT Word, Count(*) AS [# Occurrences]\n" +
				"FROM SearchWords\n" +
				"WHERE [SearchWords].[DT] >= " + GetSQLDate(Date1) + " AND [SearchWords].[DT] < " + GetSQLDate(Date2.AddDays(1)) + " AND\n" +
				"SearchWords.Word NOT IN (SELECT Word FROM StopWords)\n" +
				"GROUP BY Word\n" +
				"ORDER BY Count(*) DESC, [Word] ASC\n";

			return Result;
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		}
		#endregion

	}	
}
