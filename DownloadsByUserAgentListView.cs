using System;

namespace WSLA
{
	/// <summary>
	/// Summary description for DownloadsByUserAgentListView.
	/// </summary>
	public class DownloadsByUserAgentListView : QueryListView
	{
		private System.ComponentModel.Container components = null;

		public DownloadsByUserAgentListView()
		{
			InitializeComponent();
		}

		public override String GetQuery(DateTime Date1, DateTime Date2)
		{
			String Result =
				"SELECT [UserAgent] AS [User Agent], [FileName] AS URL, Count(*) AS [# Requests]\n" +
				"FROM HTTPInfo\n" +
				"WHERE [HTTPInfo].[DT] >= " + GetSQLDate(Date1) + " AND [HTTPInfo].[DT] < " + GetSQLDate(Date2.AddDays(1)) + "\n" +
				"GROUP BY [UserAgent], [FileName]\n" +
				"ORDER BY [UserAgent], [FileName];";

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
			this.SelectedIndexChanged += new System.EventHandler(this.DownloadsByUserAgentListView_SelectedIndexChanged);
		}
		#endregion

		private void DownloadsByUserAgentListView_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (SelectedIndices.Count == 1)
			{
				int Index = SelectedIndices[0];

				String URL = ExtractURL.Extract(Items[Index].SubItems[0].Text);

				MainForm MF = (MainForm) this.Parent.Parent.Parent;
				MF.DisplayURLInBrowser(URL);
			}
		}
	}	
}
