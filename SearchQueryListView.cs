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
	/// Summary description for SearchQueriesListView.
	/// </summary>
	public class SearchQueriesListView : QueryListView
	{
		private System.ComponentModel.Container components = null;

		public SearchQueriesListView()
		{
			InitializeComponent();
		}

		public override String GetQuery(DateTime Date1, DateTime Date2)
		{
			String ReferringURL = "";

			for (int i = 0; i < QueryUtils.Patterns.Length; i++)
			{
				ReferringURL += "ReferringURL Like " + "\"%" + QueryUtils.Patterns[i] + "%\"";
				
				if (i < QueryUtils.Patterns.Length - 1)
				{
					ReferringURL += " OR";
				}

				ReferringURL += "\n";
			}

			String Result = 
				"SELECT [ReferringURL] AS Query, [ReferringURL] AS [Search Engline], [FileName] AS URL, Count(*) AS [# Occurrences]\n" +
				"FROM HTTPInfo\n" +
				"WHERE [HTTPInfo].[DT] >= " + GetSQLDate(Date1) + " AND [HTTPInfo].[DT] < " + GetSQLDate(Date2.AddDays(1)) + " AND\n" +
				"(\n" + ReferringURL + ")\n" + 
				"GROUP BY [ReferringURL], [ReferringURL], [FileName]\n" +
				"ORDER BY [ReferringURL], [ReferringURL], [FileName];";

			return Result;
		}

		protected override void FormatFields(String[] Fields)
		{
			base.FormatFields(Fields);

			Fields[0] = QueryUtils.ExtractQuery(Fields[0]);

			Uri URL = new Uri(Fields[1]);
			Fields[1] = URL.Host;
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
			this.SelectedIndexChanged += new System.EventHandler(this.SearchQueriesListView_SelectedIndexChanged);
		}
		#endregion

		private void SearchQueriesListView_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (SelectedIndices.Count == 1)
			{
				int Index = SelectedIndices[0];

				String URL = ExtractURL.Extract(Items[Index].SubItems[1].Text);

				MainForm MF = (MainForm) this.Parent.Parent.Parent;
				MF.DisplayURLInBrowser(URL);
			}
		}
	}	
}
